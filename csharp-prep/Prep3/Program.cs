using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 101);

        int guess = 0;

        int num_guesses = 0;

        Console.WriteLine("Guess a number between 1 and 100.");

        do
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (guess > number)
            {
                Console.WriteLine("Too high!");
            }
            else if (guess < number)
            {
                Console.WriteLine("Too low!");
            }

            num_guesses += 1;

        } while (guess != number);

        Console.WriteLine($"You got it! The number was {number}");
        Console.WriteLine($"It took you {num_guesses} guesses.");

    }
}