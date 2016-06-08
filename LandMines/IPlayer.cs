using System.Text;

namespace LandMines
{
    public interface IPlayer
    { 
        int XCoordinate { get; set; }

        int YCoordinate { get; set; } 

        int Lives { get; set; }

        bool Completed { get; set; }

        StringBuilder MoveResponseText { get; set; }

        void MoveRight();
        void MoveLeft();
        void MoveUp();
        void MoveDown();
        bool ValidateMove(IGameBoard board);

      

        void MineHit();
       
    }
}