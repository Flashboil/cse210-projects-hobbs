using System;

class Program
{
    static void Main(string[] args)
    {
        EmptySpace slot1 = new EmptySpace(0,0);
        EmptySpace slot2 = new EmptySpace(1,0);
        EmptySpace slot3 = new EmptySpace(2,0);
        EmptySpace slot4 = new EmptySpace(3,0);
        EmptySpace slot5 = new EmptySpace(4,0);

        BoardRow enemyrow = new BoardRow(slot1, slot2, slot3, slot4, slot5);

        enemyrow.RenderRow();

        BoardRow playerrow = new BoardRow(2);

        playerrow.RenderRow();

        
    }
}