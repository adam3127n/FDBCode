using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LandMines.Tests 
{
    class PlayerTests
    {
        [Test]
        public void RepositoryRetrievesPlayerXCoordinate()
        {
            IRepository repository = new Repository();

            int playerXCoordinate = 0;
            playerXCoordinate = repository.GetPlayerXCoordinate();

            Assert.AreEqual(0, playerXCoordinate);
           
        }

        [Test]
        public void RepositoryRetrievesPlayerYCoordinate()
        {
            IRepository repository = new Repository();

            int playerYCoordinate = 0;
            playerYCoordinate = repository.GetPlayerYCoordinate();

            Assert.AreEqual(0, playerYCoordinate);
        }

        [Test]
        public void RepositoryRetrievesInvalidMoveText()
        {
            IRepository repository = new Repository();
            string InvalidMoveText = repository.GetInvalidMoveText();

            Assert.AreNotEqual(null, InvalidMoveText);
        }


        [Test]
        public void RepositoryRetrievesVictoriousText()
        {
            IRepository repository = new Repository();
            string VictoriousText = repository.GetVictoriousText();

            Assert.AreNotEqual(null, VictoriousText);
        }

        [Test]
        public void RepositoryRetrievesFaliureText()
        {
            IRepository repository = new Repository();
            string FailureText = repository.GetFailureText();

            Assert.AreNotEqual(null, FailureText);
        }

        [Test]
        public void RepositoryRetrievesPlayerLives()
        {
            IRepository repository = new Repository();

            int playerLives = 2;
            playerLives = repository.GetPlayerLives();

            Assert.AreEqual(2, playerLives);
        }



        [Test]
        public void PlayerConstructorSetsUpPlayerProperties()
        {
            IRepository repository = new Repository();
            IPlayer player = new Player(repository.GetPlayerXCoordinate(),repository.GetPlayerYCoordinate(),repository.GetPlayerLives());

            repository.GetPlayerLives();
            Assert.AreEqual(0, player.XCoordinate);
            Assert.AreEqual(0, player.YCoordinate);
            Assert.AreEqual(2, player.Lives);
        }

        [Test]
        public void InputResultsInCorrectPlayerAction()
        {
            IRepository repository = new Repository();
            IPlayer player = new Player(repository.GetPlayerXCoordinate(), repository.GetPlayerYCoordinate(), repository.GetPlayerLives());

            IList<string> PlayerInputs = new List<string>();
                PlayerInputs.Add(repository.GetPlayerMovesRightInput());
                PlayerInputs.Add(repository.GetPlayerMovesLeftInput());
                PlayerInputs.Add(repository.GetPlayerMovesUpInput());
                PlayerInputs.Add(repository.GetPlayerMovesDownInput());

            foreach (var move in PlayerInputs)
            {
                switch (move.ToUpper())
                {
                    case "R":
                       int currentXCoordinate =  player.XCoordinate;
                       player.MoveRight();
                       currentXCoordinate++;
                       Assert.AreEqual(player.XCoordinate, currentXCoordinate);

                        break;
                    case "L":
                         
                        currentXCoordinate = player.XCoordinate;
                        player.MoveLeft();
                        currentXCoordinate--;
                        Assert.AreEqual(player.XCoordinate, currentXCoordinate);
                        break;

                    case "U":

                        int currentYCoordinate = player.YCoordinate;
                        player.MoveUp();
                        currentYCoordinate++;
                        Assert.AreEqual(player.YCoordinate, currentYCoordinate);
                        break;
                       
                    case "D":

                        currentYCoordinate = player.YCoordinate;
                        player.MoveDown();
                        currentYCoordinate--;
                        Assert.AreEqual(player.YCoordinate, currentYCoordinate);
                        break;

                    default:
                        throw new InvalidOperationException(repository.GetInvalidMoveText());
                } 

            }
        }


        [Test]
        public void RepositoryRetrievesMineHitText()
        {
            IRepository repository = new Repository();
           string MineHitText =  repository.GetMineHitText();
            Assert.AreNotEqual(null, MineHitText);
        }

        [Test]
        public void PlayerLosesLifeWhenMineIsHit()
        {
            IPlayer player = new Player(0, 0, 2);
            player.MineHit();
            Assert.AreEqual(1, player.Lives);
        }

        [Test]
        public void PlayersMoveIsValid()
        {
            IRepository repository = new Repository();
            IPlayer player = new Player(0, 0, 2);
            IGameBoard board = new GameBoard(repository.GetBoardYAxisLength(), repository.GetBoardXAxisLength());
            player.MoveDown();
            if (!player.ValidateMove(board) )
            {
                Assert.AreEqual(player.ValidateMove(board), false);
           
            }
           
        }
    }
}
