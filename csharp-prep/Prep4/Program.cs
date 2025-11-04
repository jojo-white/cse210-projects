using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        List<int> numberList = new List<int>();
        bool repeatQuestion = true;
        int sum = 0;
        float avg;
        int largest = 0;

        while (repeatQuestion == true)
        {
            string numberString;
            Console.Write("Enter a number (enter 0 when you want to stop): ");
            numberString = Console.ReadLine();
            int number = int.Parse(numberString);
            numberList.Add(number);
            if (number == 0)
            {
                repeatQuestion = false;
                foreach (int numbers in numberList)
                {
                    sum = sum + numbers;
                }
                Console.WriteLine($"The sum is: {sum}");

                int listLength;
                listLength = numberList.Count;
                avg = ((float)sum) / listLength;
                
                Console.WriteLine($"The average is: {avg}");
                foreach (int bigNumber in numberList)
                {
                    if (bigNumber > largest)
                    {
                        largest = bigNumber;
                    }
                }
                Console.WriteLine($"The biggest number is: {largest}");
            }
        }
    }
}