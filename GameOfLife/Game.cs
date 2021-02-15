using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Game
    {
        public uint Rows { get; }
        public uint Columns { get; }
        public double Coverage { get; }

        #region Members

        private static int _gameNumber;

        private static DateTime _startTime = DateTime.MinValue;

        #endregion Members


        #region Prorperties

        //[JsonConverter(typeof(BoardConverter))]
        public Board Board { get; set; }
       
        public Board StartBoard { get; }
        
        public int Generation { get; private set; }

        #endregion Prorperties


        #region Constructor

        [JsonConstructor]
        public Game(uint rows, uint columns, double coverage)
        {
            Rows = rows;
            Columns = columns;
            Coverage = coverage;
            var grid = GenerateRandomBoard(Rows, Columns, coverage);
            Board = new Board(Rows, Columns, grid);
            StartBoard = new Board(Board);

            Generation = 1;
            _gameNumber++;
            if (_startTime == DateTime.MinValue)
                _startTime = DateTime.Now;
        }

        #endregion Constructor


        #region Public Methods

        protected bool Equals(Game other)
        {
            return StartBoard.Equals(other.Board) && Equals(Board, other.Board) && Generation == other.Generation;
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
            var fileName = $"{nameof(Board)}__{_startTime.Day}_{_startTime.Month}__{_startTime.Hour}_{_startTime.Minute}__{_gameNumber}.txt";

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            await using var createStream = File.Create(fileName); 
            await JsonSerializer.SerializeAsync(createStream, this, options);

            return fileName;
        }

        public static async Task<Game> Load(string path)
        {
            await using FileStream openStream = File.OpenRead(path);
            var result = await JsonSerializer.DeserializeAsync<Game>(openStream);

            return result;
        }

        public void Play(uint maxIterations = 1)
        {
            for (var i = 0; i < maxIterations; i++)
            {
                Console.WriteLine($"Generation={Generation}, Population={Board.Population}");
                var nextGenerationBoard = CalculateNextGeneration(Board);

                var equals = Board.Equals(nextGenerationBoard);
                if (equals)
                    break;

                Generation++;
                Board = nextGenerationBoard;
            }
        }


        #endregion Public Methods


        #region Private Methods


        private Board CalculateNextGeneration(Board board)
        {
            var nextGenerationBoard = new Board(Rows, Columns, null); 

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

        private static IDictionary<int, bool[]> GenerateRandomBoard(uint rows, uint columns, double coverage)
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
                result[(int) (index / rows)][index % rows] = true;
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