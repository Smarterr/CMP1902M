namespace Assignment2
{
    internal class Statistics
    {
        // Properties to store statistics data
        public int LowestTotal { get; private set; }
        public int HighestTotal { get; private set; }
        public int GamesPlayed { get; private set; }

        // List to store all Sevens Out game results
        private List<int> sevensOutTotals = new List<int>();

        // List to store all Three or More game results
        private List<int> threeOrMoreTotals = new List<int>();

        // File path for saving and loading statistics
        private readonly string filePath = "game_stats.txt";

        public Statistics()
        {
            // Load statistics from file if available
            LoadStatistics();
        }

        // Method to load statistics from a file
        private void LoadStatistics()
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                if (lines.Length >= 6) // Ensure the file contains enough lines
                {
                    LowestTotal = int.Parse(lines[0]);
                    HighestTotal = int.Parse(lines[1]);
                    GamesPlayed = int.Parse(lines[2]);
                }
                else
                {
                    // Handle the case where the file does not contain enough lines
                    // Set default values
                    LowestTotal = int.MaxValue;
                    HighestTotal = int.MinValue;
                    GamesPlayed = 0;
                }
            }
            else
            {
                // Handle the case where the file does not exist
                // Set default values
                LowestTotal = int.MaxValue;
                HighestTotal = int.MinValue;
                GamesPlayed = 0;
            }
        }

        // Method to save statistics to a file
        private void SaveStatistics()
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(LowestTotal);
                writer.WriteLine(HighestTotal);
                writer.WriteLine(GamesPlayed);
            }
        }

        // Method to record a new game result for Sevens Out
        public void RecordSevensOutResult(int total)
        {
            // Update lowest and highest total
            LowestTotal = Math.Min(LowestTotal, total);
            HighestTotal = Math.Max(HighestTotal, total);

            // Increment games played
            GamesPlayed++;

            // Add the total to the list
            sevensOutTotals.Add(total);

            // Save statistics to file
            SaveStatistics();
        }

        // Method to record a new game result for Three or More
        public void RecordThreeOrMoreResult(int total)
        {
            // Update lowest and highest total
            LowestTotal = Math.Min(LowestTotal, total);
            HighestTotal = Math.Max(HighestTotal, total);

            // Increment games played
            GamesPlayed++;

            // Add the total to the list
            threeOrMoreTotals.Add(total);

            // Save statistics to file
            SaveStatistics();
        }

        public bool HasSevensOutResults()
        {
            return sevensOutTotals.Count > 0; // Assuming sevensOutTotals list stores the game results
        }

        public bool HasThreeOrMoreResults()
        {
            return threeOrMoreTotals.Count > 0; // Assuming threeOrMoreTotals list stores the game results
        }

        // Method to print Sevens Out statistics summary
        public void PrintSevensOutSummary()
        {
            Console.WriteLine("Sevens Out Game Statistics:");
            Console.WriteLine($"Lowest total: {LowestTotal}");
            Console.WriteLine($"Highest total: {HighestTotal}");
            Console.WriteLine($"Games played: {GamesPlayed}");
        }

        // Method to print Three or More statistics summary
        public void PrintThreeOrMoreSummary()
        {
            Console.WriteLine("Three or More Game Statistics:");
            Console.WriteLine($"Lowest total: {LowestTotal}");
            Console.WriteLine($"Highest total: {HighestTotal}");
            Console.WriteLine($"Games played: {GamesPlayed}");
        }
    }
}
