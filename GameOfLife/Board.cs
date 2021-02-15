using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace GameOfLife
{
    public class Board
    {
        #region Prorperties

        public int Rows { get; }
        
        public int Columns { get; }

        public IDictionary<int, bool[]> Grid { get; }
        
        public int Population => Grid.SelectMany(rows => rows.Value).Count(cell => cell);

        public bool this[int i, int j]
        {
            get => Grid[i][j];
            set => Grid[i][j] = value;
        }

        #endregion Prorperties


        #region Constructor

        [JsonConstructor]
        public Board(int rows, int columns, IDictionary<int, bool[]> grid )
        {
            Rows = rows;
            Columns = columns;

            if (grid != null)
                Grid = grid.ToDictionary(entry => entry.Key,
                    entry => entry.Value);
            else
            {
                Grid = new Dictionary<int, bool[]>();
                for (var i = 0; i < rows; i++)
                {
                    Grid.Add(i, new bool[columns]);
                }
            }
        }

        public Board(Board other) : this(other.Rows, other.Columns, other.Grid)
        {
            
        }

        #endregion Constructor


        #region Public Methods

        protected bool Equals(Board other)
        {
            if (Grid.Count != other.Grid.Count)
                return false;

            for (var i = 0; i < Grid.Count; i++)
            {
                if (Grid[i].Length != other.Grid[i].Length)
                    return false;

                for (var j = 0; j < Grid[i].Length; j++)
                {
                    if (Grid[i][j] != other.Grid[i][j])
                        return false;
                }
            }

            return true;
        }
        
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Board) obj);
        }

        public override int GetHashCode()
        {
            return (Grid != null ? Grid.GetHashCode() : 0);
        }

        #endregion Public Methods


        #region Private Grid


        #endregion
    }
}