public class Nebula : CelestialObj
{
    public const string ObjectType = "Nebula";
    public const string DistanceMeasurement = "light years";

    public Nebula(string text) : base(text)
    {}

    public Nebula(string objectName, float distance, bool isSphere, float angularSize1, string measureName, string measureNotation) : base(objectName, distance, isSphere, angularSize1, measureName, measureNotation)
    {}

    public Nebula(string objectName, float distance, bool isSphere, float angularSize1, float angularSize2, string measureName, string measureNotation) : base(objectName, distance, isSphere, angularSize1, angularSize2, measureName, measureNotation)
    {}


    public override void CalcBlackHole(double radius, double mass)
    {
        double radiusMeters = radius * 9.461e+15;
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
        return DistanceMeasurement;
    }

    public override string GetCelestialObjType()
    {
        return ObjectType;
    }
}