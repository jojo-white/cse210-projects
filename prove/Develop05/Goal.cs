using System.Drawing;
using System.Reflection.Metadata;


public abstract class Goal
{
    private string _goalName = "";
    private string _description = "";
    private int _pointValue;
    private bool _goalFinished;
    
    
    // this constructor takes one string of text, splits it, and uses Initialize method to assign them to the different private variables in this class
    public Goal(string text)
    {
        string[] parts = text.Split("~~");
        bool finished = (parts[1] == "[X]");
        Initialize(parts[2], parts[3], int.Parse(parts[4]), finished);
    }

    // this constructor calls the Initialize method to assign the variables passed in the constructor to the private variables in this class
    public Goal(string goalName, string description, int pointValue, bool goalFinished)
    {
        Initialize(goalName, description, pointValue, goalFinished);
    }
    // Assigns the passed in variables to the private variables in the class
    private void Initialize(string goalName, string description, int pointValue, bool goalFinished)
    {
        _goalName = goalName;
        _description = description;
        _pointValue = pointValue;
        _goalFinished = goalFinished;
    }


    
    public string GetGoalName()
    {
        return _goalName;
    }

    public string GetDescription()
    {
        return _description;
    }
    
    public int GetPointValue()
    {
        return _pointValue;
    }

    public void SetBoolFinished(bool finished)
    {
        _goalFinished = finished;        
    }
    public bool GetBoolFinished()
    {
        return _goalFinished;
    }
    public string CompletionMark()
    {
        if (_goalFinished) return "[X]";
        else return "[ ]";
    }

    public abstract string GetGoalType();
    public abstract string AsString();
    public abstract string GetDisplayString();   
    public abstract int RecordEvent();
    public virtual string CreateDelimitedString(string delimiter)
    {
        string goalType = GetGoalType();
        
        string box = CompletionMark();

        string goalName = GetGoalName();

        string goalDescription = GetDescription();

        int goalPoints = GetPointValue();

        string result = $"{goalType}{delimiter}{box}{delimiter}{goalName}{delimiter}{goalDescription}{delimiter}{goalPoints}";

        return result;
    }

}