using System;

namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Statistics statistics = new Statistics(); // Create an instance of Statistics class

            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Play Sevens Out");
                Console.WriteLine("2. Play Three or More");
                Console.WriteLine("3. View Statistics");
                Console.WriteLine("4. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        PlaySevensOut(statistics);
                        break;
                    case "2":
                        PlayThreeOrMore(statistics);
                        break;
                    case "3":
                        ViewStatistics(statistics);
                        break;
                    case "4":
                        Console.WriteLine("Exiting the program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter 1, 2, 3, or 4.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void PlaySevensOut(Statistics statistics)
        {
            SevensOut game = new SevensOut(statistics); // Pass the Statistics object
            game.StartGame();
        }

        static void PlayThreeOrMore(Statistics statistics)
        {
            Random random = new Random();
            ThreeOrMore game = new ThreeOrMore(random);
            game.StartGame();
        }

        static void ViewStatistics(Statistics statistics)
        {
            if (statistics.HasGameResults())
            {
                statistics.PrintSummary();
            }
            else
            {
                Console.WriteLine("No game results available. Please play a game first.");
            }
        }
    }
}
