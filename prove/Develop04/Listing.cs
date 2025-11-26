public class Listing : Activity
{

    
    private List<string> _promptList = new List<string>{"Who are people you appreciate?", "What are personal strengths of yours?", "Who are people that you have helped this week?", "When have you felt the Holy Ghost this month?", "Who are some of your personal heroes?"};
    
    private int _listTime;

    public Listing() : base()
    {}

    public Listing(string name) : base(name)
    {}
    
    public Listing(string name, string explanation) : base(name, explanation)
    {}

    public void ListingExercise()
    {
        Welcome();
        _listTime = GetActivityLength();
        Console.Clear();
        Console.WriteLine("Get Ready...");
        SetSpinnerTime(5);
        Spinner();
        Console.WriteLine("\nList as many responses as you can to the following prompt:");
        string listingPrompt = GetPrompt(_promptList);
        Console.WriteLine($" --- {listingPrompt} ---\n");
        Console.Write("You may begin in: ");
        CountDown(5);
        Console.WriteLine();
        int listingCount = 0;
        DateTime listingTimer = GetTime();
        while (DateTime.Now < listingTimer)
        {
            Console.Write("> ");
            string listing = Console.ReadLine();
            listingCount++;
        }
        Console.WriteLine($"You listed {listingCount} items!\n");
        Congrats();



    }

}