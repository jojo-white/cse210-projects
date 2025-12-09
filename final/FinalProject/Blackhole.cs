public class Blackhole : CelestialObj
{

    public const string ObjectType = "Black hole";
    public const string DistanceMeasurement = "light years";

    public Blackhole(string text) : base(text)
    {}

    public Blackhole(string objectName, float distance, bool isSphere, float angularSize1, string measureName, string measureNotation) : base(objectName, distance, isSphere, angularSize1, measureName, measureNotation)
    {}

    public override string GetDistanceMeasurement()
    {
        return DistanceMeasurement;
    }

    public override string GetCelestialObjType()
    {
        return ObjectType;
    }
}