public class Galaxy : CelestialObj
{
    public const string ObjectType = "Galaxy";
    public const string DistanceMeasurement = "light years";

    public Galaxy(string text) : base(text)
    {}

    public Galaxy(string objectName, float distance, bool isSphere, float angularSize1, string measureName, string measureNotation) : base(objectName, distance, isSphere, angularSize1, measureName, measureNotation)
    {}

    public Galaxy(string objectName, float distance, bool isSphere, float angularSize1, float angularSize2, string measureName, string measureNotation) : base(objectName, distance, isSphere, angularSize1, angularSize2, measureName, measureNotation)
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