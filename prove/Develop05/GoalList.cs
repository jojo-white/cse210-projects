using System.Text.Json;

// The list is a Generic Class that can take any type
public class GoalList : List<Goal>
{
    private int _totalPoints;
    public GoalList()
    {}

    public int GetTotalPoints()
    {
        return _totalPoints;
    }
    public void SetTotalPoints(int totalPoints)
    {
        _totalPoints = totalPoints;
    }
    public int AddPoints(int points)
    {
        _totalPoints += points;
        return _totalPoints;
    }


    public void SaveToFile(string fileName)
    {
        Console.WriteLine("Saving to file...");
        string file = fileName;
        

        using (StreamWriter outputFile = new StreamWriter(file))
        {
            outputFile.WriteLine(GetTotalPoints());
            foreach (Goal g in this)
            {
                string text = g.AsString();
                outputFile.WriteLine(text);
            }
        }
    }

    public void LoadFromFile(string fileName)
    {
        Console.WriteLine("Reading from File...");

        using (StreamReader inputFile = new StreamReader(fileName))
        {
            string userPoints = inputFile.ReadLine();
            int totalPoints = int.Parse(userPoints);
            SetTotalPoints(totalPoints);
            
            while(!inputFile.EndOfStream)
            {
                string text = inputFile.ReadLine();
                
                Goal g = CreateGoal(text);

                // "this" refers to the class I'm working in, calling itself
                this.Add(g);
            }
        }
    }

    private static Goal CreateGoal(string text)
    {
        string[] parts = text.Split("~~");
        // string checkText = "";
        switch(parts[0])
        {
            // Create new case for each goal type, create a constant "GoalType" in each different goal class
            case SimpleGoal.GoalType:
                return new SimpleGoal(text);
            case EternalGoal.GoalType:
                return new EternalGoal(text);
            case ChecklistGoal.GoalType:
                return new ChecklistGoal(text);
            default:
                throw new NotImplementedException(parts[0]);                
        }
    }

    public void DisplayGoals()
    {
        int goalCount = 1;
        foreach (Goal g in this)
        {
            string goal = g.GetDisplayString();
            Console.WriteLine($"{goalCount}. {goal}");
            goalCount++;
        }
    }
    public void ListGoalName()
    {
        int goalCount = 1;
        foreach (Goal g in this)
        {
            if (!g.GetBoolFinished())
            {
                string goalName = g.GetGoalName();
                Console.WriteLine($"{goalCount}. {goalName}");
                goalCount++;
            }
            
        }
    }

    public void RecordEvent(int index)
    {
        Goal g = this[index];
        int bonusPoints = g.RecordEvent();
        this.AddPoints(g.GetPointValue()+bonusPoints);   
    
    }
}