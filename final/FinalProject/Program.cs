using System;

class Program
{
    static void Main(string[] args)
    {
        GameBoard board = new GameBoard();
        board.RenderBoard();

        GameManager manager = new GameManager(2, 4, 15, 5, board);

        manager.RenderBattery();
        manager.RenderScore();

        manager.RenderClearAll();
    }
}