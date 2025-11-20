class Record
{
    private int _totalPoints;
    private List<Goal> _goals;
    private DateTime _lastCompletion;
    private int _streak;

    //save and load stuff here <--

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
            }
            else
            {
                AddPoints(100);
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

}