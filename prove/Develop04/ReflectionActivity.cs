public class ReflectionActivity : Activity
{
    private List<string> _promptsReflection1;
    private List<string> _promptsReflection2;

    public ReflectionActivity(int duration, string activity, string description, List<string> prompts1, List<string> prompts2) : base(duration, activity, description)
    {
        _promptsReflection1 = prompts1;
        _promptsReflection2 = prompts2;
    }

    public ReflectionActivity(int duration, string activity, string description) : base(duration, activity, description)
    {
        _promptsReflection1 = new List<string>
            {
                "Think of a time when you did something really difficult.",
                "Recall a moment when you helped someone in need.",
                "Describe a situation where you learned from failure.",
                "Remember a time you stepped outside your comfort zone.",
                "Think of a goal you achieved and how it made you feel.",
                "Reflect on a moment that changed the way you see the world."
            };
        _promptsReflection2 = new List<string>
            {
                "Why was this experience meaningful to you?",
                "What did you learn about yourself from this situation?",
                "How has this experience influenced your decisions since then?",
                "What emotions did you feel during and after the experience?",
                "If you could relive this moment, would you do anything differently?",
                "How can you apply what you learned here to future challenges?",
                "What strengths did you rely on to get through this experience?",
                "How did other people play a role in what happened?",
                "What surprised you most about the outcome?",
                "How might this experience shape the way you handle similar situations in the future?"
            };
    }
    
    public void DoActivity()
    {
        DisplayInfo();

        Console.WriteLine("How long would you like for this activity to last?");
        SetDuration(int.Parse(Console.ReadLine()));

        Animation(5);

        // This is part specific to ReflectionActivity

        Console.WriteLine(SelectPrompt(_promptsReflection1));

        Console.WriteLine();

        Console.WriteLine("When you are ready, press enter to continue.");
        Console.Read();


        for (int i = 0; i < _duration / 5; i++)
        {
            Console.WriteLine(SelectPrompt(_promptsReflection2));
            Animation(5);
        }

        Console.WriteLine();

        GoodJob();

        Animation(5);
    }
}