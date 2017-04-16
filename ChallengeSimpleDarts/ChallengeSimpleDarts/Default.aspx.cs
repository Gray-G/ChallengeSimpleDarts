using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Darts;

namespace ChallengeSimpleDarts
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void okButton_Click(object sender, EventArgs e)
        {
            Random random = new Random(); // random be passed into Dart() constructor to generate dart position
            Dart playerOneDartGame = new Dart(random);
            Dart playerTwoDartGame = new Dart(random);
            bool isPlayerOneWinner = false; // isPlayerOneWinner will hold state of game's winner

            // Loop until a player's score reaches 300
            playGame(playerOneDartGame, playerTwoDartGame);

            // Check winner, store boolean result in isPlayerOneWinner
            isPlayerOneWinner = checkWinner(playerOneDartGame, playerTwoDartGame);

            // Update resultLabel server control with results
            displayResults(playerOneDartGame, playerTwoDartGame, isPlayerOneWinner);
        }

        private void playGame(Dart playerOneDartGame, Dart playerTwoDartGame)
        {
            while (playerOneDartGame.Score < 300 && playerTwoDartGame.Score < 300)
            {
                playerOneDartGame.Throw();
                playerTwoDartGame.Throw();
            }

            return;
        }

        private bool checkWinner(Dart playerOneDartGame, Dart playerTwoDartGame)
        {
            if (playerOneDartGame.Score > playerTwoDartGame.Score)
                return true;
            else return false;
        }

        private void displayResults(Dart playerOneDartGame, Dart playerTwoDartGame, bool isPlayerOneWinner)
        {
            resultLabel.Text = $"<p>Player 1's Score: {playerOneDartGame.Score}</p>" +
            $"<p>Players 2's Score: {playerTwoDartGame.Score}</p>";

            if (isPlayerOneWinner)
                resultLabel.Text += $"<p>Player 1 wins!</p>";
            // else playerTwo wins
            else resultLabel.Text += $"<p>Player 2 wins!</p>";
        }
    }
}
