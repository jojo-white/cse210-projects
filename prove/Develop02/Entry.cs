public class Entry
{
    public string _entry = "";
    public string _prompt = "";
    public string _currentTime = "";
    

    public Entry()
    {
    }

    public void Display()
    {
        Console.WriteLine($"{_prompt} {_entry} {_currentTime}");

    }

}