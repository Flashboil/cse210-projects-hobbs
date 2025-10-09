public class JournalEntry
{
    public string _datetime;
    public int _dayRating;
    public string _promptToday;
    public string _entryContent;

    public void GetPrompt()
    {
        string[] promptList = new string[]
        {
            "What did you learn about yourself today?",
            "What emotion guided most of your decisions today?",
            "When did you feel most at peace today?",
            "What moment today deserves more appreciation than it got?",
            "How did you respond to something difficult today?",
            "What habits are helping you move forward right now?",
            "What are you avoiding that needs your attention?",
            "How did someone else’s actions affect your mood today?",
            "What did you notice about your thoughts or reactions today?",
            "What do you wish you had done differently today?",
            "How did you make use of your time today?",
            "What’s something you understand better now than you did yesterday?",
            "What part of today felt most meaningful?",
            "How did you take responsibility for your choices today?",
            "What do you want to carry with you into tomorrow?",
            "How did you show patience or compassion today?",
            "What are you grateful to have experienced recently?",
            "How did today change your perspective, even in a small way?"
        };

        Random rnd = new Random();

        int index = rnd.Next(promptList.Length);

        _promptToday = promptList[index];
    }

    public void DisplayEntry()
    {
        Console.WriteLine(_datetime);
        Console.WriteLine($"Rating: {_dayRating}");
        Console.WriteLine(_promptToday);
        Console.WriteLine(_entryContent);
        Console.WriteLine("---");
    }

    public void MakeEntry()
    {
        _datetime = Convert.ToString(DateTime.Now);

        Console.WriteLine(_datetime);

        Console.WriteLine("How would you rate today? (1-10)");
        _dayRating = int.Parse(Console.ReadLine());

        GetPrompt();
        Console.WriteLine(_promptToday);

        _entryContent = Console.ReadLine();
    }
}