using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

public class Word
{
    private string _word;
    private bool _hidden;

    public Word(string word)
    {
        _word = word;
        _hidden = false;
    }

    public void MakeHidden()
    {
        _hidden = true;
    }

    public string GetWord()
    {
        if (_hidden == false)
        {
            return _word;
        }
        else
        {
            string blanked = "";
            for (int i = 0; i < _word.Length; i++)
            {
                blanked += "_";
            }
            return blanked;
        }
    }
    
}