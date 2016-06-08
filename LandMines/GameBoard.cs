using System;
using System.Collections.Generic;
using System.Linq;

namespace LandMines
{
    public class GameBoard : IGameBoard
    { 

        public GameBoard(int xAxisLength, int yAxisLength)
        {
            XAxisLength = xAxisLength; 

            YAxisLength = yAxisLength;

            Squares = new List<Square>();

            for (int x = 0; x < XAxisLength; x++)
            {
                Square square = new Square();
                square.XCoordinate = x;

                for (int y = 0; y < YAxisLength; y++)
                {
                    square.YCoordinate = y;
                    Squares.Add(square);

                    square = new Square();
                    square.XCoordinate = x;
                }
            }

        }

        public int XAxisLength { get; set; }
        public int YAxisLength { get; set; }

        public IList<Square> Squares { get; set; }

        public void MakePercentageOfSquaresMines(int Percentage)
        {
            int squaresToTurnIntoMines = Percentage * Squares.Count / 100;
            Random random = new Random();
            List<Square> squaresWithMines = new List<Square>();
            squaresWithMines = Squares.OrderBy(x => random.Next()).Take(squaresToTurnIntoMines).ToList();

            foreach (var square in squaresWithMines)
            {
                square.ContainsLandMine = true;
            }
        }
    }
}