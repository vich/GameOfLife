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
            //Arrange

            //Act
            var fileName =  await _game.Save();
            var loadedGame = await Game.Load(fileName);

            //Assert
            Assert.AreEqual(_game, loadedGame);
        }

        [Test]
        public void RunningFullGridTest()
        {
            //Arrange
            var board = BoardFactory.Create(rows, columns, 1);
            _game = new Game(board);

            //Act
            _game.Play(maxIterationToPlay);

            //Assert
            Assert.AreEqual(2, _game.Generation);
        }

        [Test]
        public void RunningEmptyGridTest()
        {
            //Arrange
            var board = BoardFactory.Create(rows, columns, 0);
            _game = new Game(board);

            //Act
            _game.Play(maxIterationToPlay);

            //Assert
            Assert.AreEqual(1, _game.Generation);
        }


        [Test]
        public void CrossoverTest()
        {
            //Arrange
            var boardA = BoardFactory.Create(rows, columns, 0.4);
            var boardB = BoardFactory.Create(rows, columns, 0.4);

            //Act
            var crossover = BoardFactory.Crossover(boardA, boardB, 1);

            //Assert
            Assert.AreEqual(boardA.Grid.Count, crossover.Grid.Count);
            Assert.AreEqual(boardA.Grid[0].Length, crossover.Grid[0].Length);
        }

        [Test]
        public void MutationTest()
        {
            //Arrange
            var boardA = BoardFactory.Create(rows, columns, 0.4);
            var maxMutationRation = 0.1;

            //Act
            var crossover = BoardFactory.Mutation(boardA, 1, maxMutationRation);

            //Assert
            var changes = CountChanges(boardA, crossover);
            var maxChanges = boardA.Rows * boardA.Columns * maxMutationRation;
            Assert.LessOrEqual(changes, maxChanges);
        }

        #region Private Methods

        private int CountChanges(Board boardA, Board boardB)
        {
            if (boardA.Columns != boardB.Columns || boardA.Rows != boardB.Rows)
                throw new System.Exception();

            var result = 0;
            for (var i = 0; i < boardA.Rows; i++)
            {
                for (var j = 0; j < boardA.Columns; j++)
                {
                    if (boardA.Grid[i][j] != boardB.Grid[i][j])
                        result++;
                }
            }

            return result;
        }

        #endregion Private Methods
    }
}