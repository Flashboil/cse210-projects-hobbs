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
    private bool _isRunning;

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
        _isRunning = true;
    }

    public bool GetRunning()
    {
        return _isRunning;
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
                BatteryMax();
                RenderClearAll();

                while (playerResponse != 1 && playerResponse != 2)
                {
                    if (_playerDeck.GetLibrary().Count > 0 || _playerDeck.GetVessels().Count > 0)
                    {
                        Console.WriteLine("[1] Draw from Library [2] Draw Vessel (0/1, cost 1)");
                        playerResponse = int.Parse(Console.ReadLine());   

                        if (playerResponse == 1)
                        {
                            if (_playerDeck.GetLibrary().Count > 0)
                            {
                                _playerDeck.DrawCard();  
                            }
                            else
                            {
                                Console.WriteLine("You have no more cards to draw.");
                                playerResponse = 3;
                            }
                        }
                        else if (playerResponse == 2)
                        {
                            if (_playerDeck.GetVessels().Count > 0)
                            {
                                 _playerDeck.DrawVessel(); 
                            }
                            else
                            {
                                Console.WriteLine("You have no more vessels to draw.");
                                playerResponse = 3;
                            }
                        }   
                    }
                    else
                    {
                        Console.WriteLine("You have no more cards to draw.");
                    }
                }
            }
            else
            {
                _playerDeck.DrawVessel();
            }

            playerResponse = -1;
            RenderClearAll();

            while (playerResponse != 1 && playerResponse != 2)
            {
                Console.WriteLine("[1] Play Card [2] Finish Turn");
                playerResponse = int.Parse(Console.ReadLine());
                
                if (playerResponse == 1)
                {
                    int cardChoice = -2;

                    while (cardChoice != -1 && (cardChoice < 1 || cardChoice > _playerDeck.GetHand().Count))
                    {
                        RenderClearAll();

                        Console.WriteLine("Which card do you want to play? Or type -1 to go back.");

                        cardChoice = int.Parse(Console.ReadLine());
                    }

                    if (cardChoice != -1)
                    {
                        int laneChoice = 0;

                        while (laneChoice != -1 && (laneChoice < 1 || laneChoice > 4))
                        {
                            int cardIndex = cardChoice - 1;

                            Console.WriteLine("In which lane do you want to play? Or type -1 to go back.");
                            laneChoice = int.Parse(Console.ReadLine());

                            if (laneChoice >= 1 && laneChoice <= 5)
                            {
                                PlayerPlayCard(laneChoice - 1, cardIndex);
                                RenderClearAll();
                            }
                        }
                    }
                    else
                    {
                        DoCombat();
                        playerResponse = 1;  
                    }

                    playerResponse = 3;

                }
                else if (playerResponse == 2 || playerResponse == -1)
                {
                    DoCombat();
                    playerResponse = 2;
                }
            }
        }
        else
        {
            AdvanceCards();
            RenderClearAll();
            Thread.Sleep(1000);

            EnemyPlayCard();
            RenderClearAll();
            Thread.Sleep(1000);

            DoCombat();
            RenderClearAll();
            Thread.Sleep(1000);
        }

        NextTurn();
        RenderClearAll();
        CheckStatus();
    }
    
    public void DoCombat()
    {
        int attackerRow = _playerTurn ? 2 : 1;
        int targetRow = _playerTurn ? 1 : 2;

        for (int lane = 0; lane < 5; lane++)
        {
            Tile attackerTile = _board.GetBoardRow(attackerRow).GetSingleTile(lane);
            Tile targetTile = _board.GetBoardRow(targetRow).GetSingleTile(lane);

            if (attackerTile is Card attackerCard)
            {
                if (targetTile is Card targetCard)
                {
                    targetCard.TakeDamage(attackerCard.GetPower());

                    if (targetCard.GetHealth() <= 0)
                    {
                        _board.GetBoardRow(targetRow).UpdateRow(lane, new EmptySpace());
                    }
                }
                else
                {
                    if (_playerTurn)
                    {
                        _score.enemy -= attackerCard.GetPower();
                    }
                    else
                    {
                        _score.player -= attackerCard.GetPower();
                    }
                }
            }
        }
    }

    public void AdvanceCards()
    {
        List<int> lanesToAdvance = new List<int>();

        for (int lane = 0; lane < 5; lane++)
        {
            Tile current = _board.GetBoardRow(0).GetSingleTile(lane);
            Tile next = _board.GetBoardRow(1).GetSingleTile(lane);

            if (current is Card && next is not Card)
            {
                lanesToAdvance.Add(lane);
            }
        }

        foreach (int lane in lanesToAdvance)
        {
            Tile card = _board.GetBoardRow(0).GetSingleTile(lane);
            _board.GetBoardRow(1).UpdateRow(lane, card);
            _board.GetBoardRow(0).UpdateRow(lane, new PreviewSpace());
        }
    }
    public void NextTurn()
    {
        _playerTurn = !_playerTurn;
    }

    public void CheckStatus()
    {
        if (_score.player - _score.enemy >= 10)
        {
            _isRunning = false;
            Console.WriteLine("Game End!");
            Console.WriteLine("You Win!");
        }
        else if (_score.player - _score.enemy <= -10)
        {
            _isRunning = false;
            Console.WriteLine("Game End!");
            Console.WriteLine("You Lose!");
        }
    }

    public void BatteryMax()
    {
        _maxBattery = Math.Min(_maxBattery + 1, 6);
        _battery = _maxBattery;
    }

    public void RenderBattery()
    {
        for (int i = 0; i < 6; i++)
        {
            if (i < _battery)          
            {
                Console.Write("[+]");
            }
            else if (i < _maxBattery)  
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
        Console.WriteLine("You - Opponent : Score");
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

    public void EnemyPlayCard()
    {
        int tries = 0;
        bool playedCard = false;

        _enemyDeck.DrawHand();
        int row = 0;

        Random rnd1 = new Random();
        Random rnd2 = new Random();

        int index = rnd1.Next(_enemyDeck.CardsFromHand().Count); 
        Card card = _enemyDeck.CardFromHand(index);

        int column = rnd2.Next(0, 4);
        
        while (tries < 5 && !playedCard)
        { 
            if (_board.GetBoardRow(row).GetSingleTile(column) is Card)
            {
                tries += 1;
            }
            else
            {
                _enemyDeck.Discard(index);
                _board.UpdateRow(column, row, card);
                playedCard = true;
            }
        }
    }
}