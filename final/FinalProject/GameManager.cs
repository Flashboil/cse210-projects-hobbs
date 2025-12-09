class GameManager
{
    private bool _playerTurn;
    private int _battery;
    private int _maxBattery;
    private (int player, int enemy) _score;
    private GameBoard _board;
    private Deck _playerDeck;
    private Deck _enemyDeck;

    public GameManager(int battery, int maxBattery, int playerScore, int enemeyScore, GameBoard board, Deck player)
    {
        _playerTurn = true;
        _battery = battery;
        _maxBattery = maxBattery;
        _score = (playerScore, enemeyScore);
        _board = board;
        _playerDeck = player;
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
        RenderScore();
        _board.RenderBoard();
        RenderBattery();
    }

    public void RenderClearAll()
    {
        Console.Clear();
        Console.WriteLine("\x1b[3J");

        RenderScore();
        _board.RenderBoard();
        RenderBattery();
    }

    public void PlayerPlayCard(int column, int index)
    {
        int row = 2;
        Card card = _playerDeck.CardFromHand(index);
        _playerDeck.Discard(index);
        _board.UpdateRow(column, row, card);
    }

    public void EnemyPlayCard(int column, int index)
    {
        int row = 0;
        Card card = _enemyDeck.CardFromHand(index);
        _enemyDeck.Discard(index);
        _board.UpdateRow(column, row, card);
    }
}