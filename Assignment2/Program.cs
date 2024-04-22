using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Create a game object and allow the user to pick which game they would like to play
             */

            while (true)
            {
                Console.WriteLine("Choose a game:");
                Console.WriteLine("1. Sevens Out");
                Console.WriteLine("2. Three or More");
                Console.WriteLine("3. Exit");

                // Read user input
                string input = Console.ReadLine();

                // Check user choice
                switch (input)
                {
                    case "1":
                        PlaySevensOut();
                        break;
                    case "2":
                        PlayThreeOrMore();
                        break;
                    case "3":
                        Console.WriteLine("Exiting the program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                        break;
                }

                // Add a blank line for clarity
                Console.WriteLine();
            }
        }

        static void PlaySevensOut()
        {
            SevensOut game = new SevensOut();
            game.StartGame();
        }

        static void PlayThreeOrMore()
        {
            Random random = new Random();
            ThreeOrMore game = new ThreeOrMore(random);
            game.StartGame();
        }
    }
}