using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class MovingAverage
    {
        private readonly int _period;

        private IList<double> Data { get; }

        public double Average => Data.Sum() / Data.Count;

        public MovingAverage(int period)
        {
            _period = period;
            Data = new List<double>();
        }

        public void Push(double num)
        {
            Data.Add(num);

            if (Data.Count > _period)
                Data.RemoveAt(0);
        }
    }
}