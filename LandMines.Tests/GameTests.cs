using NUnit.Framework;

namespace LandMines.Tests
{
    class GameTests 
    {
        [Test]
        public void GameConstructorSetsUpBoardProperties()
        {
            IGame game = new Game(); 
            IRepository repository = new Repository();
            Assert.AreEqual(game.StartupText, repository.GetStartupText());
      
        }
    }
}
