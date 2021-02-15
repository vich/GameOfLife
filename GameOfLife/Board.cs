using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Board
    {
        #region Members

        private static int _gameNumber;

        private static DateTime _startTime = DateTime.MinValue;
        
        #endregion Members

        #region Prorperties

        public uint Rows { get; }

        public uint Columns { get; }

        public bool[,] Grid { get; private set; }

        public bool[,] StartBoard { get; }

        public int Generation { get; private set; }

        public int Population => Grid.Cast<bool>().Count(cell => cell);

        public int GameNumber => _gameNumber;

        #endregion Prorperties

        #region Constructor

        public Board(uint rows, uint columns, bool[,] board = null)
        {
            Rows = rows;
            Columns = columns;
            Grid = board ?? new bool[Rows, Columns];
            StartBoard = (bool[,])Grid.Clone();
            
            Generation = 1;
            _gameNumber++;
            if (_startTime == DateTime.MinValue)
                _startTime = DateTime.Now;
        }

        #endregion Constructor

        #region Public Methods
        
        public async void Save()
        {
            var fileName = $"{nameof(Board)}_{_startTime}_{GameNumber}";

            using var createStream = File.Create(fileName);
            await JsonSerializer.SerializeAsync(createStream, this);
        }

        public async Task<Board> Load(string path)
        {
            using FileStream openStream = File.OpenRead(path);
            return await JsonSerializer.DeserializeAsync<Board>(openStream);
        }

        public bool CalculateNextGeneration()
        {
            Generation++;
            var nextGeneration = new bool[Rows, Columns];

            // Loop through every cell 
            for (var row = 1; row < Rows - 1; row++)
            {
                for (var column = 1; column < Columns - 1; column++)
                {
                    // find your alive neighbors
                    var aliveNeighbors = 0;
                    for (var i = -1; i <= 1; i++)
                    {
                        for (var j = -1; j <= 1; j++)
                        {
                            aliveNeighbors += Grid[row + i, column + j] ? 1 : 0;
                        }
                    }

                    var currentCell = Grid[row, column];

                    // The cell needs to be subtracted 
                    // from its neighbors as it was  
                    // counted before 
                    aliveNeighbors -= currentCell ? 1 : 0;

                    // Implementing the Rules of Life 

                    // Cell is lonely and dies 
                    if (currentCell && aliveNeighbors < 2)
                    {
                        nextGeneration[row, column] = false;
                    }

                    // Cell dies due to over population 
                    else if (currentCell == aliveNeighbors > 3)
                    {
                        nextGeneration[row, column] = false;
                    }

                    // A new cell is born 
                    else if (currentCell == false && aliveNeighbors == 3)
                    {
                        nextGeneration[row, column] = true;
                    }
                    // All other cells stay the same
                    else
                    {
                        nextGeneration[row, column] = currentCell;
                    }
                }
            }

            var result = SameGrid(Grid, nextGeneration);

            Grid = nextGeneration;

            return result;
        }

        #endregion Public Methods

        #region Private Grid

        private static bool SameGrid(bool[,] gridA, bool[,] gridB)
        {
            var rowsA = gridA.GetLength(0);
            var columnsA = gridA.GetLength(1);
            var rowsB = gridB.GetLength(0);
            var columnsB = gridB.GetLength(1);

            if (rowsA != rowsB || columnsA != columnsB)
                return false;

            for (var i = 0; i < rowsA; i++)
            {
                for (var j = 0; j < columnsB; j++)
                {
                    if (gridA[i, j] != gridB[i, j])
                        return false;
                }
            }

            return true;
        }

        #endregion
    }
}