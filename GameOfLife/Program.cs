using System;
using System.Diagnostics;
using System.Threading.Tasks;
using BenchmarkDotNet.Running;

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
            NumberphileFinder numberphileFinder = new NumberphileFinder();
            var sw = new Stopwatch();
            sw.Start();
            
            var game1 = numberphileFinder.FindNumberphile(10, 0.40, 0.7, 0.2, 5000);
            var time1 = sw.Elapsed;
            Console.WriteLine($"stopwatch={time1}");
            sw.Restart();
            
            var game2 = numberphileFinder.FindNumberphile(20, 0.40, 0.7, 0.2, 3000);
            var time2 = sw.Elapsed;
            Console.WriteLine($"stopwatch={time2}");
            sw.Restart();

            var game3 = numberphileFinder.FindNumberphile(30, 0.40, 0.7, 0.2, 2000);
            var time3 = sw.Elapsed;
            Console.WriteLine($"stopwatch={time3}");
            sw.Restart();

            var game4 = numberphileFinder.FindNumberphile(40, 0.40, 0.7, 0.2, 1000);
            var time4 = sw.Elapsed;
            Console.WriteLine($"stopwatch={time4}");
            sw.Restart();

            // var game = GameFactory.Create(rows, columns, 10, 0.1);
            //
            // game.Play(maxIterationToPlay);

            //var summary = BenchmarkRunner.Run<NumberphileFinder>();

            Console.ReadLine();
        }

    }
}
