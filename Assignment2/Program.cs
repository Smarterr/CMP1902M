namespace Assignment2
{
    internal class Program
    {
        static void Main()
        {
            Statistics statistics = new Statistics(); // Create an instance of Statistics class to track game statistics
            Random random = new Random(); // Create a Random object for generating random numbers

            while (true) // Main loop for the program, continues until user chooses to exit
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Play Sevens Out");
                Console.WriteLine("2. Play Three or More");
                Console.WriteLine("3. View Statistics");
                Console.WriteLine("4. Exit");

                string input = Console.ReadLine(); // Reads the user input

                switch (input) // Switch statement to handle user input
                {
                    case "1": // Play Sevens Out game
                        PlaySevensOut(statistics); // Call method to start Sevens Out game
                        break;
                    case "2": // Play Three or More game
                        PlayThreeOrMore(statistics, random); // Call method to start Three or More game
                        break;
                    case "3": // View game statistics
                        ViewStatistics(statistics); // Call method to view statistics
                        break;
                    case "4": // Exit the program
                        Console.WriteLine("Exiting the program...");
                        return; // Exit Main method
                    default: // Handle invalid input
                        Console.WriteLine("Invalid choice. Please enter 1, 2, 3, or 4.");
                        break;
                }

                Console.WriteLine(); // Print an empty line for better readability
            }
        }

        static void PlaySevensOut(Statistics statistics)
        {
            SevensOut game = new SevensOut(statistics); // Pass the Statistics object to SevensOut game
            game.StartGame(); // Start Sevens Out game
        }

        static void PlayThreeOrMore(Statistics statistics, Random random)
        {
            ThreeOrMore game = new ThreeOrMore(random, statistics); // Pass Random object and Statistics object to ThreeOrMore game
            game.StartGame(); // Start Three Or More game
        }

        static void ViewStatistics(Statistics statistics)
        {
            while (true) // Loop to view statistics until user chooses to exit
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. View Sevens Out Results");
                Console.WriteLine("2. View Three or More Results");
                Console.WriteLine("3. Exit");

                string input = Console.ReadLine(); // Read user input

                switch (input) // Switch statement to handle user input
                {
                    case "1": // View Sevens Out results
                        if (statistics.HasSevensOutResults()) // Check if there are Sevens Out results available
                        {
                            statistics.PrintSevensOutSummary(); // Print Sevens Out game statistics summary
                        }
                        else
                        {
                            Console.WriteLine("No Sevens Out results available | You haven't played any games!");
                        }
                        break;
                    case "2": // View Three or More results
                        if (statistics.HasThreeOrMoreResults()) // Check if there are Three or More results available
                        {
                            statistics.PrintThreeOrMoreSummary(); // Print Three Or More game statistics summary
                        }
                        else
                        {
                            Console.WriteLine("No Three or More results available | You haven't played any games!");
                        }
                        break;
                    case "3": // Exit from statistics view
                        Console.WriteLine("Exiting...");
                        return; // Exit ViewStatistics method
                    default: // Handle invalid input
                        Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                        break;
                }

                Console.WriteLine(); // Print an empty line for better readability
            }
        }
    }
}
