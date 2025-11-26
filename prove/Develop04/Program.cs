// using System;

class Program
{
    static void Main(string[] args)
    {
        bool exitProgram = false;
        // Activity a1 = new Activity();
        // Breathing b1 = new Breathing();
        
        
        
        
        while (!exitProgram)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("\t1. Start breathing activity");
            Console.WriteLine("\t2. Start reflecting activity");
            Console.WriteLine("\t3. Start listing activity");
            Console.WriteLine("\t4. Quit");
            Console.WriteLine("Select a choice from the menu: ");
            string answer = Console.ReadLine();
            int userChoice = int.Parse(answer);
        
            if (userChoice == 1)
            {
                Console.Clear();
                Breathing b1 = new Breathing("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. \nClear your mind and focus on your breathing.");                
                b1.BreathingExercise();


            }
            else if (userChoice == 2)
            {
                Console.Clear();
                Reflecting r1 = new Reflecting("Reflecting Activity", "This activity will help you refleect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.\n");
                r1.ReflectingExercise();
                // To exceed core requirements, I made it so the reflecting list would go through every item before repeating

            }
            else if (userChoice == 3)
            {
                Console.Clear();
                Listing l1 = new Listing("Listing Activity", "This activity will helpyou reflect on the good things in your life by having you list as many things as you can in a certain area.");
                l1.ListingExercise();
            }
            else if (userChoice == 4)
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
}