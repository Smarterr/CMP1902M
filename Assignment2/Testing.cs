using System.Diagnostics;

namespace Assignment2
{
    internal class Testing
    {
        /*
         * This class is testing both games and the dice class.
         */

        //Method to test the Die class
        public static void TestDie()
        {
            // Create a Die object
            Die diecheck = new Die(new Random());

            // Tests that the die roll is in between 1 and 6
            int rollResult = diecheck.Roll();
            Debug.Assert(rollResult is >= 1 and <= 6, $"Die roll result ({rollResult}) out of range.");
        }
        
        
        public static void TestSevensOut(Statistics statistics)
        {
            // Create a Game object
            SevensOut gamecheck = new SevensOut(statistics);

            gamecheck.StartGame();

            int sum = gamecheck.SevensOutTotal;

            // Assert that the sum is within the expected range based on the number of dice rolled (3 to 18 for three dice)
            Debug.Assert(sum is >= 2 and <= 12, $"Sum of die values ({sum}) out of range 2 to 12");
        }

        
        // Method to test the ThreeOrMore game
        public static void TestThreeOrMore(Statistics statistics)
        {
            // Create a random object
            Random random = new Random();

            // Create a ThreeOrMore object with both Statistics and Random objects
            ThreeOrMore game = new ThreeOrMore(random, statistics);
            game.StartGame();

            // Accessing player points
            int player1Points = game.Player1Points;
            int player2Points = game.Player2Points;

            // Asserting player points are within valid range
            Debug.Assert(player1Points >= 0 && player1Points <= 20, "Player 1 points out of range.");
            Debug.Assert(player2Points >= 0 && player2Points <= 20, "Player 2 points out of range.");

            // Asserting both players have different points
            Debug.Assert(player1Points != player2Points, "Players cannot have the same points.");

            // Asserting the game correctly recognizes when one player reaches 20 points or more
            if (player1Points >= 20)
            {
                Debug.Assert(player2Points < 20, "Player 1 won with 20 points or more.");
            }
            else if (player2Points >= 20)
            {
                Debug.Assert(player1Points < 20, "Player 2 won with 20 points or more.");
            }
        }
    }
}
