using System.Collections.Generic;

namespace LandMines
{
    public interface IGameBoard
    { 
        IList<Square> Squares { get; set; }
        int XAxisLength { get; set; } 
        int YAxisLength { get; set; }

        void MakePercentageOfSquaresMines(int Percentage);
    }
}