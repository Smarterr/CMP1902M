using System;

namespace Assignment2
{
    internal class ThreeOrMore
    {
        private Random random;
        private Die[] player1Dice;
        private Die[] player2Dice;
        public int Player1Points { get; private set; }
        public int Player2Points { get; private set; }
        private Statistics statistics; // Add a reference to the Statistics object

        public ThreeOrMore(Random random, Statistics statistics) // Update the constructor to accept Statistics object
        {
            this.random = random;
            this.statistics = statistics; // Initialize the Statistics object
            player1Dice = new Die[5]; // Array to hold the five dice for player 1
            player2Dice = new Die[5]; // Array to hold the five dice for player 2
            for (int i = 0; i < 5; i++)
            {
                player1Dice[i] = new Die(random);
                player2Dice[i] = new Die(random);
            }

            Player1Points = 0;
            Player2Points = 0;
        }

        public void StartGame()
        {
            Console.WriteLine("Rules:");
            Console.WriteLine("- Roll all 5 dice hoping for a 3-of-a-kind or better.");
            Console.WriteLine("- If 2-of-a-kind is rolled, player may choose to rethrow all, or the remaining dice.");
            Console.WriteLine("- 3-of-a-kind: 3 points");
            Console.WriteLine("- 4-of-a-kind: 6 points");
            Console.WriteLine("- 5-of-a-kind: 12 points");
            Console.WriteLine("- First to a total of 20 wins!");
            Console.WriteLine("");
            
            // Ask the user whether they want to play against another player or the computer
            Console.WriteLine("Choose your opponent:");
            Console.WriteLine("1. Another player");
            Console.WriteLine("2. Computer");

            string opponentChoice = Console.ReadLine();

            while (opponentChoice != "1" && opponentChoice != "2")
            {
                Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                opponentChoice = Console.ReadLine();
            }

            bool playAgainstComputer = opponentChoice == "2";

            int currentPlayer = 1; // Player 1 starts
            int turns = 0; // Variable to track the number of turns

            while (Player1Points < 20 && Player2Points < 20)
            {
                turns++; // Increment the number of turns

                Console.WriteLine("");
                Console.WriteLine($"Player 1 Points: {Player1Points}");
                Console.WriteLine($"Player 2 Points: {Player2Points}");
                Console.WriteLine();

                if (playAgainstComputer && currentPlayer == 2)
                {
                    // Computer's turn
                    Console.WriteLine("Computer's turn. Press Enter to roll the dice...");
                    Console.ReadLine();
                    RollDice(player2Dice, true); // Pass true to indicate it's the computer's turn
                }
                else
                {
                    Console.WriteLine($"Player {currentPlayer}'s turn. Press Enter to roll the dice...");
                    Console.ReadLine();
                    if (currentPlayer == 1)
                    {
                        RollDice(player1Dice, false); // Pass false for player's turn
                    }
                    else
                    {
                        RollDice(player2Dice, false); // Pass false for player's turn
                    }
                }

                currentPlayer = currentPlayer == 1 ? 2 : 1; // Switch to the other player
            }

            if (Player1Points >= 20)
            {
                if (playAgainstComputer)
                {
                    Console.WriteLine("Congratulations! You won against the computer!");
                }
                else
                {
                    Console.WriteLine("Player 1 wins!");
                }
            }
            else
            {
                if (playAgainstComputer)
                {
                    Console.WriteLine("The computer wins!");
                    statistics.RecordThreeOrMoreResult(turns, true); // Pass true to indicate the computer wins
                }
                else
                {
                    Console.WriteLine("Player 2 wins!");
                    statistics.RecordThreeOrMoreResult(turns, false); // Pass false to indicate player 2 wins
                }
            }
        }


        private void RollDice(Die[] dice, bool isComputerTurn)
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
                if (isComputerTurn)
                {
                    Player2Points += 12;
                    Console.WriteLine(
                        $"Congratulations! The computer rolled 5-of-a-kind! It earned 12 points. Total points: {Player2Points}");
                }
                else
                {
                    Player1Points += 12;
                    Console.WriteLine(
                        $"Congratulations! You rolled 5-of-a-kind! You earned 12 points. Total points: {Player1Points}");
                }
            }
            else if (counts.Contains(4)) // 4-of-a-kind
            {
                if (isComputerTurn)
                {
                    Player2Points += 6;
                    Console.WriteLine(
                        $"Congratulations! The computer rolled 4-of-a-kind! It earned 6 points. Total points: {Player2Points}");
                }
                else
                {
                    Player1Points += 6;
                    Console.WriteLine(
                        $"Congratulations! You rolled 4-of-a-kind! You earned 6 points. Total points: {Player1Points}");
                }
            }
            else if (counts.Contains(3)) // 3-of-a-kind
            {
                if (isComputerTurn)
                {
                    Player2Points += 3;
                    Console.WriteLine(
                        $"Congratulations! The computer rolled 3-of-a-kind! It earned 3 points. Total points: {Player2Points}");
                }
                else
                {
                    Player1Points += 3;
                    Console.WriteLine(
                        $"Congratulations! You rolled 3-of-a-kind! You earned 3 points. Total points: {Player1Points}");
                }
            }
            else if
                (counts.Contains(2) &&
                 !isComputerTurn) // 2-of-a-kind, only prompt for reroll if it's not the computer's turn
            {
                Console.WriteLine("You rolled 2-of-a-kind. Do you want to reroll the remaining dice? (Y/N)");
                string choice = Console.ReadLine().ToUpper();
                if (choice == "Y")
                {
                    RollRemainingDice(dice, isComputerTurn);
                }
            }
            else // No winning combination or it's the computer's turn
            {
                Console.WriteLine("No winning combination. Try again!");
            }
        }


        private void RollRemainingDice(Die[] dice, bool isComputerTurn)
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
                if (isComputerTurn)
                {
                    Player2Points += 12;
                    Console.WriteLine(
                        $"Congratulations! The computer rolled 5-of-a-kind! It earned 12 points. Total points: {Player2Points}");
                }
                else
                {
                    Player1Points += 12;
                    Console.WriteLine(
                        $"Congratulations! You rolled 5-of-a-kind! You earned 12 points. Total points: {Player1Points}");
                }
            }
            else if (counts.Contains(4)) // 4-of-a-kind
            {
                if (isComputerTurn)
                {
                    Player2Points += 6;
                    Console.WriteLine(
                        $"Congratulations! The computer rolled 4-of-a-kind! It earned 6 points. Total points: {Player2Points}");
                }
                else
                {
                    Player1Points += 6;
                    Console.WriteLine(
                        $"Congratulations! You rolled 4-of-a-kind! You earned 6 points. Total points: {Player1Points}");
                }
            }
            else if (counts.Contains(3)) // 3-of-a-kind
            {
                if (isComputerTurn)
                {
                    Player2Points += 3;
                    Console.WriteLine(
                        $"Congratulations! The computer rolled 3-of-a-kind! It earned 3 points. Total points: {Player2Points}");
                }
                else
                {
                    Player1Points += 3;
                    Console.WriteLine(
                        $"Congratulations! You rolled 3-of-a-kind! You earned 3 points. Total points: {Player1Points}");
                }
            }
        }
    }
}
