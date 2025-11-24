public class Assignment
{
    // protected string _studentName = "";
    // protected string _topic = "";
    private string _studentName;
    private string _topic;

    public Assignment()
    {
        _studentName = "No Name";
        _topic = "No Topic";
    }

    public Assignment(string name, string topic)
    {
        _studentName = name;
        _topic = topic;
    }

    public string GetName()
    {
        return _studentName;
    }

    public string GetTopic()
    {
        return _topic;
    }
    
    public string GetSummary()
    {
        return _studentName + " - " + _topic;
    }
}