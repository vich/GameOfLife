using System.Linq;

namespace GameOfLife
{
    public class Board
    {
        public uint Rows { get; set; }
        public uint Columns { get; set; }

        #region Prorperties

        public bool[][] Grid { get; set; }
        
        public int Population => Grid.SelectMany(rows => rows).Count(cell => cell);

        public bool this[int i, int j]
        {
            get => Grid[i][j];
            set => Grid[i][j] = value;
        }

        #endregion Prorperties


        #region Constructor

        public Board(uint rows, uint columns, bool[][] grid )
        {
            Rows = rows;
            Columns = columns;

            if (grid != null)
                Grid = (bool[][]) grid.Clone();
            else
            {
                Grid = new bool[rows][];
                for (var i = 0; i < rows; i++)
                {
                    Grid[i] = new bool[columns];
                }
            }
        }

        #endregion Constructor


        #region Public Methods
        
        protected bool Equals(Board other)
        {
            if (Grid.Length != other.Grid.Length)
                return false;

            for (var i = 0; i < Grid.Length; i++)
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