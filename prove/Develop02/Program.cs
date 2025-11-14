using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {


        Console.WriteLine("Welcome to the Journaling Program!");
        bool exitProgram = false;
        Journal journal1 = new Journal();
        

        while (exitProgram == false)
        {
            Console.WriteLine("Choose an option given below:");
            Console.WriteLine("1. New Entry");
            Console.WriteLine("2. Display Journal");
            Console.WriteLine("3. Save Journal to File");
            Console.WriteLine("4. Load Journal from File");
            Console.WriteLine("5. Exit");
            Console.WriteLine("What would you like to do? ");
            string answer = Console.ReadLine();
            int userChoice = int.Parse(answer);
            
            
            if (userChoice == 1)
            {
                NewEntry(journal1);
            }
            else if (userChoice == 2)
            {
                journal1.Display();
            }
            else if (userChoice == 3)
            {
                Console.WriteLine("What is the name of the file to save to? ");
                string fileName = Console.ReadLine();
                journal1.SaveToFile(fileName);

            }
            else if (userChoice == 4)
            {
                Console.WriteLine("What is the name of the file to load? ");
                string fileName = Console.ReadLine();
                journal1 = Journal.ReadFromFile(fileName);
            }
            else if (userChoice == 5)
            {
                Console.WriteLine("Goodbye!");
                exitProgram = true;
            }
            
        }

        


    }

    private static void NewEntry(Journal journal1)
    {
        Console.WriteLine("Would you like a prompt (y/n)? ");
        string promptAnswer = Console.ReadLine();
        string journalPrompt = "";
        string journalEntry = "";
        PromptGenerator prompt = new PromptGenerator();

        if (promptAnswer == "y")
        {
            journalPrompt = prompt.PickPrompt();
            Console.WriteLine(journalPrompt);
            Console.Write("> ");
            journalEntry = Console.ReadLine();

            DateTime theCurrentTime = DateTime.Now;
            string dateText = theCurrentTime.ToShortDateString();

            Entry e = new Entry();
            e._entry = journalEntry;
            e._prompt = journalPrompt;
            e._currentTime = dateText;
            journal1._entryList.Add(e);

        }
        else if (promptAnswer == "n")
        {
            journalPrompt = "N/A";
            Console.Write("> ");
            journalEntry = Console.ReadLine();

            DateTime theCurrentTime = DateTime.Now;
            string dateText = theCurrentTime.ToShortDateString();

            Entry e = new Entry();
            e._entry = journalEntry;
            e._prompt = journalPrompt;
            e._currentTime = dateText;
            journal1._entryList.Add(e);
        }
        else
        {
            journalPrompt = "N/A";
            Console.WriteLine("That was not an available answer, so no prompt will be given. Please write your entry below.");
            Console.Write("> ");
            journalEntry = Console.ReadLine();
            DateTime theCurrentTime = DateTime.Now;
            string dateText = theCurrentTime.ToShortDateString();

            Entry e = new Entry();
            e._entry = journalEntry;
            e._prompt = journalPrompt;
            e._currentTime = dateText;
            journal1._entryList.Add(e);
        }

    }

}