using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class NumberphileFinder
    {
        #region Members

        private const int Rows = 50;
        private const int Columns = 50;
        private const int MaxIterationToPlay = 10000;
        private static ConcurrentDictionary<int,Game> _chromosomes;

        private static Random Random { get; } = new();


        #endregion Members


        #region Public Methods
        
        public (Game, IList<Coords>) FindNumberphile(int chromosomeNum, double mutationProb, double crossoverProb, double keepBestRation = 0.2, double newGenerationRation = 0.1, int maxIteration = 1000)
        {
            var coordinates = new List<Coords>();
            _chromosomes = new ConcurrentDictionary<int, Game>();
            var bestChromosomeNum = (int)(chromosomeNum * keepBestRation);
            var newChromosomeNum = (int) (chromosomeNum * newGenerationRation);
            var round = 0;
            
            Parallel.For(0, chromosomeNum, index => _chromosomes.TryAdd(index ,CreateGameAndRun(index)));
            
            foreach (var chromosome in _chromosomes)
            {
                chromosome.Value.Save();
            }

            double previousFitness = 1;
            const int period = 100;
            var movingAverage = new MovingAverage(period);
            
            while (round < maxIteration)
            {
                round++;

                //Rank Selection
                var games = _chromosomes.Values.OrderBy(game=>game.IsNumberphile).ThenBy(Fitness).Reverse();
                var bestGames = games.Take(bestChromosomeNum).ToList();
                var bestFitness = Fitness(bestGames.First());
                coordinates.Add(new Coords(round, bestFitness));
                movingAverage.Push(bestFitness / previousFitness);

                if (round > period && bestGames.First().IsNumberphile && movingAverage.Average < 1.01 )
                    break;
                
                previousFitness = bestFitness;
                _chromosomes.Clear();
                for (var i = 0; i < bestChromosomeNum; i++)
                {
                    _chromosomes.TryAdd(i, bestGames[i]);
                }

                //create new
                Parallel.For(bestChromosomeNum, bestChromosomeNum + newChromosomeNum, index => _chromosomes.TryAdd(index, CreateGameAndRun(index)));

                //crossover
                Parallel.For(bestChromosomeNum + newChromosomeNum, chromosomeNum, index => _chromosomes.TryAdd(index, CreateDescendants(bestChromosomeNum, crossoverProb)));

                //mutation
                Parallel.For(0, chromosomeNum, index =>
                {
                    _chromosomes[index].Board = BoardFactory.Mutation(_chromosomes[index].Board, mutationProb);
                    _chromosomes[index].Play(MaxIterationToPlay);
                });
            }
            
            foreach (var game in _chromosomes.TakeWhile(game => game.Value.IsNumberphile))
            {
                game.Value.Save();
            }

            SaveCoordinates(coordinates);
            //return the best game
            return (_chromosomes.Values.OrderBy(Fitness).Last(), coordinates);
        }

        public double Fitness(Game game)
        {
            if (game.StartBoard.Population > 0)
                return game.MaxPopulation / (double) game.StartBoard.Population;
            else
                return 0;
        }

        #endregion Public Methods


        #region Private Methods

        private void SaveCoordinates(IList<Coords> coordinates)
        {
            var fileName = $"Coordinates_{nameof(Board)}__{DateTime.Now.Ticks}.txt";

            var json = JsonSerializer.Serialize(coordinates);
            File.WriteAllText(fileName, json);
        }

        private Game CreateDescendants(int bestChromosomeNum, double crossoverProb)
        {
            while (true)
            {
                var boardA = _chromosomes[Random.Next(bestChromosomeNum)].Board;
                var boardB = _chromosomes[Random.Next(bestChromosomeNum)].Board;

                var boardChild = BoardFactory.Crossover(boardA, boardB, crossoverProb);

                var game = new Game(boardChild);
                game.Play(MaxIterationToPlay);

                if (game.Generation < MaxIterationToPlay) //the board didn't stabilize
                    return game;
            }
        }

        private Game CreateGameAndRun(int index)
        {
            while(true)
            {
                var game = GameFactory.Create(Rows, Columns, 10, 0.4);
                game.Play(MaxIterationToPlay);

                if(game.Generation < MaxIterationToPlay) //the board didn't stabilize
                {
                    return game;
                }
                else
                {
                    game.Save("Check");
                }
            }
        }


        #endregion Private Methods
    }
}