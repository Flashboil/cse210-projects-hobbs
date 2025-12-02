class BoardRow
{
    private List<Tile> _tiles;

    public BoardRow(Tile slot1, Tile slot2,Tile slot3,Tile slot4,Tile slot5)
    {
        _tiles = new List<Tile>{slot1, slot2, slot3, slot4, slot5};
    }

    public BoardRow(List<Tile> tiles)
    {
        _tiles = tiles;
    }

    public BoardRow(int row, string type)
    {
        _tiles = new List<Tile>();

        if (type == "p")
        {
            for (int column = 0; column < 5; column++)
            {
                _tiles.Add(new EmptySpace(column, row));
            }   
        }
        else
        {
            for (int column = 0; column < 5; column++)
            {
                _tiles.Add(new PreviewSpace(column, row));
            }   
        }
    }

    public void RenderRow()
    {
        for (int line = 0; line < 3; line++)
        {
            foreach (Tile t in _tiles)
            {
                t.PrintVisual(line);
            }   
            Console.WriteLine();
        }
    }

    public void UpdateRow(int column, Tile tile)
    {
        _tiles[column] = tile;
    }
}