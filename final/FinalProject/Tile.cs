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

    public void UpdateVisual(List<String> visual)
    {
        _visual = visual;
    }

    public virtual int GetPower()
    {
        return 0;
    }
}