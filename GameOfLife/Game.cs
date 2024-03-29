﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GameOfLife
{
    public class Game
    {
        #region Members
        
        private static DateTime _startTime = DateTime.MinValue;

        #endregion Members


        #region Prorperties

        public bool IsNumberphile { get; private set; }

        public Board Board { get; set; }
       
        public Board StartBoard { get; }
        
        public int Generation { get; private set; }

        [JsonIgnore]
        public IList<Board> Steps { get; }

        public int MaxPopulation { get; private set; }

        #endregion Prorperties


        #region Constructor

        public Game(Board board)
        {
            Board = board;
            StartBoard = new Board(board);
            Steps = new List<Board>{StartBoard};

            MaxPopulation = Board.Population;
            Generation = 1;

            if (_startTime == DateTime.MinValue)
                _startTime = DateTime.Now;
        }

        [JsonConstructor]
        public Game(Board board, Board startBoard, int generation, int maxPopulation)
        {
            Board = board;
            StartBoard = startBoard;
            Steps = new List<Board>{ StartBoard};

            MaxPopulation = maxPopulation;
            Generation = generation;

            if (_startTime == DateTime.MinValue)
                _startTime = DateTime.Now;
        }

        #endregion Constructor


        #region Public Methods

        public void Restart()
        {
            Generation = 1;
            Steps.Clear();
            Steps.Add(StartBoard);
            Board = new Board(StartBoard);
            MaxPopulation = Board.Population;
        }

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

        public string Save(string prefix = "Board")
        {
            var fileName = $"{prefix}__{DateTime.Now.Ticks}.txt";
             
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            var json = JsonSerializer.Serialize(this, options);
            File.WriteAllText(fileName, json);

            return fileName;
        }

        public static Game Load(string path)
        {
            var jsonString = File.ReadAllText(path);
            var result = JsonSerializer.Deserialize<Game>(jsonString);

            return result;
        }

        public void Play(int maxIterations = 1)
        {
            for (var i = 0; i < maxIterations; i++)
            {
                var nextGenerationBoard = CalculateNextGeneration(Board);
                var repeatIndex = Steps.IndexOf(nextGenerationBoard);
                if (repeatIndex != -1)
                {
                    IsNumberphile = true;
                    break;
                } 

                Generation++;
                Board = nextGenerationBoard;
                MaxPopulation = Math.Max(MaxPopulation, Board.Population);
                Steps.Add(Board);
            }
        }

        #endregion Public Methods


        #region Private Methods


        private static Board CalculateNextGeneration(Board board)
        {
            var rows = board.Grid.Count;
            var columns = board.Grid[0].Length;
            var nextGenerationBoard = BoardFactory.Create(rows, columns, 0);

            // Loop through every cell 
            for (var row = 1; row < rows - 1; row++)
            {
                for (var column = 1; column < columns - 1; column++)
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

        #endregion
    }
}