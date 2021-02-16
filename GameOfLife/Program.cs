using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            const int rows = 50;
            const int columns = 50;
            const double coverage = 0.55;
            const int maxIterationToPlay = 10000;

            // var board = BoardFactory.Create(rows, columns, coverage);
            // var game = new Game(board);
            var sw = new Stopwatch();
            sw.Start();

            var game1 = MethoshelachFinder.FindGoodMethoshelach(10, 0.40, 0.7, 0.2, 5000);
            Console.WriteLine($"stopwatch={sw.Elapsed}");
            sw.Restart();

            var game2 = MethoshelachFinder.FindGoodMethoshelach(20, 0.40, 0.7, 0.2, 3000);
            Console.WriteLine($"stopwatch={sw.Elapsed}");
            sw.Restart();

            var game3 = MethoshelachFinder.FindGoodMethoshelach(30, 0.40, 0.7, 0.2, 2000);
            Console.WriteLine($"stopwatch={sw.Elapsed}");
            sw.Restart();

            var game4 = MethoshelachFinder.FindGoodMethoshelach(40, 0.40, 0.7, 0.2, 1000);
            Console.WriteLine($"stopwatch={sw.Elapsed}");
            sw.Restart();

            // var game = GameFactory.Create(rows, columns, 10, 0.1);
            //
            // game.Play(maxIterationToPlay);

            Console.ReadLine();
        }

    }
}
