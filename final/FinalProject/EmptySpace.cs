class EmptySpace : Tile
{
    public EmptySpace(int column, int row) : base(column, row)
    {
        _visual = new List<string> {"╒ - ╕","|   |","╘ - ╛"};
    }
}