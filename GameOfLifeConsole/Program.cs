using System;
using System.Collections.Generic;
using System.Diagnostics;
using GameOfLife;

namespace GameOfLifeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();

            //maxMutationRation = 0.001
            // var game1 = FindNumberphile(10, 0.40, 0.7, 0.2, 5000);
            // var game2 = FindNumberphile(20, 0.40, 0.7, 0.2, 3000);
            // var game3 = FindNumberphile(30, 0.40, 0.7, 0.2, 2000);
            // var game4 = FindNumberphile(40, 0.40, 0.7, 0.2, 1000);

            // var game5 = FindNumberphile(10, 0.10, 0.7, 0.2, 1000);
            // //Score = 27
            // var game6 = FindNumberphile(10, 0.20, 0.7, 0.2, 1000);
            // //Score = 49
            // var game7 = FindNumberphile(10, 0.30, 0.7, 0.2, 1000);
            // //Score = 50
            // var game8 = FindNumberphile(10, 0.40, 0.7, 0.2, 1000);
            // //Score = 52
            // var game9 = FindNumberphile(10, 0.50, 0.7, 0.2, 1000);
            // //Score = 59
            // var game10 = FindNumberphile(10, 0.60, 0.7, 0.2, 1000);
            // //Score = 84
            // var game11 = FindNumberphile(10, 0.70, 0.7, 0.2, 1000);
            // //Score = 83
            // var game12 = FindNumberphile(10, 0.80, 0.7, 0.2, 1000);
            // //Score = 82
            // var game13 = FindNumberphile(10, 0.90, 0.7, 0.2, 1000);
            // //Score = 82
            // var game14 = FindNumberphile(10, 1, 0.7, 0.2, 1000);
            // //Score = 100

            // //maxMutationRation = 0.01
            // var game5 = FindNumberphile(10, 0.10, 0.7, 0.2, 1000);
            // //Score = 91
            // var game6 = FindNumberphile(10, 0.20, 0.7, 0.2, 1000);
            // //Score = 115
            // var game7 = FindNumberphile(10, 0.30, 0.7, 0.2, 1000);
            // //Score = 145
            // var game8 = FindNumberphile(10, 0.40, 0.7, 0.2, 1000);
            // //Score = 166
            // var game9 = FindNumberphile(10, 0.50, 0.7, 0.2, 1000);
            // //Score = 186
            // var game10 = FindNumberphile(10, 0.60, 0.7, 0.2, 1000);
            // //Score = 230
            // var game11 = FindNumberphile(10, 0.70, 0.7, 0.2, 1000);
            // //Score = 245
            // var game12 = FindNumberphile(10, 0.80, 0.7, 0.2, 1000);
            // //Score = 270
            // var game13 = FindNumberphile(10, 0.90, 0.7, 0.2, 1000);
            // //Score = 284
            // var game14 = FindNumberphile(10, 1, 0.7, 0.2, 1000);
            // //Score = 327

            // //maxMutationRation = 0.1
            // var game5 = FindNumberphile(10, 0.10, 0.7, 0.2, 1000);
            // //Score = 265
            // var game6 = FindNumberphile(10, 0.20, 0.7, 0.2, 1000);
            // //Score = 484
            // var game7 = FindNumberphile(10, 0.30, 0.7, 0.2, 1000);
            // //Score = 723
            // var game8 = FindNumberphile(10, 0.40, 0.7, 0.2, 1000);
            // //Score = 967
            // var game9 = FindNumberphile(10, 0.50, 0.7, 0.2, 1000);
            // //Score = 1229
            // var game10 = FindNumberphile(10, 0.60, 0.7, 0.2, 1000);
            // //Score = 1372
            // var game11 = FindNumberphile(10, 0.70, 0.7, 0.2, 1000);
            // //Score = 1594
            // var game12 = FindNumberphile(10, 0.80, 0.7, 0.2, 1000);
            // //Score = 1933
            // var game13 = FindNumberphile(10, 0.90, 0.7, 0.2, 1000);
            // //Score = 2604
            // var game14 = FindNumberphile(10, 1, 0.7, 0.2, 1000);
            // //Score = 2359

            // //maxMutationRation = 0.5
            // var game5 = FindNumberphile(10, 0.10, 0.7, 0.2, 1000);
            // //Score = 720
            // var game6 = FindNumberphile(10, 0.20, 0.7, 0.2, 1000);
            // //Score = 1466
            // var game7 = FindNumberphile(10, 0.30, 0.7, 0.2, 1000);
            // //Score = 1923
            // var game8 = FindNumberphile(10, 0.40, 0.7, 0.2, 1000);
            // //Score = 2646
            // var game9 = FindNumberphile(10, 0.50, 0.7, 0.2, 1000);
            // //Score = 3523
            // var game10 = FindNumberphile(10, 0.60, 0.7, 0.2, 1000);
            // //Score = 3813
            // var game11 = FindNumberphile(10, 0.70, 0.7, 0.2, 1000);
            // //Score = 4585
            // var game12 = FindNumberphile(10, 0.80, 0.7, 0.2, 1000);
            // //Score = 5086
            // var game13 = FindNumberphile(10, 0.90, 0.7, 0.2, 1000);
            // //Score = 5837
            // var game14 = FindNumberphile(10, 1, 0.7, 0.2, 1000);
            // //Score = 6281
            //
            // //maxMutationRation = 1
            // var game5 = FindNumberphile(10, 0.10, 0.7, 0.2, 1000);
            // //Score = 443
            // var game6 = FindNumberphile(10, 0.20, 0.7, 0.2, 1000);
            // //Score = 915
            // var game7 = FindNumberphile(10, 0.30, 0.7, 0.2, 1000);
            // //Score = 1249
            // var game8 = FindNumberphile(10, 0.40, 0.7, 0.2, 1000);
            // //Score = 1674
            // var game9 = FindNumberphile(10, 0.50, 0.7, 0.2, 1000);
            // //Score = 2313
            // var game10 = FindNumberphile(10, 0.60, 0.7, 0.2, 1000);
            // //Score = 2583
            // var game11 = FindNumberphile(10, 0.70, 0.7, 0.2, 1000);
            // //Score = 4109
            // var game12 = FindNumberphile(10, 0.80, 0.7, 0.2, 1000);
            // //Score = 3615
            // var game13 = FindNumberphile(10, 0.90, 0.7, 0.2, 1000);
            // //Score = 3971
            // var game14 = FindNumberphile(10, 1, 0.7, 0.2, 1000);
            // //Score = 4357

            // //maxMutationRation = 0.5
            // var game5 = FindNumberphile(20, 0.10, 0.7, 0.2, 1000);
            // //Score = 826                
            // var game6 = FindNumberphile(20, 0.20, 0.7, 0.2, 1000);
            // //Score = 1324               
            // var game7 = FindNumberphile(20, 0.30, 0.7, 0.2, 1000);
            // //Score = 1967               
            // var game8 = FindNumberphile(20, 0.40, 0.7, 0.2, 1000);
            // //Score = 2762               
            // var game9 = FindNumberphile(20, 0.50, 0.7, 0.2, 1000);
            // //Score = 3247
            // var game10 = FindNumberphile(20, 0.60, 0.7, 0.2, 1000);
            // //Score = 3904                
            // var game11 = FindNumberphile(20, 0.70, 0.7, 0.2, 1000);
            // //Score = 4458                
            // var game12 = FindNumberphile(20, 0.80, 0.7, 0.2, 1000);
            // //Score = 5157                
            // var game13 = FindNumberphile(20, 0.90, 0.7, 0.2, 1000);
            // //Score = 5971                
            // var game14 = FindNumberphile(20, 1, 0.7, 0.2, 1000);
            // //Score = 6423

            // //maxMutationRation = 0.5
            // var game5 = FindNumberphile(10, 0.20, 0.1, 0.2, 1000);
            // //Score = 1406                
            // var game6 = FindNumberphile(10, 0.20, 0.2, 0.2, 1000);
            // //Score = 1413               
            // var game7 = FindNumberphile(10, 0.20, 0.3, 0.2, 1000);
            // //Score = 1408               
            // var game8 = FindNumberphile(10, 0.20, 0.4, 0.2, 1000);
            // //Score = 1389               
            // var game9 = FindNumberphile(10, 0.20, 0.5, 0.2, 1000);
            // //Score = 1473
            // var game10 = FindNumberphile(10, 0.20, 0.6, 0.2, 1000);
            // //Score = 1408                
            // var game11 = FindNumberphile(10, 0.20, 0.7, 0.2, 1000);
            // //Score = 1345                
            // var game12 = FindNumberphile(10, 0.20, 0.8, 0.2, 1000);
            // //Score = 1365                
            // var game13 = FindNumberphile(10, 0.20, 0.9, 0.2, 1000);
            // //Score = 1276                
            // var game14 = FindNumberphile(10, 0.20, 1, 0.2, 1000);
            // //Score = 1194

            //var game13 = FindNumberphile(10, 1, 0.5, 0.2, 2000);
            //Fitness=12702, time=00:09:58.0898146
            //var game14 = FindNumberphile(20, 1, 0.5, 0.2, 1000);
            //Score = 6439


            var game13 = FindNumberphile(20, 1, 0.5, 0.2, 2000);

            Console.ReadLine();
        }

        private static (Game, IList<Coords>) FindNumberphile(int chromosomeNum, double mutationProb, double crossoverProb, double keepBestRation = 0.2, int maxIteration = 1000)
        {
            var sw = new Stopwatch();
            sw.Start();

            var numberphileFinder = new NumberphileFinder();
            var game = numberphileFinder.FindNumberphile(chromosomeNum, mutationProb, crossoverProb, keepBestRation, maxIteration);
            sw.Stop();
            var time = sw.Elapsed;
            //Console.WriteLine($"stopwatch={time}");
            Debug.WriteLine($"chromosomeNum={chromosomeNum}, Fitness={numberphileFinder.Fitness(game.Item1)}, time={time}");
            return game;
        }
    }
}
