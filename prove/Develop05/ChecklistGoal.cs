using System.Drawing;
using System.Dynamic;

public class ChecklistGoal : Goal
{
    private int _valueUntilComplete;
    private int _bonusValue;
    private int _timesCompleted;
    public const string GoalType = "ChecklistGoal";

    public ChecklistGoal(string text) : base(text)
    {
        string[] parts = text.Split("~~");
        _bonusValue = int.Parse(parts[5]);
        _timesCompleted = int.Parse(parts[6]);
        _valueUntilComplete = int.Parse(parts[7]);

    }
    public ChecklistGoal(string goalName, string description, int pointValue, bool goalFinished, int valueUntilComplete, int bonusValue) : base(goalName, description, pointValue, goalFinished)
    {
        Initialize(valueUntilComplete, bonusValue);
    }

    private void Initialize(int valueUntilComplete, int bonusValue)
    {
        _valueUntilComplete = valueUntilComplete;
        _bonusValue = bonusValue;
    }
    public int GetBonusValue()
    {
        return _bonusValue;
    }
    public int GetValueUntilComplete()
    {
        return _valueUntilComplete;
    }
    public int GetTimesCompleted()
    {
        return _timesCompleted;
    }
    public void SetTimesCompleted(int timesCompleted)
    {
        _timesCompleted = timesCompleted;
    }
    
    public override string GetGoalType()
    {
        return GoalType;
    }
    public override string GetDisplayString()
    {
        string goalToSplit = CreateDelimitedString("~~");
        string[] parts = goalToSplit.Split("~~");
        string goalDisplay = $"{parts[1]} {parts[2]} ({parts[3]}) -- Currently completed: {parts[6]}/{parts[7]}";
        return goalDisplay;
    }
    public override string CreateDelimitedString(string delimiter)
    {
        string goalType = GetGoalType();
        
        string box = CompletionMark();

        string goalName = GetGoalName();

        string goalDescription = GetDescription();

        int goalPoints = GetPointValue();

        int bonusValue = GetBonusValue();

        int timesCompleted = GetTimesCompleted();

        int valueUntilComplete = GetValueUntilComplete();

        string result = $"{goalType}{delimiter}{box}{delimiter}{goalName}{delimiter}{goalDescription}{delimiter}{goalPoints}{delimiter}{bonusValue}{delimiter}{timesCompleted}{delimiter}{valueUntilComplete}";

        return result;
    }
    public override int RecordEvent()
    {
        _timesCompleted++;
        if (_timesCompleted == _valueUntilComplete)
        {
            SetBoolFinished(true);
            return GetBonusValue();
        }
        return 0;
    }


}