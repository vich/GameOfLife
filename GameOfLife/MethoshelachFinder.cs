using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameOfLife
{
    public static class MethoshelachFinder
    {
        private const int Rows = 50;
        private const int Columns = 50;
        private const double Coverage = 0.15;
        private const int MaxIterationToPlay = 10000;

        public static Game FindGoodMethoshelach(int chromosomeNum, double mutationProb, double crossoverProb)
        {
            var chromosomes = new List<Game>(chromosomeNum);

            //init first generation 
            Parallel.For(0, chromosomeNum, _ => chromosomes.Add(CreateGameAndRun()));


            //return the best game
            return chromosomes.OrderBy(game => game.Generation).First();
        }

        private static Game CreateGameAndRun()
        {
            while(true)
            {
                var game = GameFactory.Create(Rows, Columns, 10, 0.15);
                game.Play(MaxIterationToPlay);

                if(game.Generation < MaxIterationToPlay) //the board didn't stabilize
                    return game;
            }
        }

        private static double Fitness(Game game)
        {
            return game.Generation + (game.MaxPopulation / game.StartBoard.Population);
        }
    }
}