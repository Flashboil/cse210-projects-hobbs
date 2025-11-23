using System;
using System.IO.Enumeration;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        string filename = "goals.txt";

        Record record = new Record(filename);

        string response = "";

        while (response != "4")
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goals");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Record Event");
            Console.WriteLine("  4. Quit");

            Console.Write("Select a choice from the menu: ");
            response = Console.ReadLine();

            string name = "";
            string desc = "";
            int points = 0;

            switch (response)
            {
                case "1":
                    Console.WriteLine("Select a goal type:");
                    Console.WriteLine("  1. Simple goal (one time completion)");
                    Console.WriteLine("  2. Fixed Goal (set number of compeltions to finish)");
                    Console.WriteLine("  3. Endless Goal (running total of completions)");

                    string selectResponse = Console.ReadLine();

                    switch (selectResponse)
                    {
                        case "1":
                            Console.WriteLine("What is the name of this goal? ");
                            name = Console.ReadLine();
                            Console.WriteLine("What is a brief description of this goal? ");
                            desc = Console.ReadLine();
                            Console.WriteLine("How many points is this goal worth? ");
                            points = int.Parse(Console.ReadLine());

                            record.AddNewGoal(new SimpleGoal(name, desc, points, false));
                            break;
                        case "2":
                            Console.WriteLine("What is the name of this goal? ");
                            name = Console.ReadLine();
                            Console.WriteLine("What is a brief description of this goal? ");
                            desc = Console.ReadLine();
                            Console.WriteLine("How many points is this goal worth? ");
                            points = int.Parse(Console.ReadLine());
                            Console.WriteLine("How many times to complete this goal? ");
                            int completionGoal = int.Parse(Console.ReadLine());

                            record.AddNewGoal(new FixedGoal(name, desc, points, false, 0, completionGoal));
                            break;
                        case "3":
                            Console.WriteLine("What is the name of this goal? ");
                            name = Console.ReadLine();
                            Console.WriteLine("What is a brief description of this goal? ");
                            desc = Console.ReadLine();
                            Console.WriteLine("How many points is this goal worth? ");
                            points = int.Parse(Console.ReadLine());

                            record.AddNewGoal(new EndlessGoal(name, desc, points, false, 0));
                            break;
                        default:
                            Console.WriteLine("Returning to menu.");
                            break;
                    }
                    break;
                case "2":
                    record.DisplayGoals();
                    Console.WriteLine();
                    record.DisplayPoints();
                    break;
                case "3":
                    record.DisplayGoals();
                    record.DisplayPoints();

                    Console.Write("Select a goal to update: ");
                    int goalSelect = int.Parse(Console.ReadLine());

                    record.UpdateGoal(goalSelect - 1);

                    record.DisplayGoals();
                    record.DisplayPoints();
                    break;
                case "4":
                    record.SaveData(filename);
                    break;
                default:
                    break;
            }
            
        }

    }
}