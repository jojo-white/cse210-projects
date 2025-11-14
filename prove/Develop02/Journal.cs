public class Journal
{
    public List<Entry> _entryList = new List<Entry>();

    public void Display()
    {
        foreach (Entry entry in _entryList)
        {
            entry.Display();
        }
    }

    public void Seperate()
    {
        string seperate = string.Join("~~", _entryList);
    }

    public void SaveToFile(string fileName)
    {
        Console.WriteLine("Saving to file...");
        string file = fileName;
        // string seperate = string.Join("~~", entries);
        
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry e in _entryList)
            {
                string seperate = $"{e._prompt}~~{e._entry}~~{e._currentTime}";
                outputFile.WriteLine(seperate);
            }
        }
    }

    public static Journal ReadFromFile(string fileName)
    {
        Console.WriteLine("Reading from File...");
        Journal journal = new Journal();
        

        string[] lines = System.IO.File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split("~~");

            // parts[0] - prompt
            // parts[1] - entry
            // parts[2] - date

            Entry newEntry = new Entry();
            newEntry._prompt = parts [0];
            newEntry._entry = parts [1];
            newEntry._currentTime = parts[2];
            journal._entryList.Add(newEntry);
        }

        return journal;
    }
}