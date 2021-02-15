using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            const uint rows = 50;
            const uint columns = 50;
            const double coverage = 1;
            const uint maxIterationToPlay = 10000;

            var game = new Game(rows, columns, coverage, maxIterationToPlay);

            Console.WriteLine($"Generation={game.Board.Generation}, Population={game.Board.Population}");

            Console.ReadLine();
        }

    }
}
