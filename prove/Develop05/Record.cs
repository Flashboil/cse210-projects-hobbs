using System.Runtime.CompilerServices;

class Record
{
    private int _totalPoints;
    private List<Goal> _goals;
    private DateTime _lastCompletion;
    private int _streak;

    public Record(string filename)
    {
        _goals = LoadGoals(filename);
        LoadData(filename);
    }

    public void LoadData(string filename)
    {
        string line = File.ReadAllLines(filename).First();

        string[] parts = line.Split('|');

        _totalPoints = int.Parse(parts[0]);
        _lastCompletion = DateTime.Parse(parts[1]);
        _streak = int.Parse(parts[2]);
    }
    public List<Goal> LoadGoals(string filename)
    {
        string[] lines = File.ReadAllLines(filename);

        List<Goal> goals = new List<Goal>();

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];

            string[] parts = line.Split('|');
            string goalType = parts[0];
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);
            bool complete = bool.Parse(parts[4]);

            switch (goalType)
            {
                case "SimpleGoal":
                    goals.Add(new SimpleGoal(name, description, points, complete));
                    break;
                case "FixedGoal":
                    int completionCurrent = int.Parse(parts[5]);
                    int completionGoal = int.Parse(parts[6]);
                    goals.Add(new FixedGoal(name, description, points, complete, completionCurrent, completionGoal));
                    break;
                case "EndlessGoal":
                    int completeTotal = int.Parse(parts[5]);
                    goals.Add(new EndlessGoal(name, description, points, complete, completeTotal));
                    break;
            }

        }

        return goals;
    }

    public void SaveData(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
    {
        writer.WriteLine($"{_totalPoints}|{_lastCompletion}|{_streak}");

        foreach (Goal g in _goals)
        {
            string line = g.FormatSave();
            writer.WriteLine(line);
        }
    }
    }

    public void DisplayPoints()
    {
        Console.WriteLine($"Total points: {_totalPoints}");
    }
    public void AddPoints(int points)
    {
        _totalPoints += points;
    }

    public void CheckStreak()
    {
        DateTime today = DateTime.Today;
        DateTime yesterday = today.AddDays(-1);

        if (_lastCompletion == yesterday)
        {
            _streak += 1;
            if (_streak <= 7)
            {
                AddPoints(_streak * 10);
                Console.WriteLine($"Bonus for {_streak} day streak!");
            }
            else
            {
                AddPoints(100);
                Console.WriteLine($"Bonus for {_streak} day streak!");
            }
        }
        else if (_lastCompletion == today)
        {
        }
        else
        {
           _streak = 0; 
        }

        _lastCompletion = DateTime.Today;
    }

    public void DisplayGoals()
    {
        int numbered = 1;
        foreach (Goal g in _goals)
        {
            Console.Write($"{numbered}. ");
            Console.WriteLine(g.GetInfo());
            numbered += 1;
        }
    }

    public void UpdateGoal(int goalIndex)
    {
        _goals[goalIndex].CompleteTask(this);
    }

    public void AddNewGoal(Goal goal)
    {
        _goals.Add(goal);
    }

}