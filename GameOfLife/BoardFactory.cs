using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public static class BoardFactory
    {
        #region Public Methods

        public static Board Create(int rows, int columns, double coverage)
        {
            var grid = GenerateRandomBoard(rows, columns, coverage);
            return new Board(rows, columns, grid);
        }

        #endregion Public Methods


        #region Private Methods

        private static IDictionary<int, bool[]> GenerateRandomBoard(int rows, int columns, double coverage)
        {
            var result = new Dictionary<int, bool[]>();
            for (var i = 0; i < rows; i++)
            {
                result.Add(i, new bool[columns]);
            }

            var totalItems = (int)(rows * columns);
            var itemsToAssign = (int)(coverage * totalItems);

            var randomIndexes = GenerateRandomInts(itemsToAssign, totalItems);
            foreach (var index in randomIndexes)
            {
                result[(int)(index / rows)][index % rows] = true;
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

        #endregion Private Methods
    }
}