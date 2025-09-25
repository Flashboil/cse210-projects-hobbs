using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, then type 0 when finished.");

        List<int> numbers = new List<int>();

        int highest = 0;

        int number = 0;

        do
        {
            Console.Write("Enter a number: ");
            number = int.Parse(Console.ReadLine());

            if (number != 0)
            {
                numbers.Add(number);

                if (number > highest)
                {
                    highest = number;
                }
            }

        } while (number != 0);

        int sum = numbers.Sum();

        int average = sum / numbers.Count;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {highest}");

    }
}