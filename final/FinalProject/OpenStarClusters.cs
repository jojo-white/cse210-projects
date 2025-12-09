public class OpenStarClusters : CelestialObj
{
    public const string ObjectType = "Open Star Cluster";
    public const string DistanceMeasurement = "light years";

    public OpenStarClusters(string text) : base(text)
    {}

    public OpenStarClusters(string objectName, float distance, bool isSphere, float angularSize1, float angularSize2, string measureName, string measureNotation) : base(objectName, distance, isSphere, angularSize1, angularSize2, measureName, measureNotation)
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