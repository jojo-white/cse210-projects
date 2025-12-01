public class Circle : Shape
{
    private double _radius;

    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    public override double GetArea()
    {
        double r2 = Math.Pow(_radius, 2);
        double pi = Math.PI;
        double area = pi * r2;
        return area;
    }

    public override string GetShape()
    {
        return "Circle";
    }
}