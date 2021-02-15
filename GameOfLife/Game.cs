using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class Game
    {
        public Board Board { get; }

        public Game(uint rows, uint columns, double coverage, uint iterationToPlay)
        {
            var grid = GenerateRandomBoard(rows, columns, coverage);
            Board = new Board(rows, columns, grid);
            Play(iterationToPlay);
        }

        #region Private Methods

        private void Play(uint maxIterations = 1)
        {
            for (var i = 0; i < maxIterations; i++)
            {
                Console.WriteLine($"Generation={Board.Generation}, Population={Board.Population}");
                var changed = Board.CalculateNextGeneration();
                if (changed)
                    break;
            }
        }

        private static bool[,] GenerateRandomBoard(uint rows, uint columns, double coverage)
        {
            var result = new bool[rows, columns];
            var totalItems = (int)(rows * columns);
            var itemsToAssign = (int)(coverage * totalItems);

            var randomIndexes = GenerateRandomInts(itemsToAssign, totalItems);
            foreach (var index in randomIndexes)
            {
                result[index / rows, index % rows] = true;
            }

            return result;
        }

        private static IEnumerable<int> GenerateRandomInts(int count, int maxValue)
        {
            var random = new Random();
            // generate count random values.
            var candidates = new HashSet<int>(count);
            while (candidates.Count < count)
            {
                // May strike a duplicate.
                candidates.Add(random.Next(maxValue));
            }

            // load them in to a list.
            var result = new List<int>();
            result.AddRange(candidates);
            result.Sort();

            return result;
        }

        #endregion
    }
}