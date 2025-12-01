using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Learning05 World!");
        
        //Square square = new Square("Green", 3);
        //string sColor = square.GetColor();
        //double sArea = square.GetArea();
        //Console.WriteLine($"The color of the square is {sColor} and the area is {sArea}");
        //
        //Rectangle rectangle = new Rectangle("Blue", 2, 4);
        //string rColor = rectangle.GetColor();
        //double rArea = rectangle.GetArea();
        //Console.WriteLine($"The color of the rectangle is {rColor} and the area of the rectangle is {rArea}");
        //
        //Circle circle = new Circle("Red", 4);
        //string cColor = circle.GetColor();
        //double cArea = circle.GetArea();
        //Console.WriteLine($"The color of the circle is {cColor} and the area of the circcle is {cArea}");

        List<Shape> shapes = new List<Shape>();

        Square s1 = new Square("Green", 3);
        shapes.Add(s1);

        Rectangle r1 = new Rectangle("Blue", 2, 4);
        shapes.Add(r1);

        Circle c1 = new Circle("Red", 4);
        shapes.Add(c1);

        foreach (Shape shape in shapes)
        {
            string shapeName = shape.GetShape();
            string shapeColor = shape.GetColor();
            double shapeArea = shape.GetArea();
            Console.WriteLine($"Your {shapeName} is {shapeColor} and has an area of {shapeArea}");
        }
    }
}