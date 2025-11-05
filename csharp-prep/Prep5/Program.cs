using System;

class Program
{

    public static void Main(string[] args)
    {
        EntryMessage();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();

        int userYear;
        PromptUserBirthYear(out userYear);

        int squaredNumber = SquareNumber(userNumber);

        DisplayResult(userName, squaredNumber, userYear);

    }

    static void EntryMessage()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("What is your first and last name? ");
        string userName = Console.ReadLine();
        return userName;
    }
    static int PromptUserNumber()
    {
        string numberString;
        Console.Write("What is your favorite number? ");
        numberString = Console.ReadLine();
        int userNumber = int.Parse(numberString);
        return userNumber;
    }

    static void PromptUserBirthYear(out int userYear)
    {
        Console.Write($"What year were you born? ");
        userYear = int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int userNumber)
    {
        int square = userNumber * userNumber;
        return square;
    }
    static void DisplayResult(string userName, int userSquare, int userYear)
    {
        Console.WriteLine($"Hello {userName}! The square of your number is... {userSquare}!");
        Console.WriteLine($"{userName} is turning {2025 - userYear} years old this year!");
    }
}