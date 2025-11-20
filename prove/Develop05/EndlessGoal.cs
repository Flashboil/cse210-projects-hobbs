class EndlessGoal : Goal
{
    private int _completionTotal;
    public EndlessGoal(string name, string desc, int points, bool complete) : base(name, desc, points, complete)
    {
        _completionTotal = 0;
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
}