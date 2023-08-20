using System;
   namespace RockPaperScissorsGame {
    class Program
    {
        static void Main(string[] args)
        {
            int userWins = 0;
            int computerWins = 0;
            int roundsToWin = 2;

            Console.WriteLine("Welcome to the Rock-Paper-Scissors game!");

            // Prompt user for their name and validate it
            string userName;
            do
            {
                Console.Write("Enter your name: ");
                userName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userName))
                {
                    Console.WriteLine("Name cannot be empty. Please enter your name.");
                }
            } while (string.IsNullOrWhiteSpace(userName));

            Console.WriteLine($"Hello, {userName}!");

            do
            {
                Console.WriteLine("\nSelect your move:\n1->ROCK\n2->PAPER\n3->SCISSORS");
                string[] choices = { "ROCK", "PAPER", "SCISSORS" };
                Random random = new Random();
                int computerChoice = random.Next(0, 3);

                Console.WriteLine("Enter your choice:");
                string userChoice = Console.ReadLine().ToUpper();

                Console.WriteLine($"Computer: {choices[computerChoice]}");

                int result = DetermineWinner(userChoice, choices[computerChoice]);

                if (result == 1)
                {
                    Console.WriteLine($"Congratulations, {userName}! You win this round!");
                    userWins++;
                }

                if (result == -1)
                {
                    Console.WriteLine($"Sorry, {userName}. Computer wins this round!");
                    computerWins++;
                }

                if (result == 0)
                {
                    Console.WriteLine("It's a tie!");
                }

                Console.WriteLine($"Score: {userName} {userWins} - {computerWins} Computer");

                if (userWins >= roundsToWin || computerWins >= roundsToWin)
                {
                    Console.WriteLine("Do you want to play again? (YES/NO):");
                }
                else
                {
                    Console.WriteLine("Next round...");
                }

            } while ((userWins < roundsToWin && computerWins < roundsToWin) ||
                     Console.ReadLine().ToUpper() == "YES");

            Console.WriteLine("\nGame over!");
            if (userWins > computerWins)
            {
                Console.WriteLine($"Congratulations, {userName}! You win the game!");
            }
            else if (computerWins > userWins)
            {
                Console.WriteLine($"Sorry, {userName}. Computer wins the game.");
            }
            else
            {
                Console.WriteLine("It's a tie!");
            }
        }

        static int DetermineWinner(string user, string computer)
        {
            if (user == computer)
            {
                return 0; // It's a tie
            }
            if ((user == "ROCK" && computer == "SCISSORS") ||
                (user == "PAPER" && computer == "ROCK") ||
                (user == "SCISSORS" && computer == "PAPER"))
            {
                return 1; // User wins
            }
            return -1; // Computer wins
        }
    }
}
 
