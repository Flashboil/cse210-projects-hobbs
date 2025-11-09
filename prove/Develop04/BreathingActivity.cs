public class BreathingActivity : Activity
{
    public BreathingActivity(int duration, string activity, string description) : base(duration, activity, description)
    {

    }
    
    public void DoActivity()
    {
        DisplayInfo();

        Console.WriteLine("How long would you like for this activity to last?");
        SetDuration(int.Parse(Console.ReadLine()));

        Animation(5);

        // This is part specific to BreathingActivity

        bool breathe = true;

        for (int i = 0; i < _duration / 5; i++)
        {
            if (breathe)
            {
                Console.Write("Breathe in... ");
                Countdown(5);
                Console.WriteLine();
            }
            else
            {
                Console.Write("Breathe out... ");
                Countdown(5);
                Console.WriteLine();
            }
            breathe = !breathe;
        }

        Console.WriteLine();

        GoodJob();

        Animation(5);
    }
}