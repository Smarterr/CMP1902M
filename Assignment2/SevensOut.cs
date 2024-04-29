using System;

namespace Assignment2
{
    internal class SevensOut
    {
        private Statistics statistics; // Store a reference to the Statistics object

        public int SevensOutTotal { get; private set; } // Property to store the total score in Sevens Out game
        public int SumOfDieValues { get; private set; } // Property to store the sum of the two dice

        // Constructor to accept a Statistics object
        public SevensOut(Statistics stats)
        {
            statistics = stats; // Initialize the Statistics object
        }

        // Method to play the Sevens Out game
        public void StartGame()
        {
            Console.WriteLine("Rules:");
            Console.WriteLine("- Roll the two dice.");
            Console.WriteLine("- If the sum is 7 stop.");
            Console.WriteLine("- Any other number should be added to a total.");
            Console.WriteLine("- If it is a double - add double the total to your score (3,3 would add 12 to your total)");
            Console.WriteLine("");

            // Create a single instance of Random to share among all dice
            Random random = new Random();

            // Initialize variables for dice results and sum
            int result1, result2;

            // Initialize a flag to control rolling and game termination
            bool continueRolling = true;

            // Loop until the sum is 7 or the user decides to stop
            while (continueRolling)
            {
                // Create two instances of the Die class
                Die die1 = new Die(random);
                Die die2 = new Die(random);

                // Roll the dice
                result1 = die1.Roll();
                result2 = die2.Roll();

                // Calculate the sum
                SumOfDieValues = result1 + result2;

                // Output the results
                Console.WriteLine("Results of rolling two dice:");
                Console.WriteLine("Die 1: " + result1);
                Console.WriteLine("Die 2: " + result2);
                Console.WriteLine("Sum of both is: " + SumOfDieValues);

                // Double the sum if a double is rolled
                if (result1 == result2)
                {
                    SumOfDieValues *= 2;
                    Console.WriteLine("You rolled doubles! Adding double the sum to your total.");
                }

                // Add the sum to the total
                SevensOutTotal += SumOfDieValues;

                Console.WriteLine("Your current total is: " + SevensOutTotal);

                // Check if the sum is 7 to stop the game instantly
                if (SumOfDieValues == 7)
                {
                    continueRolling = false;

                    // Record game result in statistics
                    statistics.RecordSevensOutResult(SevensOutTotal);
                }
                else
                {
                    // Output the prompt to roll again or exit
                    Console.WriteLine("Press Enter to roll again or type 'exit' to stop.");

                    // Wait for the Enter key press
                    string input = Console.ReadLine();

                    // Check if the input is "exit" to stop the game
                    if (input.ToLower() == "exit")
                    {
                        continueRolling = false;
                    }
                }
            }

            // Inform the user that the game has stopped
            Console.WriteLine();
            Console.WriteLine("The sum of the two dice is 7. Game over!");
            Console.WriteLine("Your current total was: " + SevensOutTotal);
        }
    }
}
