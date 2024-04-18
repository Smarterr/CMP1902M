using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Game
    {
        /*
         * The Game class should create three die objects, roll them, sum and report the total of the three dice rolls.
         *
         * EXTRA: For extra requirements (these aren't required though), the dice rolls could be managed so that the
         * rolls could be continous, and the totals and other statistics could be summarised for example.
         */

        public int SumOfDieValues { get; private set; }

        //Methods
        public void StartGame()
        {

            // Create a single instance of Random to share among all dice
            Random random = new Random();

            // Create three instances of the Die class
            Die die1 = new Die(random);
            Die die2 = new Die(random);
            Die die3 = new Die(random);

            // Roll all three dice
            int result1 = die1.Roll();
            int result2 = die2.Roll();
            int result3 = die3.Roll();

            // Calculate the sum of the face values
            SumOfDieValues = result1 + result2 + result3;

            // Output the results
            Console.WriteLine("Results of rolling three dice:");
            Console.WriteLine("Die 1: " + result1);
            Console.WriteLine("Die 2: " + result2);
            Console.WriteLine("Die 3: " + result3);
            Console.WriteLine("Sum of dice values: " + SumOfDieValues);
            Console.ReadLine();
        }
    }
}