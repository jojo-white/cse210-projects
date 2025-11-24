public class WritingAssignment : Assignment
{
    private string _title = "";

    public WritingAssignment() : base()
    {} 
    
    public WritingAssignment(string name, string topic, string title) : base(name, topic)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        // return $"{GetName()} - {GetTopic()} \n{_title} by {GetName()}";

        string name = GetName();

        return $"{_title} by {name}";
    }
}