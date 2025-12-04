using System;

class Program
{
    static void Main(string[] args)
    {
        bool exitProgram = false;
        GoalList goalList = new GoalList();
        
        
        Console.Clear();    

        while (!exitProgram)
        {
            int totalPoints = goalList.GetTotalPoints();
            Console.WriteLine();
            Console.WriteLine($"You have {totalPoints} points.\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("\t1. Create New Goal");
            Console.WriteLine("\t2. List Goals");
            Console.WriteLine("\t3. Save Goals");
            Console.WriteLine("\t4. Load Goals");
            Console.WriteLine("\t5. Record Event");
            Console.WriteLine("\t6. Quit");
            Console.Write("Select a choice from the menu: ");
            string answer = Console.ReadLine();
            int userChoice = int.Parse(answer);


            if (userChoice == 1)
            {
                Console.WriteLine();
                SetNewGoal(goalList);
            }

            else if (userChoice == 2)
            {
                Console.Clear();
                Console.WriteLine();
                goalList.DisplayGoals();
            }

            else if (userChoice == 3)
            {
                Console.WriteLine();
                Console.Write("What is the name of the file you want to save to? ");
                string fileChoice = Console.ReadLine();
                goalList.SaveToFile(fileChoice);
            }

            else if (userChoice == 4)
            {
                Console.WriteLine();
                Console.Write("What is the name of the file you want to load? ");
                string fileChoice = Console.ReadLine();
                goalList.LoadFromFile(fileChoice);
            }

            else if (userChoice == 5)
            {
                CallRecordEntry(goalList);
            }

            else if (userChoice == 6)
            {
                Console.WriteLine("Goodbye! Have a good day!");
                exitProgram = true;
            }

            else
            {
                Console.WriteLine("That is not an option. Please try again.");
                Thread.Sleep(1500);
            }

        }
    }

    private static void CallRecordEntry(GoalList goalList)
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("Your current goals are:");
        goalList.ListGoalName();
        Console.WriteLine("\nType 'quit' to exit.");
        Console.Write("Which goal did you accomplish? ");
        string record = Console.ReadLine();
        if (record == "quit")
        {
            Console.Clear();
        }
        else
        {
            int recordChoice = int.Parse(record) - 1;
            goalList.RecordEvent(recordChoice);
            Goal goalChoice = goalList[recordChoice];
            int gPoints = goalChoice.GetPointValue();
            Console.WriteLine($"Congratulations! You've earned {gPoints} points!");

            
            if (goalChoice.GetBoolFinished() && goalChoice is ChecklistGoal)
            {
                // ((ChecklistGoal)goalChoice).GetBonusValue() is called casting, and allows you to, as Microsoft puts it, explicitly make a conversion and that it indicates you're aware data loss might occur, or the cast might fail at run time
                int bonusPoints = ((ChecklistGoal)goalChoice).GetBonusValue();
                Console.WriteLine($"WOAHHHHH CONGRATULATIONS YOU GOT {bonusPoints} BONUS POINTS!!");
            }
            Thread.Sleep(1500);
        }

    }

    private static void SetNewGoal(GoalList goalList)
    {
        bool exitChoice = false;
        while (!exitChoice)
        {
            Console.Clear();
            Console.WriteLine("The types of Goals are:");
            Console.WriteLine("\t1. Simple Goal");
            Console.WriteLine("\t2. Eternal Goal");
            Console.WriteLine("\t3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");
            string goalAnswer = Console.ReadLine();
            int goalChoice = int.Parse(goalAnswer);

            Console.Write("What is the name of your goal? ");
            string goalName = Console.ReadLine();

            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();

            Console.Write("What is the amount of points associated with this goal? ");
            string points = Console.ReadLine();
            int pointValue = int.Parse(points);


            if (goalChoice == 1)
            {
                exitChoice = true;
                Console.WriteLine();
                SimpleGoal sGoal = new SimpleGoal(goalName, description, pointValue, false);
                goalList.Add(sGoal);
                Console.Clear();
            }
            else if (goalChoice == 2)
            {
                Console.WriteLine();
                EternalGoal eGoal = new EternalGoal(goalName, description, pointValue, false);
                goalList.Add(eGoal);
                exitChoice = true;
                Console.Clear();
            }
            else if (goalChoice == 3)
            {
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                string times = Console.ReadLine();
                int totalTimes = int.Parse(times);

                Console.Write("What is the bonus for accomplishing it that many times? ");
                string bonus = Console.ReadLine();
                int totalBonus = int.Parse(bonus);
                ChecklistGoal cGoal = new ChecklistGoal(goalName, description, pointValue, false, totalTimes, totalBonus);
                goalList.Add(cGoal);
                exitChoice = true;
                Console.Clear();
            }
            else
            {
                Console.WriteLine("That is not an option. Please Try again.");
                Thread.Sleep(1500);
            }
        }
    }

}