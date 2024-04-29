namespace Assignment2
{
    internal class Program
    {
        static void Main()
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
            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. View Sevens Out Results");
                Console.WriteLine("2. View Three or More Results");
                Console.WriteLine("3. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        if (statistics.HasSevensOutResults())
                        {
                            statistics.PrintSevensOutSummary();
                        }
                        else
                        {
                            Console.WriteLine("No Sevens Out results available | You haven't played any games!");
                        }

                        break;
                    case "2":
                        if (statistics.HasThreeOrMoreResults())
                        {
                            statistics.PrintThreeOrMoreSummary();
                        }
                        else
                        {
                            Console.WriteLine("No Three or More results available | You haven't played any games!");
                        }
                        
                        break;
                    case "3":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
