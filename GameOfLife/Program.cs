using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            const uint rows = 50;
            const uint columns = 50;
            const double coverage = 0.25;
            const uint maxIterationToPlay = 10000;

            var game = new Game(rows, columns, coverage);

            Console.WriteLine($"Generation={game.Generation}, Population={game.Board.Population}");

            Console.ReadLine();
        }

    }
}
