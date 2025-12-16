public class Moon : CelestialObj
{
    public const string _objectType = "Moon";
    public const string _distanceMeasurement = "kilometers";

    public Moon(string text) : base(text)
    {}
    
    public Moon(string objectName, float distance, bool isSphere, float angularSize1, string measureName, string measureNotation) : base(objectName, distance, isSphere, angularSize1, measureName, measureNotation)
    {}

    public Moon(string objectName, float distance, bool isSphere, float angularSize1, float angularSize2, string measureName, string measureNotation) : base(objectName, distance, isSphere, angularSize1, angularSize2, measureName, measureNotation)
    {}


    public override void CalcBlackHole(double radius, double mass)
    {
        double radiusMeters = radius * 1000;
        double gravity = GetGravity();
        double lightSpeed = GetLight();
        string objectType = GetCelestialObjType();
        double schwarzRadius = 2 * gravity * mass / (lightSpeed * lightSpeed);
        if (schwarzRadius >= radiusMeters)
        {
            Console.WriteLine($"Your {objectType} is a black hole!");
            Console.WriteLine($"Your {objectType}'s radius is {radiusMeters} meters.");
            Console.WriteLine($"The schwarzchild radius is {schwarzRadius} meters.");
        }
        else if (schwarzRadius < radiusMeters)
        {
            Console.WriteLine($"Your {objectType} isn't a black hole :(");
            Console.WriteLine($"Your {objectType}'s radius is {radiusMeters} meters.");
            Console.WriteLine($"The schwarzchild radius is {schwarzRadius} meters.");
        }
    }

    public override string GetDistanceMeasurement()
    {
        return _distanceMeasurement;
    }

    public override string GetCelestialObjType()
    {
        return _objectType;
    }
    

}