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
            Dart playerOnesDart = new Dart(random);
            Dart playerTwosDart = new Dart(random);
            Game game = new Game();

            // Loop until a player's score reaches 300
            game.PlayGame(playerOnesDart, playerTwosDart);

            // Update resultLabel server control with results
            displayResults(playerOnesDart, playerTwosDart);
        }

        private void displayResults(Dart playerOnesDart, Dart playerTwosDart)
        {
            resultLabel.Text = $"<p>Player 1's Score: {playerOnesDart.Score}</p>" +
            $"<p>Players 2's Score: {playerTwosDart.Score}</p>";

            resultLabel.Text += $"Winner: " + 
                (playerOnesDart.Score > playerTwosDart.Score ? "Player 1" : "Player 2");
        }
    }
}
