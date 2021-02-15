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
            var fileName =  await _game.Save();
            var loadedGame = await Game.Load(fileName);
            Assert.AreEqual(_game, loadedGame);
        }

        [Test]
        public void RunningFullGridTest()
        {
            _game = new Game(rows, columns, 1);
            _game.Play(maxIterationToPlay);
            Assert.AreEqual(2, _game.Generation);
        }

        [Test]
        public void RunningEmptyGridTest()
        {
            _game = new Game(rows, columns, 0);
            _game.Play(maxIterationToPlay);
            Assert.AreEqual(1, _game.Generation);
        }
    }
}