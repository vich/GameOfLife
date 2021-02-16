using System;

namespace GameOfLife
{
    public static class GameFactory
    {
        public static Game Create(int rows, int columns, int minGenerationsAlive, double maxCoverage = 1)
        {
            Console.WriteLine($"Start Create Game witch alive at minimum {minGenerationsAlive} generations");
            
            var random = new Random();

            while (true)
            {
                var coverage = random.NextDouble() * maxCoverage;
                var board = BoardFactory.Create(rows, columns, coverage);
                var game = new Game(board);
                game.Play(minGenerationsAlive);

                if (game.Generation >= minGenerationsAlive)
                {
                    return game;
                }
            }
        }
    }
}