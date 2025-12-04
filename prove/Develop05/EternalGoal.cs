using System.Drawing;

public class EternalGoal : Goal
{
    public const string GoalType = "EternalGoal";
    private const bool GoalFinished = false;

    public EternalGoal(string text) : base(text)
    {}

    public EternalGoal(string goalName, string description, int pointValue, bool goalFinished) : base(goalName, description, pointValue, goalFinished)
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
        SetBoolFinished(GoalFinished);
        return 0;
    }
}