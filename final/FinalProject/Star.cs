public class Star : CelestialObj
{
    public const string ObjectType = "Star";
    public const string DistanceMeasurement = "kilometers";

    public Star(string text) : base(text)
    {}

    public Star(string objectName, float distance, bool isSphere, float angularSize1, string measureName, string measureNotation) : base(objectName, distance, isSphere, angularSize1, measureName, measureNotation)
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