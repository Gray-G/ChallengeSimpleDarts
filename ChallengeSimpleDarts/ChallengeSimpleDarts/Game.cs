using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Darts;

namespace ChallengeSimpleDarts
{
    public class Game
    {
        private Player _player1;
        private Player _player2;

        public Game()
        {
        }

        public Game(string player1Name, string player2Name)
        {
            _player1 = new Player();
            _player1.Name = player1Name;

            _player2 = new Player();
            _player2.Name = player2Name;
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