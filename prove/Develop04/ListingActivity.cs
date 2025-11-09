using System.ComponentModel.DataAnnotations;

public class ListingActivity : Activity
{
    private List<string> _promptsListing;
    public ListingActivity(int duration, string activity, string description, List<string> prompts) : base(duration, activity, description)
    {
        _promptsListing = prompts;
    }

    public ListingActivity(int duration, string activity, string description) : base(duration, activity, description)
    {
        _promptsListing = new List<string>
            {
                "Who are people you appreciate?",
                "What are five things that make you feel calm or happy?",
                "List moments when you felt proud of yourself.",
                "What are challenges you've overcome in the past year?",
                "Name places where you feel most at peace.",
                "List people who have positively influenced your life.",
                "What are things you’re grateful for today?"
            };
    }
    
    public void DoActivity()
    {
         DisplayInfo();

        Console.WriteLine("How long would you like for this activity to last?");
        SetDuration(int.Parse(Console.ReadLine()));

        Animation(5);

        // This is part specific to ListingActivity

        Console.WriteLine(SelectPrompt(_promptsListing) + "\n");

        Console.Write("Get ready...");
        Countdown(5);

        Console.WriteLine();

        DateTime nowTime = DateTime.Now;
        DateTime endTime = nowTime.AddSeconds(_duration);

        while (nowTime < endTime)
        {
            Console.ReadLine();
            nowTime = DateTime.Now;
        }

        Console.WriteLine();

        GoodJob();

        Animation(5);
    }
}