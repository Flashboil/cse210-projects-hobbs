using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop04 World!");
        
        static void Animation(int length)
        {

            List<string> frames = new List<string>
        {
            "█","▓","░","▓"
        };

            int frameCount = frames.Count;

            for (int i = 0; i < length; i++)
            {
                Console.Write(frames[i % frameCount]);
                Thread.Sleep(500);
                Console.Write("\b \b");
            }
        }

        Animation(15);
    }
}