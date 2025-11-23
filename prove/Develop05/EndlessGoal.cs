class EndlessGoal : Goal
{
    private int _completionTotal;
    public EndlessGoal(string name, string desc, int points, bool complete, int total) : base(name, desc, points, complete)
    {
        _completionTotal = total;
    }

    public override void CompleteTask(Record record)
    {
        _completionTotal += 1;
        record.AddPoints(_points);
        record.CheckStreak();
    }

    public override string GetInfo()
    {
        return $"[{_completionTotal}] {_name} ({_description}).";
    }

    public override string FormatSave()
    {
        return $"EndlessGoal|{_name}|{_description}|{_points}|{_isComplete}|{_completionTotal}";
    }
}