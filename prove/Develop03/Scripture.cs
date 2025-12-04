public class Scripture
{
    private string _scripture = "";
    private List<Word> _wordList = new List<Word>();
    private Word[] _wordArray;

    private Random random = new Random();

    public Scripture(string text)
    {
        _scripture = text;
        
        string[] parts = text.Split();
        _wordArray = new Word[parts.Length];
        for (int i = 0; i < parts.Length; i++)
        {
            _wordArray[i] = new Word(parts[i]);
        }
        // AddRange shoves everything in the parenthesis into a List, so in this case, everything in the array is now a string in the list _wordList
            _wordList.AddRange(_wordArray);
    }

    public string GetScripture()
    {
        string result = _wordArray[0].ToString();
        for (int i = 1; i < _wordArray.Length; i++)
        {
            result += " " + _wordArray[i].ToString();
        }   
        return result;
    }

    
    public int HideWord(int wordsToHide)
    {
        
        while(wordsToHide >= 1)
        {
            if (_wordList.Count == 0) return 0;

            int wordIndex = random.Next(_wordList.Count);
            _wordList[wordIndex].Hide();

            // RemoveAt is used to remove an element from a list (or an array) at a 0 based index
            _wordList.RemoveAt(wordIndex);
            wordsToHide--;
        }
        
        return _wordList.Count;
    }

    public int WordsLeft()
    {

        return _wordList.Count;
    }

    

    
}