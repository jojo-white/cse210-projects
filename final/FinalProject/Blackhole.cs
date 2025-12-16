public class Blackhole : CelestialObj
{

    public const string _objectType = "Black hole";
    public const string _distanceMeasurement = "kilometers";

    public Blackhole(string text) : base(text)
    {}

    public Blackhole(string objectName, float distance, bool isSphere, float angularSize1, string measureName, string measureNotation) : base(objectName, distance, isSphere, angularSize1, measureName, measureNotation)
    {}

    public override string GetDistanceMeasurement()
    {
        return _distanceMeasurement;
    }

    public override string GetCelestialObjType()
    {
        return _objectType;
    }
}