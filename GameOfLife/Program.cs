using System;

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

            var game = GameFactory.Create(rows, columns, 20);

            game.Play(maxIterationToPlay);
            
            Console.ReadLine();
        }

    }
}
