using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage (just type the number)? ");
        string gradeString = Console.ReadLine();

        int grade = int.Parse(gradeString);
        string letter = "x";
        if (grade >= 90 && grade <= 100)
        {
            letter = "A";
        }
        else if (grade < 90 && grade >= 80)
        {
            letter = "B";
        }
        else if (grade < 80 && grade >= 70)
        {
            letter = "C";
        }
        else if (grade < 70 && grade >= 60)
        {
            letter = "D";
        }
        else if (grade > 100)
        {
            letter = "N/A";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"You earned the grade: {letter}");

        if (grade <= 100 && grade >= 70)
        {
            Console.WriteLine("Congrats! You passed!");
        }
        else if (grade > 100)
        {
            Console.WriteLine("You can't have a grade higher than 100%... You cheater...");
        }
        else
        {
            Console.WriteLine("I'm sorry, you didn't pass the class...");
        }
        // A >= 90
        // B >= 80
        // C >= 70
        // D >= 60
        // F < 60
    }
}