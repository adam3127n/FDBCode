using System;

namespace LandMines
{
    public class Game : IGame
    {
         
        public Game() 
        {
            IRepository repository = new Repository();
            StartupText = repository.GetStartupText();
        }
        public string StartupText { get; set; }

      
    }
}