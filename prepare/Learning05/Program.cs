using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("red", 4);
        Rectangle rect = new Rectangle("blue", 3, 4);
        Circle circle = new Circle("yellow", 5);

        List<Shape> shapes = new List<Shape> { square, rect, circle };

        foreach (Shape shape in shapes)
        {
            Console.WriteLine(shape.GetColor());
            Console.WriteLine(shape.GetArea());
        }

    }
}