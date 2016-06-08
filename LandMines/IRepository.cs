namespace LandMines
{
    public interface IRepository
    {
        int GetBoardXAxisLength();
         
        int GetBoardYAxisLength();

        int GetPercentageOfSquaresToTurnInotMines();

        int GetPlayerLives(); 

        int GetPlayerXCoordinate();

        int GetPlayerYCoordinate();
        string GetPlayerMovesRightInput();
        string GetPlayerMovesLeftInput();
        string GetPlayerMovesUpInput();
        string GetPlayerMovesDownInput();
        string GetInvalidMoveText();
        string GetMineHitText();
        string GetStartupText();
        string GetVictoriousText();
        string GetFailureText();
    }
}