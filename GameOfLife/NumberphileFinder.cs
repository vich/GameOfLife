using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class NumberphileFinder
    {
        #region Members

        private const int Rows = 50;
        private const int Columns = 50;
        private const double Coverage = 0.15;
        private const int MaxIterationToPlay = 10000;
        private static ConcurrentDictionary<int,Game> _chromosomes;

        private static Random Random { get; } = new();



        #endregion Members


        #region Public Methods
        
        public (Game, IList<Coords>) FindNumberphile(int chromosomeNum, double mutationProb, double crossoverProb, double keepBestRation = 0.2, int maxIteration = 1000)
        {
            var sw = new Stopwatch();
            sw.Start();
            var coordinates = new List<Coords>();

            _chromosomes = new ConcurrentDictionary<int, Game>();
            var bestChromosomeNum = (int)(chromosomeNum * keepBestRation);
            var round = 0;

            //init first generation 
            var files = Directory.GetFiles(@"C:\Temp\InitData2");
            for (var index = 0; index < files.Length && index < chromosomeNum; index++)
            {
                var jsonPath = files[index];
                var game = Game.Load(jsonPath);
                _chromosomes.TryAdd(index, game);
            }

            // Parallel.For(0, chromosomeNum, index => _chromosomes.TryAdd(index ,CreateGameAndRun(index)));
            //
            // foreach (var chromosome in _chromosomes)
            // {
            //     chromosome.Value.Save(@"C:\Temp\InitData2");
            // }

            while (round < maxIteration)
            {
                round++;

                //Rank Selection
                var games = _chromosomes.Values.OrderBy(Fitness).Reverse();
                var bestGames = games.Take(bestChromosomeNum).ToList();
                var bestFitness = Fitness(bestGames.First());
                Console.WriteLine($"best fitness={bestFitness} for round {round}");
                coordinates.Add(new Coords(round, bestFitness));
                
                // if (bestFitness >= 10_000)
                //     break;

                _chromosomes.Clear();
                for (var i = 0; i < bestChromosomeNum; i++)
                {
                    _chromosomes.TryAdd(i, bestGames[i]);
                }

                //crossover
                Parallel.For(bestChromosomeNum, chromosomeNum, index => _chromosomes.TryAdd(index, CreateDescendants(bestChromosomeNum, crossoverProb)));

                //mutation
                Parallel.For(0, chromosomeNum, index =>
                {
                    _chromosomes[index].Board = BoardFactory.Mutation(_chromosomes[index].Board, mutationProb);
                    _chromosomes[index].Play(MaxIterationToPlay);
                });
            }

            Console.WriteLine($"stopwatch={sw.Elapsed}");
            sw.Stop();
            foreach (var game in _chromosomes.TakeLast(10))
            {
                game.Value.Save();
            }

            //return the best game
            return (_chromosomes.Values.OrderBy(Fitness).Last(), coordinates);
        }

        public double Fitness(Game game)
        {
            if (game.StartBoard.Population > 0)
                return game.Generation + (game.MaxPopulation / game.StartBoard.Population);
            else
                return game.Generation;
        }

        #endregion Public Methods


        #region Private Methods

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
                var game = GameFactory.Create(Rows, Columns, 15, 0.4);
                game.Play(MaxIterationToPlay);

                if(game.Generation < MaxIterationToPlay) //the board didn't stabilize
                {
                    Console.WriteLine($"Create game {index}");
                    return game;
                }
                else
                {
                    Console.WriteLine($"Game run for to much generations, saved to files");
                    game.Save(@"C:\Temp\Data\Check");
                }
            }
        }


        #endregion Private Methods
    }
}