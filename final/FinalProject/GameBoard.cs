using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

class GameBoard
{
    private List<BoardRow> _rows;

    public GameBoard()
    {
        _rows = new List<BoardRow>();

        _rows.Add(new BoardRow(0, ""));
        for (int row = 1; row < 3; row++)
            {
                _rows.Add(new BoardRow(row, "p"));
            }
    }

    public void RenderBoard()
    {
        foreach (BoardRow row in _rows)
        {
            row.RenderRow();
        }
    }

    public void UpdateRow(int column, int row, Tile tile)
    {
        
    }
}