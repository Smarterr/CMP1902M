namespace Assignment2
{
    internal class Statistics
    {
        // Properties to store statistics data
        public int LowestTotal { get; private set; }
        public int HighestTotal { get; private set; }
        public int GamesPlayed { get; private set; }
        public int QuickestWinTurns { get; private set; } // New field to store the quickest win turns
        public string QuickestWinner { get; private set; } // New field to store the winner of the quickest win
        public int SlowestWinTurns { get; private set; } // New field to store the slowest win turns
        public string SlowestWinner { get; private set; } // New field to store the winner of the slowest win

        // List to store all Sevens Out game results
        private List<int> sevensOutTotals = new List<int>();
        private List<int> threeOrMoreTurns = new List<int>(); // List to store all Three Or More game turns

        // File path for saving and loading statistics
        private readonly string filePath = "sevens_out_stats.txt";

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

        // Method to record a new game result for Three Or More
        public void RecordThreeOrMoreResult(int turns, bool computerWins)
        {
            // Add the number of turns to the list
            threeOrMoreTurns.Add(turns);

            // Update quickest win
            if (QuickestWinTurns == 0 || turns < QuickestWinTurns)
            {
                QuickestWinTurns = turns;
                QuickestWinner = computerWins ? "Computer" : "Player 1"; // Assuming Player 1 starts the game
            }
            else if (turns == QuickestWinTurns)
            {
                QuickestWinner = "Player 2"; // If multiple games have the same quickest win turns, set the winner accordingly
            }

            // Update slowest win
            if (turns > SlowestWinTurns)
            {
                SlowestWinTurns = turns;
                SlowestWinner = computerWins ? "Computer" : "Player 1"; // Assuming Player 1 starts the game
            }
            else if (turns == SlowestWinTurns)
            {
                SlowestWinner = "Player 2"; // If multiple games have the same slowest win turns, set the winner accordingly
            }
        }

        public bool HasSevensOutResults()
        {
            return sevensOutTotals.Count > 0; // Assuming sevensOutTotals list stores the game results
        }

        public bool HasThreeOrMoreResults()
        {
            return threeOrMoreTurns.Count > 0; // Assuming threeOrMoreTurns list stores the game results
        }

        // Method to print Sevens Out statistics summary
        public void PrintSevensOutSummary()
        {
            Console.WriteLine("Sevens Out Game Statistics:");
            Console.WriteLine($"Lowest total: {LowestTotal}");
            Console.WriteLine($"Highest total: {HighestTotal}");
            Console.WriteLine($"Games played: {GamesPlayed}");
        }

        // Method to print Three Or More statistics summary
        public void PrintThreeOrMoreSummary()
        {
            Console.WriteLine("Three Or More Game Statistics:");
            Console.WriteLine($"Quickest win: {QuickestWinTurns} turns - {QuickestWinner}");
            Console.WriteLine($"Slowest win: {SlowestWinTurns} turns - {SlowestWinner}");
            Console.WriteLine($"Games played: {GamesPlayed}");
        }
    }
}
