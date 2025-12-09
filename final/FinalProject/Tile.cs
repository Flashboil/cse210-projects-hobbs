class Tile
{
    protected List<string> _visual;
    // protected (int column, int row) _location;

    // public Tile(int column, int row)
    // {
    //     _location = (column, row);
    // }

    public void PrintVisual(int line)
    {
        Console.Write(_visual[line]);
    }
}