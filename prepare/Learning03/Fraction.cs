public class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    public Fraction(int numerator)
    {
        _top = numerator;
        _bottom = 1;
    }

    public Fraction(int numerator, int denominator)
    {
        _top = numerator;
        _bottom = denominator;
    }

    public string GetFraction()
    {
        string number = $"{_top}/{_bottom}";
        return number;
    }

    public double GetDecimal()
    {
        return (double)_top / (double)_bottom;
    }
}