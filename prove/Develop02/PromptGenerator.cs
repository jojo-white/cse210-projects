using System.Security.Cryptography;
using System;
public class PromptGenerator
{
    
    // Random Number Generator to pick random prompt
    private static Random randomGenerator = new Random();
    public PromptGenerator()
    {
    }

    

    public string PickPrompt()
    {
        
        
        // Array to store 10 prompts
        List<string> promptList = new List<string>{ "What was I grateful for today?", "What was one thing I accomplished today?", "What could I have done better today?", "What was something difficult that I did today?", "What did I learn today?", "What did I do as an act of service today?", "What makes me feel powerful?", "What do I love about myself?", "How did I see the hand of the Lord in my life today?", "What was the strongest emotion I felt today?" };

        
        
        int promptNumber = randomGenerator.Next(promptList.Count);

        string prompt = "";
        prompt = promptList[promptNumber];

        return prompt;

        //Console.WriteLine($"{promptList[promptNumber]}");
        

    }
}