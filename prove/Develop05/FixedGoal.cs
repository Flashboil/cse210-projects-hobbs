class FixedGoal : Goal
{
    private int _completionGoal;
    private int _completionCurrent;
    public FixedGoal(string name, string desc, int points, bool complete, int goal) : base(name, desc, points, complete)
    {
        _completionGoal = goal;
        _completionCurrent = 0;
    }

    public override void CompleteTask(Record record)
    {
        record.AddPoints(_points);
        _completionCurrent += 1;
        
        if (_completionCurrent == _completionGoal)
        {
            _isComplete = true;
            record.AddPoints(_points * 10);
        }

        record.CheckStreak();
    }

    public override string GetInfo()
    {
        return $"[{_completionCurrent} / {_completionGoal}] {_name} ({_description}).";
    }
}