using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public static class BoardFactory
    {
        #region Members

        private static readonly Random Random = new();

        #endregion Members


        #region Public Methods

        public static Board Create(int rows, int columns, double coverage)
        {
            if(coverage < 0 || coverage > 1)
                throw new ArgumentException($"{nameof(coverage)}={coverage}, not in range 0-1");

            var grid = GenerateRandomBoard(rows, columns, coverage);
            return new Board(rows, columns, grid);
        }

        public static Board Create(IDictionary<int, bool[]> grid)
        {
            return new Board(grid.Count, grid[0].Length, grid);
        }

        public static Board Crossover(Board boardA, Board boardB, double probability)
        {
            var rnd = Random.NextDouble();
            if (probability < rnd)
                return boardA;

            var aList = boardA.Grid.ToList();
            var bList = boardB.Grid.ToList();

            var pivot = Random.Next(aList.Count);

            var partialA = aList.Take(pivot);
            var partialB = bList.TakeLast(bList.Count - pivot);

            var crossoverList = partialA.Concat(partialB).ToDictionary(i => i.Key, 
                i => i.Value);

            return Create(crossoverList);
        }

        public static Board Mutation(Board board, double probability, double maxMutationRation = 0.01)
        {
            var rnd = Random.NextDouble();
            if (probability < rnd)
                return board;
            
            var result = new Board(board);

            var maxCellsToMutation =(int) (board.Columns * board.Rows * maxMutationRation);
            var mutationNum = Random.Next(maxCellsToMutation);
            var indexesToMutation = GenerateRandomInts(mutationNum, board.Columns * board.Rows);

            foreach (var index in indexesToMutation)
            {
                result.Grid[index / result.Rows][index % result.Rows] = !result.Grid[index / result.Rows][index % result.Rows];
            }

            return result;
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
                result[index / rows][index % rows] = true;
            }

            return result;
        }

        private static IEnumerable<int> GenerateRandomInts(int count, int maxValue)
        {
            // generate count random values.
            var candidates = new HashSet<int>(count);
            while (candidates.Count < count)
            {
                // May strike a duplicate.
                candidates.Add(Random.Next(maxValue));
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