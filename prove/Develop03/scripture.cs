using Microsoft.VisualBasic;

public class Scripture
{
    private List<Word> _words = new List<Word>();
    private Reference _reference;
    private int _blankInterval;
    private List<List<string>> _scriptureList = new List<List<string>>();

    public Scripture(String filename)
    {
        LoadScripturesFromFile(filename);
    }

    public void PrintScripture()
    {
        Console.WriteLine(_reference.GetReference());
        foreach (Word word in _words)
        {
            Console.Write(word.GetWord() + " ");
        }
    }

    public void RandomizeInterval()
{
    Random rnd = new Random();
    _blankInterval = rnd.Next(3, 8);
}

public void RandomBlank()
{
    Random rnd = new Random();
    List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();

    if (visibleWords.Count == 0) return;

    int wordsToHide = Math.Min(_blankInterval, visibleWords.Count);

    for (int i = 0; i < wordsToHide; i++)
    {
        int index = rnd.Next(visibleWords.Count);
        visibleWords[index].MakeHidden();
        visibleWords.RemoveAt(index);
    }
}






    public void LoadScripturesFromFile(string filename)
    {
        string[] lines = File.ReadAllLines(filename);

        Random rnd = new Random();
        string line = lines[rnd.Next(lines.Length)];

        string[] parts = line.Split('|');

        string[] referenceParts = parts[1].Split(':', '-');

        if (referenceParts.Count() > 2)
        {
            _reference = new Reference(parts[0], referenceParts[0], referenceParts[1], referenceParts[2]);
        }
        else
        {
            _reference = new Reference(parts[0], referenceParts[0], referenceParts[1]);
        }

        string[] text = parts[2].Split(" ");

        foreach (String part in text)
        {
            _words.Add(new Word(part));
        }
    }

    

}