public class Breathing : Activity
{
    private string _breathIn = "Breathe In";
    private string _breathOut = "Breathe Out";
    
    private int _breathTime;
    

    public Breathing() : base()
    {}

    public Breathing(string name) : base(name)
    {
       
    }

    public Breathing(string name, string explanation) : base(name, explanation)
    {}

    
    public void BreathingExercise()
    {

        Welcome();
        _breathTime = GetActivityLength();
        Console.Clear();
        Console.WriteLine("Get Ready...");
        SetSpinnerTime(5);
        Spinner();
        Console.WriteLine();

        DateTime breathingTimer = GetTime();
        while (DateTime.Now < breathingTimer)
        {
            Console.Write(_breathIn);
            for (int i = 5; i > 0; i--)
            {
                Console.Write(".");
                Thread.Sleep(1000);
                if (i == 1) Console.WriteLine();
            }
            Console.Write(_breathOut);
            for (int i = 5; i > 0; i--)
            {
                Console.Write(".");
                Thread.Sleep(1000);
                if (i == 1) Console.WriteLine();
            }
        } 
        Congrats();
    }
}