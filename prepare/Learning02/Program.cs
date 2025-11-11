using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Microsoft";
        job1._jobTitle = "Software Developer";
        job1._startYear = 2024;
        job1._endYear = 2025;

        Job job2 = new Job();
        job2._company = "Apple";
        job2._jobTitle = "Manager";
        job2._startYear = 2020;
        job2._endYear = 2024;

        Resume resume1 = new Resume();

        resume1._name = "Joseph White";
        resume1._jobList.Add(job1);
        resume1._jobList.Add(job2);


        resume1.Display();
        // job1.Display();
        // job2.Display();


    }
}