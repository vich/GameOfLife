using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Game
    {
        #region Members

        private static int _gameNumber;
        
        #endregion Members

        #region Prorperties

        public uint Rows { get; }

        public uint Columns { get; }

        public bool[,] Board { get; private set; }

        public bool[,] StartBoard { get; }

        public int Generation { get; private set; }

        public int Population => Board.Cast<bool>().Count(cell => cell);

        public int GameNumber => _gameNumber;

        #endregion Prorperties

        #region Constructor

        public Game(uint rows, uint columns, bool[,] board = null)
        {
            Rows = rows;
            Columns = columns;
            Board = board ?? new bool[Rows, Columns];
            StartBoard = (bool[,])Board.Clone();

            _gameNumber++;
        }

        #endregion Constructor

        #region Public Methods

        public void Play(int iteration = 1)
        {
            for (var i = 0; i < iteration; i++)
            {
                Console.WriteLine($"Generation={Generation}, Population={Population}");
                CalculateNextGeneration();
            }
        }
        
        public async void Save()
        {
            var fileName = $"{nameof(Game)}_{GameNumber}";

            using var createStream = File.Create(fileName);
            await JsonSerializer.SerializeAsync(createStream, this);
        }

        public async Task<Game> Load(string path)
        {
            using FileStream openStream = File.OpenRead(path);
            return await JsonSerializer.DeserializeAsync<Game>(openStream);
        }

        #endregion Public Methods

        #region Private Methods

        private void CalculateNextGeneration()
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
                            aliveNeighbors += Board[row + i, column + j] ? 1 : 0;
                        }
                    }

                    var currentCell = Board[row, column];

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

            Board = nextGeneration;
        }

        #endregion Private Methods
    }
}