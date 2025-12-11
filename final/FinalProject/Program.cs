using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello FinalProject World!");

        bool exitProgram = false;
        
        ObjectList objList = new ObjectList();

        Console.Clear();

        while (!exitProgram)
        {
            
            Console.WriteLine();
            Console.WriteLine("Menu options:");
            Console.WriteLine("\t1. Calculate Approximate Size of Celestial Object");
            Console.WriteLine("\t2. Calculate if an Object is a Black Hole");
            Console.WriteLine("\t3. List Celestial Objects");
            Console.WriteLine("\t4. Save Celestial Objects to File");
            Console.WriteLine("\t5. Load Celestial Objects from File");
            Console.WriteLine("\t6. Delete Celestial Object from List");
            Console.WriteLine("\t7. Quit");
            Console.Write("Select a choice from the menu: ");
            int programAnswer = int.Parse(Console.ReadLine());            

            switch(programAnswer)
            {
                case 1:
                    Console.Clear();

                    Console.WriteLine("The types of objects you can calculate are:");
                    Console.WriteLine("\t1. Moons");
                    Console.WriteLine("\t2. Planets");
                    Console.WriteLine("\t3. Nebulas");
                    Console.WriteLine("\t4. Open Star Clusters");
                    Console.WriteLine("\t5. Globular Star Clusters");
                    Console.WriteLine("\t6. Stars");
                    Console.WriteLine("\t7. Black Holes (by event horizon)");
                    Console.WriteLine("\t8. Galaxies");
                    Console.WriteLine("\t9. Go back");
                    Console.Write("Which type of object would you like to calculate the size of? ");
                    int objectAnswer = int.Parse(Console.ReadLine());
                    string objectType = GetObjectType(objectAnswer);
                    string distanceType = GetDistanceType(objectAnswer);
                    Console.Clear();

                    Console.Write($"How far, in {distanceType} (you can use decimals), is your {objectType}? ");
                    float distance = float.Parse(Console.ReadLine());

                    string measureName = "";
                    string measureNotation = "";


                    bool exitMeasureType = false;
                    while (!exitMeasureType)
                    {
                        Console.Write("Are you measuring in degrees (d), arcminutes (m), or arcseconds (s)? ");
                        string measureType = Console.ReadLine();
                    
                        if (measureType == "d")
                        {
                            measureName = "degrees";
                            measureNotation = "°";
                            exitMeasureType = true;
                        }
                        else if (measureType == "m")
                        {
                            measureName = "arcminutes";  
                            measureNotation = "\'";
                            exitMeasureType = true;
                        }
                        else if (measureType == "s")
                        {
                            measureName = "arcseconds";
                            measureNotation = "\"\"";
                            exitMeasureType = true;
                        }
                        else
                        {
                            exitMeasureType = false;
                            Console.WriteLine();
                            Console.WriteLine("That is not an option. Please Try again.");
                            Thread.Sleep(1500);
                            Console.Clear();
                        }  
                    }

                    bool isSphere = SeeIfSphere(objectAnswer, objectType);

                    switch(objectAnswer)
                    {
                        default:
                            float angularLength;
                            float longAngularLength;
                            float shortAngularLength;
                            Console.WriteLine();
                            Console.WriteLine("That is not an option. Please Try again.");
                            Thread.Sleep(1500);
                            Console.Clear();
                            break;
                        case 1:
                            
                            if (!isSphere)
                            {
                                Console.Write($"What is the angular length (you can use decimals) of your {objectType} at it's longest in {measureName}? ");
                                longAngularLength = float.Parse(Console.ReadLine());

                                Console.Write($"What is the angular length (you can use decimals) of your {objectType} at it's shortest in {measureName}? ");
                                shortAngularLength = float.Parse(Console.ReadLine());

                                Moon mObj = new Moon(objectType, distance, isSphere, longAngularLength, shortAngularLength, measureName, measureNotation);

                                double moonLongLength = mObj.CalcLongDimension(distance, longAngularLength, measureName);
                                string moonLongDecimal = moonLongLength.ToString("F3");
                                double moonShortLength = mObj.CalcShortDimension(distance, shortAngularLength, measureName);
                                string moonShortDecimal = moonShortLength.ToString("F3");

                                mObj.SetLongSize(moonLongLength);
                                mObj.SetShortSize(moonShortLength);
                                objList.Add(mObj);

                                Console.WriteLine();
                                Console.WriteLine($"Your moon is approximately {moonLongDecimal} kilometers by {moonShortDecimal} kilometers across!");
                                Thread.Sleep(2000);
                            }
                            else if (isSphere)
                            {
                                Console.Write($"What is the angular length, or diameter (you can use decimals), of your {objectType} in {measureName}? ");
                                angularLength = float.Parse(Console.ReadLine());

                                Moon mObj = new Moon(objectType, distance, isSphere, angularLength, measureName, measureNotation);
                                

                                double moonSize = mObj.CalcSphere(distance, angularLength, measureName);
                                string moonDecimal = moonSize.ToString("F3");

                                mObj.SetLongSize(moonSize);
                                objList.Add(mObj);

                                Console.WriteLine();
                                Console.WriteLine($"Your moon has a {moonDecimal} kilometer long diameter!");
                                Thread.Sleep(2000);
                            }
                            
                            break;
                        case 2:
                            float millionKilometers = distance * 1000000;
                            Console.Write($"What is the angular length, or diameter (you can use decimals), of your {objectType} in {measureName}? ");
                            angularLength = float.Parse(Console.ReadLine());

                            Planet pObj = new Planet(objectType, distance, isSphere, angularLength, measureName, measureNotation);

                            double planetSize = pObj.CalcSphere(millionKilometers, angularLength, measureName);
                            string planetDecimal = planetSize.ToString("F3");

                            pObj.SetLongSize(planetSize);
                            objList.Add(pObj);

                            Console.WriteLine($"Your planet has a {planetDecimal} kilometer long diameter!");
                            Thread.Sleep(2000);
                            break;
                        case 3:
                            double lightToKilometers = distance * 9.461e+12;
                            if (!isSphere)
                            {
                                Console.Write($"What is the angular length (you can use decimals) of your {objectType} at it's longest in {measureName}? ");
                                longAngularLength = float.Parse(Console.ReadLine());

                                Console.Write($"What is the angular length (you can use decimals) of your {objectType} at it's shortest in {measureName}? ");
                                shortAngularLength = float.Parse(Console.ReadLine());

                                Nebula nObj = new Nebula(objectType, distance, isSphere, longAngularLength, shortAngularLength, measureName, measureNotation);

                                double nebulaLongLength = nObj.CalcLongDimension(lightToKilometers, longAngularLength, measureName);
                                double nebulaLongLight = nebulaLongLength / 9.461e+12;
                                string nebulaLongDecimal = nebulaLongLight.ToString("F3");
                                double nebulaShortLength = nObj.CalcShortDimension(lightToKilometers, shortAngularLength, measureName);
                                double nebulaShortLight = nebulaShortLength / 9.461e+12;
                                string nebulaShortDecimal = nebulaShortLight.ToString("F3");

                                nObj.SetLongSize(nebulaLongLength);
                                nObj.SetShortSize(nebulaShortLength);
                                objList.Add(nObj);

                                Console.WriteLine();
                                Console.WriteLine($"Your nebula is approximately {nebulaLongDecimal} light years by {nebulaShortDecimal} light years across!");
                                Thread.Sleep(2000);
                            }
                            else if (isSphere)
                            {
                                Console.Write($"What is the angular length, or diameter (you can use decimals), of your {objectType} in {measureName}? ");
                                angularLength = float.Parse(Console.ReadLine());

                                Nebula nObj = new Nebula(objectType, distance, isSphere, angularLength, measureName, measureNotation);

                                double nebulaSize = nObj.CalcSphere(lightToKilometers, angularLength, measureName);
                                double nebulaLight = nebulaSize / 9.461e+12;
                                string nebulaDecimal = nebulaLight.ToString("F3");

                                nObj.SetLongSize(nebulaSize);
                                objList.Add(nObj);

                                Console.WriteLine($"Your nebula has a {nebulaDecimal} light year long diameter!");
                                Thread.Sleep(2000);
                            }
                            Console.Clear();
                            break;
                        case 4:
                            Console.Clear();
                            break;
                        case 5:
                            Console.Clear();
                            break;
                        case 6:
                            Console.Clear();
                            break;
                        case 7:
                            Console.Clear();
                            break;
                        case 8:
                            Console.Clear();
                            break;
                        case 9:
                            Console.Clear();
                            break;

                        
                    }                    

                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Your current Celestial Objects are:");
                    objList.DisplayNoBlackHoles();
                    Console.Write("Which object did you want to see turn into a black hole? ");
                    string holeChoice = Console.ReadLine();
                    int blackHole = int.Parse(holeChoice) - 1;
                    Console.Clear();
                    
                    bool exitBlackHole = false;
                    while (!exitBlackHole)
                    {
                        if (blackHole >= 0 && blackHole < objList.Count)
                        {
                            exitBlackHole = true;
                            CelestialObj objChoice = objList[blackHole];
                            objectType = objChoice.GetCelestialObjType();
                            double radius = objChoice.GetLongSize() / 2;
                            
                            Console.WriteLine("An object will become a black hole when it has been \ncompressed past its schwarzschild radius.");
                            Console.WriteLine("For context: The sun in our solar system has a mass of 1.989 x 10^30 kg. That's 30 zeros. \nThe sun has a radius of 695,700 kilometers, \n and a schwarzschild radius of 3 kilometers.");
                            Console.Write($"What is the mass of your {objectType} in kg? (really hammer on the zeros!) ");
                            double mass = double.Parse(Console.ReadLine());
                            objChoice.CalcBlackHole(radius, mass);

                        }
                    }

                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine();
                    objList.DisplayObjects();
                    break;
                case 4:
                    Console.WriteLine();
                    Console.Write("What is the name of the file you want to save to? ");
                    string fileChoice = Console.ReadLine();
                    Console.Clear();
                    objList.SaveToFile(fileChoice);
                    
                    break;
                case 5:
                    Console.WriteLine();
                    Console.Write("What is the name of the file you want to load? ");
                    fileChoice = Console.ReadLine();
                    Console.Clear();
                    objList.LoadFromFile(fileChoice);
                    
                    break;
                case 6:
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Your current Celestial Objects are:");
                    objList.DisplayObjects();
                    Console.WriteLine("\nType 'quit' to exit.");
                    Console.Write("Which object did you want to delete? ");
                    string deleteChoice = Console.ReadLine();
                    int delete = int.Parse(deleteChoice) - 1;

                    bool exitDelete = false;
                    while (!exitDelete)
                    {
                        if (deleteChoice == "quit")
                        {
                            Console.Clear();
                            exitDelete = true;
                        }
                        else if (delete >= 0 && delete < objList.Count)
                        {
                            exitDelete = true;
                            objList.DeleteObject(delete);
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("That is not an option. Please Try again.");
                            Thread.Sleep(1500);
                            Console.Clear();
                        }
                    }
                    
                    break;
                case 7:
                    Console.Clear();
                    exitProgram = true;
                    Console.WriteLine("Goodbye! Have a nice day!");
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("That is not an option. Please Try again.");
                    Thread.Sleep(1500);
                    Console.Clear();
                    break;
            }

        }
    }

    private static string GetObjectType(int choice)
    {
        switch(choice)
        {
            case 1:
                return "moon";
            case 2:
                return "planet";
            case 3:
                return "nebula";
            case 4:
                return "open star cluster";
            case 5:
                return "globular star cluster";
            case 6:
                return "star";
            case 7:
                return "black hole";
            case 8:
                return "galaxy";
            default:
                return "";
        }
    }

    private static string GetDistanceType(int choice)
    {
        switch(choice)
        {
            case 1:
                return "kilometers";
            case 2:
                return "millions of kilometers";
            case 3:
                return "light years";
            case 4:
                return "light years";
            case 5:
                return "thousands of light years";
            case 6:
                return "light years";
            case 7:
                return "light years";
            case 8:
                return "millions of light years";
            default:
                return "";
        }
    }
    private static bool SeeIfSphere(int userChoice, string objectName)
    {
        bool isSphere = false;
        // Planets (2), Globular Star Clusters (5), Stars (6), and Black Hole event horizons (7) are always spheres, while Open Star Clusters (4) are always NOT spheres, so this will determine if we need to ask if their object is spherical or not
        if (userChoice == 2 || userChoice == 5 || userChoice == 6 || userChoice == 7)
        {
            Console.WriteLine($"Your {objectName} is always going to be a sphere.");
            isSphere = true;
        }
        else if (userChoice == 4)
        {
            Console.WriteLine($"Your {objectName} is always going to NOT be a sphere.");
            isSphere = false;
        }
        else
        {
            
            bool exitSphereAnswer = false;

            while (!exitSphereAnswer)
            {
                Console.WriteLine("Does your object appear spherical or irregular in the sky?");
                Console.WriteLine("Choose spherical if your object appears like a circle. (s)\nChoose irregular if your object doesn't appear like a circle. (i)");
                string sphereAnswer = Console.ReadLine();
                if (sphereAnswer == "s")
                {
                    isSphere = true;
                    exitSphereAnswer = true;
                }
                else if (sphereAnswer == "i")
                {
                    isSphere = false;
                    exitSphereAnswer = true;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("That is not an option. Please Try again.");
                    Thread.Sleep(1500);
                    Console.Clear();
                    exitSphereAnswer = false;
                }
            }
        }

        
        return isSphere;
    }

}