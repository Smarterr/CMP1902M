namespace Assignment2
{
    internal class ThreeOrMore
    {
        private Random random;
        private Die[] player1Dice;
        private Die[] player2Dice;
        private int player1Points;
        private int player2Points;

        public ThreeOrMore(Random random)
        {
            this.random = random;
            player1Dice = new Die[5]; // Array to hold the five dice for player 1
            player2Dice = new Die[5]; // Array to hold the five dice for player 2
            for (int i = 0; i < 5; i++)
            {
                player1Dice[i] = new Die(random);
                player2Dice[i] = new Die(random);
            }
            player1Points = 0;
            player2Points = 0;
        }

        public void StartGame()
        {
            int currentPlayer = 1; // Player 1 starts

            while (player1Points < 20 && player2Points < 20)
            {
                Console.WriteLine("");
                Console.WriteLine($"Player 1 Points: {player1Points}");
                Console.WriteLine($"Player 2 Points: {player2Points}");
                Console.WriteLine();
                Console.WriteLine($"Player {currentPlayer}'s turn. Press Enter to roll the dice...");
                Console.ReadLine();
                if (currentPlayer == 1)
                {
                    RollDice(player1Dice, ref player1Points);
                }
                else
                {
                    RollDice(player2Dice, ref player2Points);
                }

                currentPlayer = currentPlayer == 1 ? 2 : 1; // Switch to the other player
            }

            if (player1Points >= 20)
            {
                Console.WriteLine("Player 1 wins!");
            }
            else
            {
                Console.WriteLine("Player 2 wins!");
            }
        }

        private void RollDice(Die[] dice, ref int playerPoints)
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
                playerPoints += 12;
                Console.WriteLine($"Congratulations! You rolled 5-of-a-kind! You earned 12 points. Total points: {playerPoints}");
            }
            else if (counts.Contains(4)) // 4-of-a-kind
            {
                playerPoints += 6;
                Console.WriteLine($"Congratulations! You rolled 4-of-a-kind! You earned 6 points. Total points: {playerPoints}");
            }
            else if (counts.Contains(3)) // 3-of-a-kind
            {
                playerPoints += 3;
                Console.WriteLine($"Congratulations! You rolled 3-of-a-kind! You earned 3 points. Total points: {playerPoints}");
            }
            else if (counts.Contains(2)) // 2-of-a-kind
            {
                Console.WriteLine("You rolled 2-of-a-kind. Do you want to reroll the remaining dice? (Y/N)");
                string choice = Console.ReadLine().ToUpper();
                if (choice == "Y")
                {
                    RollRemainingDice(dice, ref playerPoints);
                }
            }
            else
            {
                Console.WriteLine("No winning combination. Try again!");
            }
        }

        private void RollRemainingDice(Die[] dice, ref int playerPoints)
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
                playerPoints += 12;
                Console.WriteLine($"Congratulations! You rolled 5-of-a-kind! You earned 12 points. Total points: {playerPoints}");
            }
            else if (counts.Contains(4)) // 4-of-a-kind
            {
                playerPoints += 6;
                Console.WriteLine($"Congratulations! You rolled 4-of-a-kind! You earned 6 points. Total points: {playerPoints}");
            }
            else if (counts.Contains(3)) // 3-of-a-kind
            {
                playerPoints += 3;
                Console.WriteLine($"Congratulations! You rolled 3-of-a-kind! You earned 3 points. Total points: {playerPoints}");
            }
        }
    }
}