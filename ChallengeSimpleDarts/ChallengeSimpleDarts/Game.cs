using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Darts;

namespace ChallengeSimpleDarts
{
    public class Game
    {
        public Game()
        {
        }

        public void PlayGame(Dart playerOnesDart, Dart playerTwosDart)
        {
            while (playerOnesDart.Score < 300 && playerTwosDart.Score < 300)
            {
                for (int i = 0; i < 3; i++)
                {
                    playerOnesDart.Throw();
                }
                for (int i = 0; i < 3; i++)
                {
                    playerTwosDart.Throw();
                }
            }

            return;
        }
    }
}