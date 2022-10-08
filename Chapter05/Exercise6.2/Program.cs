using static System.Console;

namespace Exercise62
{

    public class Shape
    {
        public double Height;
        public double Width;
        public double Area;
    }
    public class Rectangle : Shape
    {
        public Rectangle(double height, double width)
        {
        Height = height;
        Width = width;
        Area = height * width;
        }
    }
    public class Square : Shape
    {
        public Square(double side)
        {
            Height = side;
            Width = side;
            Area = side * side;
        }
    }
    public class Circle : Shape
    {
        public Circle(double radius)
        {
            Height = radius;
            Width = radius;
            Area = Math.PI * radius * radius;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var r = new Rectangle(3, 4.5);
            WriteLine($"Rectangle H: {r.Height}, W: {r.Width}, Area: {r.Area}");
            var s = new Square(5);
            WriteLine($"Square H: {s.Height}, W: {s.Width}, Area: {s.Area}");
            var c = new Circle(2.5);
            WriteLine($"Circle H: {c.Height}, W: {c.Width}, Area: {c.Area}");
        }
    }
}
