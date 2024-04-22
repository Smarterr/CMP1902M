namespace Assignment2
{
    internal class ThreeOrMore
    {
        private Random random;
        private Die[] dice;
        private int totalPoints;

        public ThreeOrMore(Random random)
        {
            this.random = random;
            dice = new Die[5]; // Array to hold the five dice
            for (int i = 0; i < 5; i++)
            {
                dice[i] = new Die(random);
            }
            totalPoints = 0;
        }

        public void StartGame()
        {
            while (totalPoints < 20)
            {
                Console.WriteLine($"Total Points: {totalPoints}");
                Console.WriteLine("Press Enter to roll the dice...");
                Console.ReadLine();
                RollDice();
            }
            Console.WriteLine("Congratulations! You won the game!");
        }

        private void RollDice()
        {
            // Roll all dice and display their values
            Console.WriteLine("You rolled:");
            for (int i = 0; i < dice.Length; i++)
            {
                dice[i].Roll();
                Console.WriteLine($"Die {i + 1}: {dice[i].DieValue}");
            }

            // Count occurrences of each number
            int[] counts = new int[6];
            foreach (var die in dice)
            {
                counts[die.DieValue - 1]++;
            }

            // Check for winning conditions
            if (counts.Contains(5)) // 5-of-a-kind
            {
                totalPoints += 12;
                Console.WriteLine("Congratulations! You rolled 5-of-a-kind! You earned 12 points.");
            }
            else if (counts.Contains(4)) // 4-of-a-kind
            {
                totalPoints += 6;
                Console.WriteLine("Congratulations! You rolled 4-of-a-kind! You earned 6 points.");
            }
            else if (counts.Contains(3)) // 3-of-a-kind
            {
                totalPoints += 3;
                Console.WriteLine("Congratulations! You rolled 3-of-a-kind! You earned 3 points.");
            }
            else if (counts.Contains(2)) // 2-of-a-kind
            {
                Console.WriteLine("You rolled 2-of-a-kind. Do you want to reroll the remaining dice? (Y/N)");
                string choice = Console.ReadLine().ToUpper();
                if (choice == "Y")
                {
                    RollRemainingDice();
                }
            }
            else
            {
                Console.WriteLine("No winning combination. Try again!");
            }
        }

        private void RollRemainingDice()
        {
            Console.WriteLine("Rerolling remaining dice...");

            // Find the value of the two dice that are part of the 2-of-a-kind set
            int valueOfTwoOfAKind = 0;
            foreach (var die in dice)
            {
                int count = dice.Count(d => d.DieValue == die.DieValue);
                if (count >= 2)
                {
                    valueOfTwoOfAKind = die.DieValue;
                    break;
                }
            }

            // Reroll the three dice that are not part of the 2-of-a-kind set
            for (int i = 0; i < dice.Length; i++)
            {
                if (dice[i].DieValue != valueOfTwoOfAKind)
                {
                    dice[i].Roll();
                }
            }

            // Display the values of all dice after rerolling
            Console.WriteLine("Rerolled dice values:");
            for (int i = 0; i < dice.Length; i++)
            {
                Console.WriteLine($"Die {i + 1}: {dice[i].DieValue}");
            }

            // Count occurrences of each number after rerolling
            int[] counts = new int[6];
            foreach (var die in dice)
            {
                counts[die.DieValue - 1]++;
            }

            // Check for winning conditions after rerolling
            if (counts.Contains(5)) // 5-of-a-kind
            {
                totalPoints += 12;
                Console.WriteLine("Congratulations! You rolled 5-of-a-kind! You earned 12 points.");
            }
            else if (counts.Contains(4)) // 4-of-a-kind
            {
                totalPoints += 6;
                Console.WriteLine("Congratulations! You rolled 4-of-a-kind! You earned 6 points.");
            }
            else if (counts.Contains(3)) // 3-of-a-kind
            {
                totalPoints += 3;
                Console.WriteLine("Congratulations! You rolled 3-of-a-kind! You earned 3 points.");
            }
        }
    }
}