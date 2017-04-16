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
            Random random = new Random();
            Dart playerOneDartGame = new Dart(random);
            Dart playerTwoDartGame = new Dart(random);
            bool playerOneIsWinner = false;
            bool playerTwoIsWinner = false;

            while (playerOneDartGame.Score < 300 && playerTwoDartGame.Score < 300)
            {
                playerOneDartGame.Throw();
                playerTwoDartGame.Throw();
            }

            if (playerOneDartGame.Score > playerTwoDartGame.Score)
                playerOneIsWinner = true;
            else playerTwoIsWinner = true;

            resultLabel.Text = $"<p>Player 1's Score: {playerOneDartGame.Score}</p>" +
                $"<p>Players 2's Score: {playerTwoDartGame.Score}</p>";

            if (playerOneIsWinner)
                resultLabel.Text += $"<p>Player 1 wins!</p>";
            else resultLabel.Text += $"<p>Player 2 wins!</p>";  
        }
    }
}