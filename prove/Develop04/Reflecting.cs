using System.Security.Cryptography;
using System;

public class Reflecting : Activity
{
    private static Random randomGenerator = new Random();

    private List<string> _promptList = new List<string>{ "Think of your biggest achievement last week.", "Think of a time you spent on a hobby.", "Think of a time when you did something really difficult.", "Think about your actions today.", "Think of your favorite meal from last week."};

    private List<string> _questionList = new List<string>{"How did you feel when you did it?", "What was your favorite thing about this experience?", "What was your least favorite thing about this experience?", "Would you do this again?", "Would you do anything different?"};

    private List<string> _hiddenList = new List<string>{};

    private string _question = "";
    
    private int _reflectTime;

    private string _hiddenQuestion = "";

    public Reflecting() : base()
    {}

    public Reflecting(string name) : base(name)
    {}

    public Reflecting(string name, string explanation) : base(name, explanation)
    {}


    public string GetQuestion()
    {
        int questionNumber = randomGenerator.Next(_questionList.Count);
        string question = "";
        question = _questionList[questionNumber];

        return question;
    }

    public void HideQuestion(string toHide)
    {
        _hiddenQuestion = toHide;
        _hiddenList.Add(_hiddenQuestion);
        _questionList.Remove(_hiddenQuestion);
        if  (_questionList.Count == 0)
        {
            _questionList.AddRange(_hiddenList);
            _hiddenList.Clear();
        }
    }

    public void ReflectingExercise()
    {
        Welcome();
        _reflectTime = GetActivityLength();
        Console.Clear();
        Console.WriteLine("Get Ready...");
        SetSpinnerTime(5);
        Spinner();
        Console.WriteLine("\nConsider the following prompt:\n");
        string reflectingPrompt = GetPrompt(_promptList);
        Console.WriteLine($" --- {reflectingPrompt} ---\n");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        CountDown(5);
        Console.Clear();
        

        DateTime reflectingTimer = GetTime();
        while (DateTime.Now < reflectingTimer)
        {
            _question = GetQuestion();
            Console.WriteLine($"> {_question}");
            HideQuestion(_question);
            SetSpinnerTime(5);
            Spinner();
            
        }
        Congrats();




    }
}