using System.Runtime.CompilerServices;
using System.Text.Json;

public class ObjectList : List<CelestialObj>
{
    public ObjectList()
    {}


    
    public void SaveToFile(string fileName)
    {
        Console.WriteLine("Saving to file...");
        string file = fileName;

        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (CelestialObj c in this)
            {
                string text = c.AsString();
                outputFile.WriteLine(text);
            }
        }
    }

    public void LoadFromFile(string fileName)
    {
        Console.WriteLine("Reading from file...");

        using (StreamReader inputFile = new StreamReader(fileName))
        {
            while(!inputFile.EndOfStream)
            {
                string text = inputFile.ReadLine();
                
                CelestialObj c = CreateObj(text);
                
                this.Add(c);
            }
        }
    }

    private static CelestialObj CreateObj(string text)
    {
        string[] parts = text.Split("~~");
        switch(parts[0])
        {
            case Moon._objectType:
                return new Moon(text);
            case Planet.ObjectType:
                return new Planet(text);
            case Nebula.ObjectType:
                return new Nebula(text);
            case OpenStarClusters.ObjectType:
                return new OpenStarClusters(text);
            case GlobularStarClusters.ObjectType:
                return new GlobularStarClusters(text);
            case Star.ObjectType:
                return new Star(text);
            case Blackhole.ObjectType:
                return new Blackhole(text);
            case Galaxy.ObjectType:
                return new Galaxy(text);
            default:
                throw new NotImplementedException(parts[0]);
        }
    }

    public void DisplayObjects()
    {
        foreach (CelestialObj c in this)
        {
            string celestialObject = c.GetDisplayString();
            Console.WriteLine($"{celestialObject}");
            
        }
    }

    public void DisplayNoBlackHoles()
    {
        int objectCount = 1;
        foreach (CelestialObj c in this)
        {
            if (c is Blackhole)
            {
                objectCount++;
            }
            else
            {
                string celestalObject = c.GetDisplayString();
                Console.WriteLine($"{objectCount}. {celestalObject}");
                objectCount++;
            }
        }
    }

    public void DeleteObject(int index)
    {   
        CelestialObj objectIndex = this[index];
        string objectString = objectIndex.GetDisplayString();
        bool exitDelete = false;
        while(!exitDelete)
        {
            Console.WriteLine("This is the object you have chosen to delete.");
            Console.WriteLine(objectString);
            Console.Write("Are you sure you want to delete this object? (y/n) ");
            string deleteChoice = Console.ReadLine();
            if (deleteChoice == "y")
            {
                Console.WriteLine("Deleting object...");
                Thread.Sleep(1000);
                this.RemoveAt(index);
                Console.WriteLine("Object deleted.");
                Thread.Sleep(1500);
                exitDelete = true;
            }
            else if (deleteChoice == "n")
            {
                Console.WriteLine("Object will not be deleted.");
                Thread.Sleep(1500);
                exitDelete = true;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("That is not an option. Please Try again.");
                Thread.Sleep(1500);
                Console.Clear();
            }
        }

        

        
    }
}