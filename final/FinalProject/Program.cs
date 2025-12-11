using System;

class Program
{
    static void Main(string[] args)
    {
        GameBoard board = new GameBoard();
        PlayerDeck deck = new PlayerDeck();
        EnemyDeck enemy = new EnemyDeck();
        GameManager manager = new GameManager(6, 6, 0, 0, board, deck, enemy);
        
        deck.DrawHand();
        manager.RenderAll();
        manager.PlayerPlayCard(2, 0);

    }
}