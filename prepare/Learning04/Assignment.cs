public class Assignment
{
    
    private string _studentName;
    private string _topic;

    public Assignment()
    {
        _studentName = "No Name";
        _topic = "No Topic";
    }

    public Assignment(string studentName, string assignmentTopic)
    {
        _studentName = studentName;
        _topic = assignmentTopic;
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