using System;

class GuessingNumber
{
    static void Main(string[] args)
    {
        int targetNumber;
        bool validTarget = false;

        // Player 1 sets the target number
        do
        {
            Console.Write("Player 1, enter a number between 1 and 10 to be guessed: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out targetNumber) && targetNumber >= 1 && targetNumber <= 10)
            {
                validTarget = true;
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter an integer between 1 and 10.");
            }
        } while (!validTarget);

        Console.Clear();
        Console.WriteLine("Player 2, start guessing!");

        int guess;
        bool guessedCorrectly = false;

        // Player 2 guesses the number
        while (!guessedCorrectly)
        {
            Console.Write("Enter your guess (1-10): ");
            string guessInput = Console.ReadLine();

            if (int.TryParse(guessInput, out guess))
            {
                if (guess < 1 || guess > 10)
                {
                    Console.WriteLine("Out of range! Please enter a number between 1 and 10.");
                }
                else if (guess == targetNumber)
                {
                    Console.WriteLine("You have guessed the number! Well done!");
                    guessedCorrectly = true;
                }
                else
                {
                    Console.WriteLine("Wrong guess! Try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter a number.");
            }
        }
    }
}
