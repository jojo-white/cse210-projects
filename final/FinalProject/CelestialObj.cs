public abstract class CelestialObj
{
    private string _objectName = "";
    private float _distance;
    private float _longAngularLength;
    private float _shortAngularLength;
    private string _measureName = "";
    private string _measureNotation = "";
    private double _longSize;
    private double _shortSize;
    private bool _isSphere;
    private const double _gravity = 0.000000000066743; // in m^3 per kg^-1 per s^-2
    private const double _lightSpeed = 299792458; // in m/s

    public CelestialObj(string text)
    {
        string[] parts = text.Split("~~");
        bool sphere = (parts[1] == "sphere");
        if (sphere)
        {
            InitOneSize(parts[0], float.Parse(parts[2]), float.Parse(parts[5]), sphere);
            SetMeasureType(parts[6], parts[7]);
            SetLongSize(double.Parse(parts[3]));
        }
        else if (!sphere)
        {
            InitTwoSizes(parts[0], float.Parse(parts[2]), float.Parse(parts[6]), float.Parse(parts[7]), sphere);
            SetMeasureType(parts[8], parts[9]);
            SetLongSize(double.Parse(parts[3]));
            SetShortSize(double.Parse(parts[4]));
        }

    }
    public CelestialObj(string objectName, float distance, bool isSphere, float longAngularLength, string measureName, string measureNotation)
    {
        InitOneSize(objectName, distance, longAngularLength, isSphere);
        SetMeasureType(measureName, measureNotation);
    }

    public CelestialObj(string objectName, float distance, bool isSphere, float longAngularLength, float shortAngularLength, string measureName, string measureNotation)
    {
        InitTwoSizes(objectName, distance, longAngularLength, shortAngularLength, isSphere);
        SetMeasureType(measureName, measureNotation);
    }

    private void SetMeasureType(string measureName, string measureNotation)
    {
        _measureName = measureName;
        _measureNotation = measureNotation;
    }

    private void InitOneSize(string objectName, float distance, float longAngularLength, bool isSphere)
    {
        _objectName = objectName;
        _distance = distance;
        _longAngularLength = longAngularLength;
        _isSphere = isSphere;
    }

    private void InitTwoSizes(string objectName, float distance, float longAngularLength, float shortAngularLength, bool isSphere)
    {
        _objectName = objectName;
        _distance = distance;
        _longAngularLength = longAngularLength;
        _shortAngularLength = shortAngularLength;
        _isSphere = isSphere;
    }


    public string AsString()
    {
        string objectFile = CreateDelimitedString("~~");
        return objectFile;
    }

    public virtual string CreateDelimitedString(string delimiter)
    {
        string objectName = GetCelestialObjType();
        bool isSphere = GetBoolSphere();
        string sphere = ShowSphere();

        float distance = GetDistance();
        double longSize = GetLongSize();
        double shortSize = GetShortSize();
        string distanceMeasurement = GetDistanceMeasurement();

        float longAngularLength = GetLongAngularLength();
        float shortAngularLength = GetShortAngularLength();
        string measureName = GetMeasureName();
        string measureNotation = GetMeasureNotation();
        
        if (isSphere)
        {
            string result = $"{objectName}{delimiter}{sphere}{delimiter}{distance}{delimiter}{longSize}{delimiter}{distanceMeasurement}{delimiter}{longAngularLength}{delimiter}{measureName}{delimiter}{measureNotation}";
            return result;
        }
        else if (!isSphere)
        {
            string result = $"{objectName}{delimiter}{sphere}{delimiter}{distance}{delimiter}{longSize}{delimiter}{shortSize}{delimiter}{distanceMeasurement}{delimiter}{longAngularLength}{delimiter}{shortAngularLength}{delimiter}{measureName}{delimiter}{measureNotation}";
            return result;
        }
        else return "";
    }
    
    public virtual string GetDisplayString()
    {
        bool sphere = GetBoolSphere();
        string objToSplit = CreateDelimitedString("~~");
        string[] parts = objToSplit.Split("~~");
        if (sphere)
        {
            double diameterValue = double.Parse(parts[3]);
            string diameter = diameterValue.ToString("F3");
            string objectDisplay = $"{parts[0]}: {diameter} {parts[4]} long diameter, is {parts[1]} shaped";
            return objectDisplay;
        }
        else if (!sphere)
        {
            double longValue = double.Parse(parts[3]);
            string longString = longValue.ToString("F3");
            double shortValue = double.Parse(parts[4]);
            string shortString = shortValue.ToString("F3");
            string objectDisplay = $"{parts[0]}: {longString} {parts[5]} long by {shortString} {parts[5]} wide, is {parts[1]} shaped";
            return objectDisplay;
        }
        else return "";
    }
    public abstract string GetDistanceMeasurement();
    public abstract string GetCelestialObjType();

    public double CalcSphere(double distance, double angularLength, string measureName)
    {
        double pi = Math.PI;
        
        if (measureName == "degrees")
        {
            double radians = angularLength * (pi / 180);
            double diameter = radians * distance;
            return diameter;
        }
        else if (measureName == "arcminutes")
        {
            double minute = angularLength / 60;
            double radians = minute * (pi / 180);
            double diameter = radians * distance;
            return diameter;
        }
        else if (measureName == "arcseconds")
        {
            double radians = angularLength / 206265;
            double diameter = radians * distance;
            return diameter;
        }
        else
        {
            return 0;
        }
        
    }

    public double CalcLongDimension(double distance, float longAngularLength, string measureName)
    {
        double pi = Math.PI;
        
        if (measureName == "degrees")
        {
            double longLength = longAngularLength * (2 * pi) * distance / 360;
            return longLength;
        }
        else if (measureName == "arcminutes")
        {
            float minute = longAngularLength / 60;
            double longLength = minute * (2 * pi) * distance / 360;
            return longLength;
        }
        else if (measureName == "arcseconds")
        {
            double longLength = longAngularLength * distance / 206265;
            return longLength;
        }
        else
        {
            return 0;
        }
    }

    public double CalcShortDimension(double distance, float shortAngularLength, string measureName)
    {
        double pi = Math.PI;
        
        if (measureName == "degrees")
        {
            double shortLength = shortAngularLength * (2 * pi) * distance / 360;
            return shortLength;
        }
        else if (measureName == "arcminutes")
        {
            float minute = shortAngularLength / 60;
            double shortLength = minute * (2 * pi) * distance / 360;
            return shortLength;
        }
        else if (measureName == "arcseconds")
        {
            double shortLength = shortAngularLength * distance / 206265;
            return shortLength;
        }
        else
        {
            return 0;
        }
    }
    
    public virtual void CalcBlackHole(double radius, double mass)
    {}






    public double GetLight()
    {
        return _lightSpeed;
    }
    public double GetGravity()
    {
        return _gravity;
    }
    public string GetObjectName()
    {
        return _objectName;
    }
    public float GetDistance()
    {
        return _distance;
    }
    public float GetLongAngularLength()
    {
        return _longAngularLength;
    }
    public float GetShortAngularLength()
    {
        return _shortAngularLength;
    }
    public string GetMeasureName()
    {
        return _measureName;
    }
    public string GetMeasureNotation()
    {
        return _measureNotation;
    }
    public double GetLongSize()
    {
        return _longSize;
    }
    public void SetLongSize(double longSize)
    {
        _longSize = longSize;
    }
    public double GetShortSize()
    {
        return _shortSize;
    }
    public void SetShortSize(double shortSize)
    {
        _shortSize = shortSize;
    }

    public void SetBoolSphere(bool isSphere)
    {
        _isSphere = isSphere;
    }
    public bool GetBoolSphere()
    {
        return _isSphere;
    }
    public string ShowSphere()
    {
        if (_isSphere) return "sphere";
        else return "irregular";
    }


}