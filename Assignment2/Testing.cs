using Assignment2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Testing
    {
        /*
         * This class is testing both games as well as the dice class.
         */

        //Method
 
        public static void TestDie()
        {
            // Create a Die object
            Die diecheck = new Die(new Random());

            // Tests that the die roll is inbetween 1 and 6
            int rollResult = diecheck.Roll();
            Debug.Assert(rollResult >= 1 && rollResult <= 6, $"Die roll result ({rollResult}) out of range.");

        }

        public static void TestSevensOut()
        {
            // Create a Game object
            SevensOut gamecheck = new SevensOut();

            gamecheck.StartGame();

            int sum = gamecheck.SevensOutTotal;

            // Assert that the sum is within the expected range based on the number of dice rolled (3 to 18 for three dice)
            Debug.Assert(sum >= 2 && sum <= 12, $"Sum of die values ({sum}) out of range 2 to 12");
        }
    }
}