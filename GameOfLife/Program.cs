using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            const uint rows = 50;
            const uint columns = 50;
            const double coverage = 0.55;
            const uint maxIterationToPlay = 10000;

            var game = new Game(rows, columns, coverage);
            game.Play(maxIterationToPlay);
            
            Console.ReadLine();
        }

    }
}
