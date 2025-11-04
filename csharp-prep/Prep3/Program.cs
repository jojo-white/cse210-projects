using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 101);

        string guessString;
        bool rightNumber = false;
        while (rightNumber == false)
        {
            Console.Write("Guess a number between 1 and 100: ");
            guessString = Console.ReadLine();
            int guess = int.Parse(guessString);
            if (guess > number)
            {
                Console.WriteLine("The number is lower.");
            }
            else if (guess < number)
            {
                Console.WriteLine("The number is higher.");
            }
            else
            {
                Console.Write($"You got it right! The number was {number}!");
                rightNumber = true;
            }
        }
    }
}