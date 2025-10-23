public class Scripture
{
    private List<Word> _words = new List<Word>();
    private Reference _reference;
    private int _blankInterval;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        List<string> words = text.Split().ToList();
        foreach (string word in words)
        {
            _words.Add(new Word(word));
        }
    }
    
    public void RandomizeInterval()
    {
        Random rnd = new Random();
        _blankInterval = rnd.Next(3, 8);
    }

    (int i = 0; i < 20; i += 3)

}