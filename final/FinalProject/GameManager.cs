class GameManager
{
    private bool _playerTurn;
    private int _battery;
    private int _maxBattery;
    private (int player, int enemy) _score;
    private GameBoard _board;
    private Deck _playerDeck;
    private Deck _enemyDeck;
    private int _turnCount;

    public GameManager(int battery, int maxBattery, int playerScore, int enemeyScore, GameBoard board, Deck player, Deck enemy)
    {
        _playerTurn = true;
        _battery = battery;
        _maxBattery = maxBattery;
        _score = (playerScore, enemeyScore);
        _board = board;
        _playerDeck = player;
        _enemyDeck = enemy;
        _turnCount = 0;
    }

    public void DoTurn()
    {
        RenderClearAll();
        _turnCount += 1;
        int playerResponse = -1;

        if (_playerTurn)
        {   
            if (_turnCount > 1)
            {
                while (playerResponse != 1 || playerResponse != 2)
                {
                    Console.WriteLine("[1] Draw from Library [2] Draw Vessel (0/1, cost 1)");
                    playerResponse = int.Parse(Console.ReadLine());   

                    if (playerResponse == 1)
                    {
                        _playerDeck.DrawCard();
                    }
                    else if (playerResponse == 2)
                    {
                        _playerDeck.DrawVessel();
                    }
                }
            }

            playerResponse = -1;
            RenderClearAll();

            while (playerResponse != 1 || playerResponse != 2)
            {
                Console.WriteLine("[1] Play Card [2] Finish Turn");
                playerResponse = int.Parse(Console.ReadLine());
                
                if (playerResponse == 1)
                {
                    RenderClearAll();

                    Console.WriteLine("Which card do you want to play? Or type -1 to finish turn.");
                    _playerDeck.RenderHand();

                    playerResponse = int.Parse(Console.ReadLine());
                }
                else if (playerResponse == 2)
                {
                    DoCombat();
                }
            }


        }
    }
    
    public void DoCombat()
    {
        int row = 1;
        if (_playerTurn)
        {
            row = 2;
        }

        foreach (Tile tile in _board.GetBoardRow(row).GetTiles())
        {
            if (tile is Card)
            {
                if (_playerTurn)
                {
                    _score.enemy -= tile.GetPower();
                }
                else
                {
                    _score.player -= tile.GetPower();
                }
            }
        }
    }

    public void NextTurn()
    {
        BatteryMax();
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
        _playerDeck.RenderHand();
    }

    public void RenderClearAll()
    {
        Console.Clear();
        Console.WriteLine("\x1b[3J");

        RenderScore();
        _board.RenderBoard();
        RenderBattery();
        _playerDeck.RenderHand();
    }

    public void PlayerPlayCard(int column, int index)
    {
        int row = 2;

        Card card = _playerDeck.CardFromHand(index);

        if (_board.GetBoardRow(row).GetSingleTile(column) is Card)
        {
            Console.WriteLine("There is already a card there.");
            Thread.Sleep(1000);
        }
        else
        {   
            if (card.GetCost() <= _battery)
            {
                _battery -= card.GetCost();
                _playerDeck.Discard(index);
                _board.UpdateRow(column, row, card);
            }
            else
            {
                Console.WriteLine("You do not have enough battery.");
                Thread.Sleep(1000);
            }
        }
    }

    public void EnemyPlayCard(int column, int index)
    {
        int row = 0;
        Card card = _enemyDeck.CardFromHand(index);
        _enemyDeck.Discard(index);
        _board.UpdateRow(column, row, card);
    }
}