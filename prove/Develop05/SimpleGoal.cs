using System.Drawing;

public class SimpleGoal : Goal
{

    // const cannot be changed by program when running, only changed by programmer
    public const string GoalType = "SimpleGoal";

    public SimpleGoal(string text) : base(text)
    {}

    public SimpleGoal(string goalName, string description, int pointValue, bool goalFinished) : base(goalName, description, pointValue, goalFinished)
    {}


    public override string AsString()
    {
        string goalFile = CreateDelimitedString("~~");
        return goalFile;
    }
    public override string GetGoalType()
    {
        return GoalType;
    }
    public override string GetDisplayString()
    {
        string goalToSplit = CreateDelimitedString("~~");
        string[] parts = goalToSplit.Split("~~");
        string goalDisplay = $"{parts[1]} {parts[2]} ({parts[3]})";
        return goalDisplay;
    }

    public override int RecordEvent()
    {
        SetBoolFinished(true);
        return 0;
    }

}