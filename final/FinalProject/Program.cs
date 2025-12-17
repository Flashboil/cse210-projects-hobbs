using System;

class Program
{
    static void Main(string[] args)
    {
        GameBoard board = new GameBoard();
        PlayerDeck deck = new PlayerDeck();
        EnemyDeck enemy = new EnemyDeck();
        GameManager manager = new GameManager(1, 1, 0, 0, board, deck, enemy);
        
        deck.DrawHand();
        manager.RenderAll();
        
        manager.DoTurn();

        bool running = true;

        while (running)
        {
            manager.DoTurn();
            running = manager.GetRunning();
        }

    }
}