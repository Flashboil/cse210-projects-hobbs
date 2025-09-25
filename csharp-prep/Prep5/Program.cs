using System;

class Program
{
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.Write("What is your name? ");
        string userName = Console.ReadLine();

        return userName;
    }

    static int PromptUserNumber()
    {
        Console.Write("What is your favorite number? ");
        int userNumber = int.Parse(Console.ReadLine());

        return userNumber;
    }

    static void PromptUserBirthYear(out int birthYear)
    {
        Console.Write("What is your birth year? ");
        birthYear = int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int number)
    {
        int squared = number * number;

        return squared;
    }

    static void DisplayResult(string userName, int userNumber, int birthYear)
    {
        Console.WriteLine($"{userName}, the square of your number is {SquareNumber(userNumber)}.");
        Console.WriteLine($"{userName}, you will turn {2025 - birthYear} this year.");
    }

    static void Main(string[] args)
    {
        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int birthYear = 0;
        PromptUserBirthYear(out birthYear);
        DisplayResult(userName, userNumber, birthYear);

    }
}