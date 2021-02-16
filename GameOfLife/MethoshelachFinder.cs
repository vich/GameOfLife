﻿using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GameOfLife
{
    public static class MethoshelachFinder
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

        public static Game FindGoodMethoshelach(int chromosomeNum, double mutationProb, double crossoverProb, double keepBestRation = 0.2 )
        {
            var sw = new Stopwatch();
            sw.Start();

            _chromosomes = new ConcurrentDictionary<int, Game>();
            var bestChromosomeNum = (int)(chromosomeNum * keepBestRation);
            var round = 0;

            //init first generation 
            Parallel.For(0, chromosomeNum, index => _chromosomes.TryAdd(index ,CreateGameAndRun(index)));

            foreach (var chromosome in _chromosomes)
            {
                chromosome.Value.Save(@"C:\Temp\Data\25");
            }

            while (round < 5_000)
            {
                round++;

                //Rank Selection
                var games = _chromosomes.Values.OrderBy(Fitness).Reverse();
                var bestGames = games.Take(bestChromosomeNum).ToList();
                var bestFitness = Fitness(bestGames.First());
                Console.WriteLine($"best fitness={bestFitness} for round {round}");

                if (bestFitness > 1000)
                    break;

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
            return _chromosomes.Values.OrderBy(Fitness).Last();
        }


        #endregion Public Methods


        #region Private Methods

        private static Game CreateDescendants(int bestChromosomeNum, double crossoverProb)
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

        private static Game CreateGameAndRun(int index)
        {
            while(true)
            {
                var game = GameFactory.Create(Rows, Columns, 25, 0.4);
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

        private static double Fitness(Game game)
        {
            if (game.StartBoard.Population > 0)
                return game.Generation + (game.MaxPopulation / game.StartBoard.Population);
            else
                return game.Generation;
        }

        #endregion Private Methods
    }
}