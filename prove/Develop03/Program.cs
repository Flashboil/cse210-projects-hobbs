using System;
using System.IO.Enumeration;

class Program
{
    static void Main(string[] args)
    {
        string filename = "scriptures.txt";

        string input = "";

        Scripture scripture = new Scripture(filename);

        while (input != "quit")
        {
            Console.Clear();
            
            scripture.PrintScripture();

            scripture.RandomizeInterval();

            scripture.RandomBlank();

            Console.WriteLine();
            Console.WriteLine("Press Enter to continue or type 'quit' to finish:");
            input = Console.ReadLine();

        }
    }
}