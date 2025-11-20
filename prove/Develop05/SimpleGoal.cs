class SimpleGoal : Goal
{
    public SimpleGoal(string name, string desc, int points, bool complete) : base(name, desc, points, complete)
    {
        
    }

    public override void CompleteTask(Record record)
    {
        _isComplete = true;
        record.AddPoints(_points);
        record.CheckStreak();
    }

    public override string GetInfo()
    {
        if (_isComplete)
        {
            return $"[x] {_name} ({_description})";
        }
        else
        {
            return $"[ ] {_name} ({_description})";
        }
    }
}