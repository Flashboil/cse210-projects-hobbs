using System;

class Program
{
    static void Main(string[] args)
    {
        string response = "";

        while (response != "6")
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goals");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");

            Console.Write("Select a choice from the menu: ");
            response = Console.ReadLine();

            switch (response)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                default:
                    break;
            }
            
        }



    }
}