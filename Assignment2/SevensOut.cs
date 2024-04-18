using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class SevensOut
    {
        public int SevensOutTotal { get; private set; }

        // Method to play the Sevens Out game
        public void StartGame()
        {
            // Create a single instance of Random to share among all dice
            Random random = new Random();

            // Initialize variables for dice results and sum
            int result1, result2, sum;

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
                sum = result1 + result2;

                // Output the results
                Console.WriteLine("Results of rolling two dice:");
                Console.WriteLine("Die 1: " + result1);
                Console.WriteLine("Die 2: " + result2);
                Console.WriteLine("Sum of both is: " + sum);

                // Double the sum if a double is rolled
                if (result1 == result2)
                {
                    sum *= 2;
                    Console.WriteLine("You rolled doubles! Double the sum of these two numbers will be added to your total! (" + sum + ")");
                }

                // Add the sum to the total
                SevensOutTotal += sum;

                Console.WriteLine("Your current total is: " + SevensOutTotal);

                // Check if the sum is 7 to stop the game instantly
                if (sum == 7)
                {
                    continueRolling = false;
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
