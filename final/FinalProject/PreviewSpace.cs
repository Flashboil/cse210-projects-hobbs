class PreviewSpace : Tile
{
    public PreviewSpace(int column, int row) : base(column, row)
        {
            _visual = new List<string> {"╔ - ╗","| V |","╚ - ╝"};
        }
}