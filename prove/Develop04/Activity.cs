using System.Data;

public class Activity
{

    protected static Random randomGenerator = new Random();
    private int _timer;
    private string _activityName = "";

    private int _spinnerTimer = 0;
    private string _explanation = "";

    private List<string> _spinner = new List<string>{"|", "/", "-", "\\", "|", "/", "-", "\\"};
    public Activity()
    {}

    public Activity(string name)
    {
        _activityName = name;
    }

    
    
    public Activity(string name, string explanation)
    {
        
        _activityName = name;
        _explanation = explanation;
    }

    public void Welcome()
    {
        Console.WriteLine($"Welcome to the {_activityName}.");
        Console.WriteLine($"{_explanation}");
    }

    public int GetActivityLength()
    {
        Console.Write($"About how long, in seconds, would you like for your {_activityName} to be? ");
        string seconds = Console.ReadLine();
        int userTime = int.Parse(seconds);
        _timer = userTime;
        return userTime;
    }

    public string GetPrompt(List<string> promptList)
    {
        int promptNumber = randomGenerator.Next(promptList.Count);
        string prompt = "";
        prompt = promptList[promptNumber];
        return prompt;
    }

    public void Congrats()
    {
        Console.WriteLine("\nWell done!!");
        SetSpinnerTime(3);
        Spinner();
        Console.WriteLine($"You have completed a {_timer} second {_activityName}.");
        Spinner();
    }

    public void CountDown(int countDownTimer)
    {
        for (int i = countDownTimer; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public void SetSpinnerTime(int spinnerTimer)
    {
        _spinnerTimer = spinnerTimer;
    }

    public int GetSpinnerTime()
    {
        return _spinnerTimer;
    }

    public void SetTime(int timer)
    {
        _timer = timer;
    }
    public System.DateTime GetTime()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_timer);
        return endTime;
    }

    public void Spinner()
    {

        int timer = GetSpinnerTime();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(timer);

        int i = 0;
        while (DateTime.Now < endTime)
        {
            string s = _spinner[i];
            Console.Write(s);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i++;

            if (i >= _spinner.Count)
            {
                i = 0;
            }
        }
    }
}