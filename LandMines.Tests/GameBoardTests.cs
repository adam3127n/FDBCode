using NUnit.Framework;

namespace LandMines.Tests
{ 
    public class GameBoardTests
    {
        [Test]
        public void RepositoryRetrievesGameBoardXAxisLength() 
        {
            IRepository repository = new Repository();

            int XAxisLength = 0;

            XAxisLength = repository.GetBoardXAxisLength();

            Assert.Greater(XAxisLength, 0);

        }


        [Test]
        public void RepositoryRetrievesGameBoardYAxisLength()
        {
            IRepository repository = new Repository();

            int YAxisLength = 0;

            YAxisLength = repository.GetBoardYAxisLength();

            Assert.Greater(YAxisLength, 0);

        }


        [Test]
        public void GameBoardConstructorSetsUpBoardProperties()
        {
          
            IGameBoard board = new GameBoard(8,8);

            Assert.AreEqual(8, board.XAxisLength);
            Assert.AreEqual(8, board.YAxisLength);

            Assert.GreaterOrEqual(board.Squares.Count,6);
        }


        [Test]
        public void GivenPercentageOfSquaresAreRandomlyTurnedIntoMines()
        {
            IGameBoard board = new GameBoard(8, 8);
            IRepository repository = new Repository();
            int percentage = 0;

            percentage = repository.GetPercentageOfSquaresToTurnInotMines();
            int squaresToTurnIntoMines = percentage * board.Squares.Count / 100;

            board.MakePercentageOfSquaresMines(percentage);

            int iMineCounter = 0;
            foreach (var square in board.Squares)
            {
                if (square.ContainsLandMine)
                {
                    iMineCounter++; 
                }
            }

            Assert.AreEqual(iMineCounter, squaresToTurnIntoMines);
        }
    }
}
