class GameManager
{
    private bool _playerTurn;
    private int _battery;
    private int _maxBattery;
    private (int player, int enemy) _score;
    private GameBoard _board;

    public GameManager(int battery, int maxBattery, int playerScore, int enemeyScore, GameBoard board)
    {
        _playerTurn = true;
        _battery = battery;
        _maxBattery = maxBattery;
        _score = (playerScore, enemeyScore);
        _board = board;
    }
    
    public void DoCombat()
    {
        
    }

    public void NextTurn()
    {
        if (_score.player - _score.enemy >= 10)
            Console.WriteLine("Game End!");
        _playerTurn = !_playerTurn;
    }

    public void BatteryMax()
    {
        if (_maxBattery < 6)
        {
            _maxBattery += 1;
        }

        _battery = _maxBattery;
    }
    public void RenderBattery()
    {
        for (int bat = 0; bat < 6; bat++)
        {
            if (bat <= _battery)
            {
                Console.Write("[+]");
            }
            else if (bat <= _maxBattery)
            {
                Console.Write("[_]");
            }
            else
            {
                Console.Write("[/]");
            }
        }

        Console.WriteLine();
    }

    public void RenderScore()
    {
        if (_score.player > _score.enemy)
        { 
            Console.WriteLine($"{_score.player} > {_score.enemy} : {_score.player - _score.enemy}");
        }
        else if (_score.player < _score.enemy)
        {
            Console.WriteLine($"{_score.player} < {_score.enemy} : {_score.player - _score.enemy}");
        }
        else
        {
            Console.WriteLine($"{_score.player} = {_score.enemy} : {_score.player - _score.enemy}");
        }
    }

    public void RenderAll()
    {
        _board.RenderBoard();
        RenderBattery();
        RenderScore();
    }

    public void RenderClearAll()
    {
        Console.Clear();
        Console.WriteLine("\x1b[3J");

        _board.RenderBoard();
        RenderBattery();
        RenderScore();
    }
}