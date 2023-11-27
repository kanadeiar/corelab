using System.Drawing;

namespace ConsoleApp1.DataObject;

public class Geometry
{
    private double pi = 3.14;

    public double Area(Object shape)
    {
        switch (shape)
        {
            case Square s:
                return s.Side * s.Side;
            case Rectangle r:
                return r.Height * r.Width;
            case Circle c:
                return pi * c.Radius * c.Radius;
            case Parallelogram p:
                return p.Side * p.Height;
        }
        throw new ArgumentOutOfRangeException(nameof(shape));
    }

    public double Perimeter(Object shape)
    {
        switch (shape)
        {
            case Square s:
                return s.Side * 4;
            case Rectangle r:
                return r.Height * 2 + r.Width * 2;
            case Circle c:
                return 2 * pi * c.Radius;
            case Parallelogram p:
                return 4 * p.Side;
        }
        throw new ArgumentOutOfRangeException(nameof(shape));
    }
}

public record struct Square(Point TopLeft, double Side);
public record struct Rectangle(Point TopLeft, double Height, double Width);
public record struct Circle(Point Center, double Radius);
public record struct Parallelogram(Point TopLeft, double Side, double Height);


public abstract class Shape
{
    public abstract double Area();
    public abstract double Perimeter();
}

public class CSquare : Shape
{
    private Point topLeft;
    private double side;

    public override double Area()
    {
        return side * side;
    }

    public override double Perimeter()
    {
        return side * 4;
    }
}

public class CRectangle : Shape
{
    private Point topLeft;
    private double height;
    private double width;

    public override double Area()
    {
        return height * width;
    }

    public override double Perimeter()
    {
        return height * 2 + width * 2;
    }
}

public class CCircle : Shape
{
    private double pi = 3.14;
    private Point center;
    private double radius;

    public override double Area()
    {
        return pi * radius * radius;
    }

    public override double Perimeter()
    {
        return pi * 2 * radius;
    }
}

public class CParallelogram : Shape
{
    private Point topLeft;
    private double side;
    private double height;

    public override double Area()
    {
        return side * height;
    }

    public override double Perimeter()
    {
        return side * 4;
    }
}
