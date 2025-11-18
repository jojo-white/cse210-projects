using System.Security.Cryptography;
using System;
public class Word
{
    private string _wordString;
    private bool _wordShown = true;

    public Word(string word)
    {
        _wordString = word;
    }

    public void Show()
    {
        _wordShown = true;
    }

    public void Hide()
    {
        _wordShown = false;
    }

    public bool isShown()
    {
        return _wordShown;
    }

    // Researched on my own about modifiers and found override, which allows for us to write over a class in case of a specific situation
    // While looking for ways to turn things into strings for easier readability, I learned about ToString, which helps with making certain objects easier to understand for the human brain (for me at least)
    public override string ToString()
    {
        // Since _wordShown is a boolean already, we can leave it as just _wordShown
        if (_wordShown)
        {
            return _wordString;
        }
        // Found new when researching how to censor words that we want to learn when memorizing a scripture
        return new string('*', _wordString.Length);
    }

    
}