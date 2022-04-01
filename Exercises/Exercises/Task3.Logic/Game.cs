using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.Logic
{
    public class Game
    {
        private int GamePlayed { get; set; }
        protected bool IsActiv { get; set; }


        public Game()
        {
            GamePlayed = 0;
            IsActiv = false;
        }

        protected void IncreaseGamePlayed()
        {
            GamePlayed += 1;
        }

        protected int GetGamesPlayed()
        {
            return GamePlayed;
        }

    }
}
