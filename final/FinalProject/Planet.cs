public class Planet : CelestialObj
{
    public const string ObjectType = "Planet";
    public const string DistanceMeasurement = "kilometers";

    public Planet(string text) : base(text)
    {}

    public Planet(string objectName, float distance, bool isSphere, float angularSize1, string measureName, string measureNotation) : base(objectName, distance, isSphere, angularSize1, measureName, measureNotation)
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
            Console.WriteLine($"The schwarzchild radius is {schwarzRadius} kilometers.");
        }
        else if (schwarzRadius < radiusMeters)
        {
            Console.WriteLine($"Your {objectType} isn't a black hole :(");
            Console.WriteLine($"Your {objectType}'s radius is {radiusMeters} meters.");
            Console.WriteLine($"The schwarzchild radius is {schwarzRadius} kilometers.");
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