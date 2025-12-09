public class GlobularStarClusters : CelestialObj
{
    public const string ObjectType = "Globular Star Cluster";
    public const string DistanceMeasurement = "light years";

    public GlobularStarClusters(string text) : base(text)
    {}

    public GlobularStarClusters(string objectName, float distance, bool isSphere, float angularSize1, string measureName, string measureNotation) : base(objectName, distance, isSphere, angularSize1, measureName, measureNotation)
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