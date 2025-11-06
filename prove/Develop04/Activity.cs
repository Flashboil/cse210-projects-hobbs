public class Activity
{
    private int _duration;
    private string _activityName;
    private string _activityDescription;

    Activity(int duration, string activity, string description)
    {
        _duration = duration;
        _activityName = activity;
        _activityDescription = description;
    }

    public void SetDuration(int duration)
    {
        _duration = duration;
    }

    public int GetDuration()
    {
        return _duration;
    }

    public void Countdown(int length)
    {
        int count = length;
        while (count > 0)
        {
            Console.Write(count);
            count -= 1;
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }

    }

    public void Animation(int length)
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

    public void GoodJob()
    {
        Console.WriteLine("Great job!");
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Welcome to the {_activityName}!");
        Console.WriteLine();
        Console.WriteLine(_activityDescription);
    }
    
    public string SelectPrompt(List<string> prompts)
    {
        var random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];

        return prompt;  
    }
}