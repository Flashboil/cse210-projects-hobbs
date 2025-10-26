using System.Data;

public class Reference
{
    private string _book;
    private string _chapter;
    private string _startVerse;
    private string _endVerse;

    public Reference(string book, string chapter, string startVerse, string endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public Reference(string book, string chapter, string startVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = startVerse;
    }

    public string GetReference()
        {
            if (_startVerse != _endVerse)
            {
                return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
            }
            else
            {
                return $"{_book} {_chapter}:{_startVerse}";
            }
        }

}