using System;

class Program
{
    static void Main(string[] args)
    {
        GameBoard board = new GameBoard();
        PlayerDeck deck = new PlayerDeck();
        GameManager manager = new GameManager(0, 0, 0, 0, board, deck);

        manager.RenderClearAll();

        deck.DrawHand();
        deck.RenderHand();

        manager.PlayerPlayCard(0, 2);
        manager.RenderAll();
        deck.RenderHand();
    }
}