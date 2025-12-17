class Tile
{
    protected List<string> _visual;

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

    public virtual int GetHealth()
    {
        return 0;
    }
}