using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        
        Scripture s = new Scripture("For God so loved the world, that he gave his only begotton Son, that whosoever believeth in him should not perish, but have everlasting life.");
        Reference r = new Reference("John", 3, 16);
        bool finished = false;

        while (s.WordsLeft() > 0 || !finished )
        {   
            finished = s.WordsLeft() == 0;
            Console.Clear(); // Clears terminal screen
            Console.Write($"{r.GetReference()} ");
            Console.WriteLine(s.GetScripture());
            Console.Write("To continue, press enter. To quit, type 'quit' then hit enter: ");
            string userChoice = Console.ReadLine();

            if (userChoice == "quit")
            {
                finished = true;
            }
            else
            {
                s.HideWord();
            }
            

        }

        
        
    }
}