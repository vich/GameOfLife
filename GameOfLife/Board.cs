using System.Linq;

namespace GameOfLife
{
    public class Board
    {
        #region Prorperties
        
        public bool[,] Grid { get; }
        
        public int Population => Grid.Cast<bool>().Count(cell => cell);

        public bool this[int i, int j]
        {
            get => Grid[i, j];
            set => Grid[i, j] = value;
        }

        #endregion Prorperties


        #region Constructor

        public Board(uint rows, uint columns, bool[,] grid )
        {
            Grid = grid ?? new bool[rows, columns];
        }

        #endregion Constructor


        #region Public Methods

        protected bool Equals(Board other)
        {
            return Grid.Rank == other.Grid.Rank &&
                   Enumerable.Range(0, Grid.Rank).All(dimension => Grid.GetLength(dimension) == other.Grid.GetLength(dimension)) &&
                   Grid.Cast<bool>().SequenceEqual(other.Grid.Cast<bool>());
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