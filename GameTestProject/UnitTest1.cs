using System.Threading.Tasks;
using GameOfLife;
using NUnit.Framework;

namespace GameTestProject
{
    public class Tests
    {
        private Game _game;
        private const uint rows = 50;
        private const uint columns = 50;
        private const double coverage = 0.25;
        private const uint maxIterationToPlay = 10000;

        [SetUp]
        public void Setup()
        {
            _game = new Game(rows, columns, coverage);
        }

        [Test]
        public async Task SaveAndLoadTest()
        {
            var fileName = await _game.Save();
            var loadedGame = Game.Load(fileName);
            Assert.Pass();
        }
    }
}