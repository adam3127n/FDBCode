using System;
using System.Text;

namespace LandMines
{
    public class Player : IPlayer
    { 
        public Player(int xCoordinate, int yCoordinate, int lives)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Lives = lives;
            MoveResponseText = new StringBuilder(); 
            Completed = false;
        }

        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public int Lives { get; set; }
        public bool Completed { get; set; }

        public  StringBuilder MoveResponseText { get; set; }
      
        public void MoveRight()
        {
            XCoordinate++;
        }

        public void MoveLeft()
        {
            XCoordinate--;
        }

        public void MoveUp()
        {
            YCoordinate++;

        }

        public void MoveDown()
        {
            YCoordinate--;
        }

        public bool ValidateMove(IGameBoard board)
        {
            IRepository repository = new Repository();
            if (YCoordinate < 0 || XCoordinate < 0 || XCoordinate >= board.XAxisLength )
            {
                return false;
            }
            else
            {
                if (YCoordinate > board.YAxisLength)
                {
                    MoveResponseText.Clear();
                    MoveResponseText.Append(repository.GetVictoriousText());
                    Completed = true;
                    
                    
                }
                return true;
            }
        }

        public void MineHit()
        {
            Lives--;
         
        }
    }
}