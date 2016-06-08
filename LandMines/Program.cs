using System;
using System.Linq;

namespace LandMines
{
    class Program
    {
        static void Main(string[] args)
        { 
           
            IGame game = new Game();
             
            IRepository repository = new Repository();
            IGameBoard board = new GameBoard(repository.GetBoardYAxisLength(), repository.GetBoardXAxisLength());
            board.MakePercentageOfSquaresMines(repository.GetPercentageOfSquaresToTurnInotMines());

            IPlayer player = new Player(repository.GetPlayerYCoordinate(), repository.GetPlayerXCoordinate(), repository.GetPlayerLives());
            Console.WriteLine(game.StartupText);
          
            int yAxisLength = repository.GetBoardYAxisLength();
            int xAxisLength = repository.GetBoardXAxisLength();
            while (player.Lives > 0 || player.YCoordinate < yAxisLength  )
            {

                if (player.Lives == 0)
                {
                    player.MoveResponseText.Clear();
                    player.MoveResponseText.Append(repository.GetFailureText());
                    Console.Write(player.MoveResponseText.ToString());
                    Console.ReadLine();
                    Environment.Exit(0);
                }

                var input = Console.ReadKey(true);
                player.MoveResponseText.Clear();
               
                if (player.YCoordinate == yAxisLength -1)
                {
                    player.MoveResponseText.Clear();
                    player.MoveResponseText.Append(repository.GetVictoriousText());
                    Console.Write(player.MoveResponseText.ToString());
                    Console.ReadLine();
                    Environment.Exit(0);
                }


                int beforeMoveY = player.YCoordinate;
                int beforeMoveX = player.XCoordinate;

               

                switch (input.Key.ToString().ToUpper())
                    {
                        case "R":
                            player.MoveRight();
                            break;
                        case "L":
                            player.MoveLeft();
                            break;
                        case "U":
                            player.MoveUp();
                            break;
                        case "D":
                            player.MoveDown();
                            break;
                    //default:

                }

                player.MoveResponseText.Append("Current position Y Axis ");
                player.MoveResponseText.Append(player.YCoordinate.ToString());
                player.MoveResponseText.Append("Current position X Axis ");
                player.MoveResponseText.Append(player.XCoordinate.ToString());

                if (!player.ValidateMove(board))
                {
                    player.MoveResponseText.Clear();
                    player.MoveResponseText.Append(repository.GetInvalidMoveText());
                    player.YCoordinate = beforeMoveY;
                    player.XCoordinate = beforeMoveX;
                }
                else
                {
                    Square currentSquare = (from s in board.Squares where s.XCoordinate == player.XCoordinate && s.YCoordinate == player.YCoordinate select s).FirstOrDefault();
                    if (currentSquare.ContainsLandMine)
                    {
                        player.MineHit();
                        player.MoveResponseText.Append(repository.GetMineHitText());
                        player.MoveResponseText.Append("Lives Left ");
                        player.MoveResponseText.Append(player.Lives.ToString());
                    }
                }

                Console.WriteLine(player.MoveResponseText);
               
            }
            

        }
    }
}
