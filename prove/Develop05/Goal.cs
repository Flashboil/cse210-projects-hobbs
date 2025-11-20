using System.Reflection;

abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;
    protected bool _isComplete;

    public Goal(string name, string desc, int points, bool complete)
    {
        _name = name;
        _description = desc;
        _points = points;
        _isComplete = complete;
    }

    public int GetPoints()
    {
        return _points;
    }

    public void SetPoints(int points)
    {
        _points = points;
    }

    public abstract void CompleteTask(Record record);

    public abstract string GetInfo();
}