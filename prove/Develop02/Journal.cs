using System.Text.Json.Nodes;
using System.Xml;

public class Journal
{
    public string _name;
    public List<JournalEntry> _entries = new List<JournalEntry>();

    public void DisplayJournalEntries()
    {
        foreach (JournalEntry entry in _entries)
        {
            entry.DisplayEntry();
        }
    }

    public void SaveToFile(string filename)
    {
        List<string> lines = new List<string>();

        foreach (JournalEntry entry in _entries)
        {
            string line = $"{entry._datetime},{entry._dayRating},{entry._promptToday},{entry._entryContent}";
            lines.Add(line);
        }

        File.WriteAllLines(filename, lines);
    }
    
    public void LoadFromFile(string filename)
    {
        string[] lines = File.ReadAllLines("journal.txt");

        foreach (string line in lines)
        {
            string[] parts = line.Split(',');

            JournalEntry entry = new JournalEntry
            {
                _datetime = parts[0],
                _dayRating = int.Parse(parts[1]),
                _promptToday = parts[2],
                _entryContent = parts[3]
            };

            _entries.Add(entry);
        }
    }
}