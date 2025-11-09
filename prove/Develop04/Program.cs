using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        BreathingActivity bactivity = new BreathingActivity(
            15,
            "Breathing Activity",
            "In this activity, we will practice controlled breathing. Breathe in through your nose and out through your mouth. Clear your mind and focus on your breathing."
            );

        ReflectionActivity ractivity = new ReflectionActivity(
            15,
            "Reflection Activity",
            "In this acitivty, you will be asked to reflect on a particular prompt. This will help you to think about what you have been doing recently and how you feel about it."
        );

        ListingActivity lactivity = new ListingActivity(
            15,
            "Listing Activity",
            "This activity will help you to reflect on good things in your life by listing as many things as you can in a certain length of time."
        );

        Console.WriteLine("Welcome!");

        bool running = true;
        string response = "";

        while (running)
        {
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflecting Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Quit");

            response = Console.ReadLine();

            switch (response)
            {
                case "1":
                    bactivity.DoActivity();
                    break;
                case "2":
                    ractivity.DoActivity();
                    break;
                case "3":
                    lactivity.DoActivity();
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    break;
            }
        }
    }
}