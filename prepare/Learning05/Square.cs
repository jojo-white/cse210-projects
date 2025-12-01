using System.Reflection.Metadata.Ecma335;

public class Square : Shape
{
    private double _side;
    

    public Square(string color, double side) : base(color)
    {
        _side = side;
    }

    public override double GetArea()
    {
        // To use exponents, use double variable = Math.Pow(base, exponent);
        double area = Math.Pow(_side, 2);
        return area;
    }

    public override string GetShape()
    {
        return "Square";
    }
}