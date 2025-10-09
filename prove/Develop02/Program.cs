using System;
using System.IO.Enumeration;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter the name of your Journal file:");
        string filename = Console.ReadLine();

        Journal journal = new Journal();

        journal.LoadFromFile(filename);

        bool running = true;

        while (running)
        {
            Console.WriteLine("Welcome to the Journal program!");
            Console.WriteLine("Please select an action:");
            Console.WriteLine("1-Display all entries");
            Console.WriteLine("2-Display last five entries");
            Console.WriteLine("3-Write new entry");
            Console.WriteLine("4-Quit");

            string response = Console.ReadLine();

            if (response == "1")
            {
                journal.DisplayJournalEntries();
            }
            else if (response == "2")
            {
                foreach (JournalEntry entry in journal._entries.TakeLast(5))
                {
                    entry.DisplayEntry();
                }
            }
            else if (response == "3")
            {
                JournalEntry today = new JournalEntry();
                today.MakeEntry();
                journal._entries.Add(today);
            }
            else if (response == "4")
            {
                journal.SaveToFile(filename);
                running = false;
            }
        }

    }
}