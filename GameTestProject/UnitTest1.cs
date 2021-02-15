using System.Threading.Tasks;
using GameOfLife;
using NUnit.Framework;

namespace GameTestProject
{
    public class Tests
    {
        private Game _game;
        private const int rows = 50;
        private const int columns = 50;
        private const double coverage = 0.25;
        private const int maxIterationToPlay = 10000;

        [SetUp]
        public void Setup()
        {
            var board = BoardFactory.Create(rows, columns, coverage);
            _game = new Game(board);
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
            var board = BoardFactory.Create(rows, columns, 1);
            _game = new Game(board);
            _game.Play(maxIterationToPlay);
            Assert.AreEqual(2, _game.Generation);
        }

        [Test]
        public void RunningEmptyGridTest()
        {
            var board = BoardFactory.Create(rows, columns, 0);
            _game = new Game(board);
            _game.Play(maxIterationToPlay);
            Assert.AreEqual(1, _game.Generation);
        }
    }
}