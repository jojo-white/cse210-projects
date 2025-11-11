public class Job
{
    public string _company = "";
    public string _jobTitle = "";

    public int _startYear = -1;
    public int _endYear = -1;

    public Job()
    {
    }

   public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}