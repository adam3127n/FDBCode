using System;

namespace LandMines
{
    public class Repository : IRepository
    { 
        public int GetBoardXAxisLength()
        {
            return LandMines.Properties.Settings.Default.GameBoardXAxisLength;
        }
         
        public int GetBoardYAxisLength()
        {
            return LandMines.Properties.Settings.Default.GameBoardYAxisLength;
        }

        public string GetInvalidMoveText()
        {
            return LandMines.Properties.Settings.Default.InvalidMoveText;
        }

        public int GetPercentageOfSquaresToTurnInotMines()
        {
            return LandMines.Properties.Settings.Default.PercentageOfSquaresToTurnInotMines;
        }

        public int GetPlayerLives()
        {
            return LandMines.Properties.Settings.Default.PlayerLives; 
        }

        public string GetPlayerMovesDownInput()
        {
            return LandMines.Properties.Settings.Default.PlayerMovesDownInput;
        }

        public string GetPlayerMovesLeftInput()
        {
            return LandMines.Properties.Settings.Default.PlayerMovesLeftInput;
        }

        public string GetPlayerMovesRightInput()
        {
            return LandMines.Properties.Settings.Default.PlayerMovesRightInput;
        }

        public string GetPlayerMovesUpInput()
        {
            return LandMines.Properties.Settings.Default.PlayerMovesUpInput;
        }

        public int GetPlayerXCoordinate()
        {
            return LandMines.Properties.Settings.Default.PlayerXAxis;
        }

        public int GetPlayerYCoordinate()
        {
            return LandMines.Properties.Settings.Default.PlayerYAxis;
        }

        public string GetStartupText()
        {
            return LandMines.Properties.Settings.Default.StartupText;
        }

        public string GetMineHitText()
        {
            return LandMines.Properties.Settings.Default.MineHitText;
        }

        public string GetVictoriousText()
        {
            return LandMines.Properties.Settings.Default.VictoriousText;
        }

        public string GetFailureText()
        {
            return LandMines.Properties.Settings.Default.FailureText;
        }
        
    }
}