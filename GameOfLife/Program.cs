using System;
using System.Collections.Generic;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            const uint rows = 50;
            const uint columns = 50;
            var board = GenerateRandomBoard(rows, columns, 1);
            var game = new Game(rows, columns, board);
            game.Play(10000);

            Console.WriteLine($"Generation={game.Generation}, Population={game.Population}");

            Console.ReadLine();
        }

        private static bool[,] GenerateRandomBoard(uint rows, uint columns, double coverage) 
        {
            var result = new bool[rows, columns];
            var totalItems = (int) (rows * columns);
            var itemsToAssign =(int) (coverage * totalItems);

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
    }
}
