using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Game
    {
        private readonly uint _rows;
        private readonly uint _columns;

        #region Members

        private static int _gameNumber;

        private static DateTime _startTime = DateTime.MinValue;

        #endregion Members


        #region Prorperties

        public Board Board { get; set; }
       
        public bool[,] StartBoard { get; }
        
        public int Generation { get; private set; }

        #endregion Prorperties


        #region Constructor

        public Game(uint rows, uint columns, double coverage)
        {
            _rows = rows;
            _columns = columns;
            var grid = GenerateRandomBoard(_rows, _columns, coverage);
            Board = new Board(_rows, _columns, grid);
            StartBoard = (bool[,])grid.Clone();

            Generation = 1;
            _gameNumber++;
            if (_startTime == DateTime.MinValue)
                _startTime = DateTime.Now;
        }

        #endregion Constructor


        #region Public Methods

        protected bool Equals(Game other)
        {
            var equalStartBoard = StartBoard.Rank == other.StartBoard.Rank &&
                                  Enumerable.Range(0, StartBoard.Rank).All(dimension => StartBoard.GetLength(dimension) == other.StartBoard.GetLength(dimension)) &&
                                  StartBoard.Cast<bool>().SequenceEqual(other.StartBoard.Cast<bool>());

            return equalStartBoard && Equals(Board, other.Board) && Generation == other.Generation;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Game) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Board, StartBoard, Generation);
        }

        public async Task<string> Save()
        {
            var fileName = $"{nameof(Board)}__{_startTime.Day}_{_startTime.Month}__{_startTime.Hour}_{_startTime.Minute}__{_gameNumber}";
            
            using var createStream = File.Create(fileName);
            await JsonSerializer.SerializeAsync(createStream, this);

            return fileName;
        }

        public static async Task<Board> Load(string path)
        {
            using FileStream openStream = File.OpenRead(path);
            return await JsonSerializer.DeserializeAsync<Board>(openStream);
        }

        #endregion Public Methods


        #region Private Methods

        private void Play(uint maxIterations = 1)
        {
            for (var i = 0; i < maxIterations; i++)
            {
                Console.WriteLine($"Generation={Generation}, Population={Board.Population}");
                Generation++;
                var nextGenerationBoard = CalculateNextGeneration(Board);

                var equals = Board.Equals(nextGenerationBoard);
                if (equals)
                    break;

                Board = nextGenerationBoard;
            }
        }

        private Board CalculateNextGeneration(Board board)
        {
            var nextGenerationBoard = new Board(_rows, _columns, new bool[_rows, _columns]);

            // Loop through every cell 
            for (var row = 1; row < _rows - 1; row++)
            {
                for (var column = 1; column < _columns - 1; column++)
                {
                    // find your alive neighbors
                    var aliveNeighbors = 0;
                    for (var i = -1; i <= 1; i++)
                    {
                        for (var j = -1; j <= 1; j++)
                        {
                            aliveNeighbors += board[row + i, column + j] ? 1 : 0;
                        }
                    }

                    var currentCell = board[row, column];

                    // The cell needs to be subtracted 
                    // from its neighbors as it was  
                    // counted before 
                    aliveNeighbors -= currentCell ? 1 : 0;

                    // Implementing the Rules of Life 

                    // Cell is lonely and dies 
                    if (currentCell && aliveNeighbors < 2)
                    {
                        nextGenerationBoard[row, column] = false;
                    }

                    // Cell dies due to over population 
                    else if (currentCell == aliveNeighbors > 3)
                    {
                        nextGenerationBoard[row, column] = false;
                    }

                    // A new cell is born 
                    else if (currentCell == false && aliveNeighbors == 3)
                    {
                        nextGenerationBoard[row, column] = true;
                    }
                    // All other cells stay the same
                    else
                    {
                        nextGenerationBoard[row, column] = currentCell;
                    }
                }
            }

            return nextGenerationBoard;
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