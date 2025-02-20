using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        List<Shape> shapes = new List<Shape>();

        Square square = new Square("Red", 4);
        shapes.Add(square);

        Rectangle rectangle = new Rectangle("Blue", 5, 6);
        shapes.Add(rectangle);

        Circle circle = new Circle("Green", 3);
        shapes.Add(circle);

        foreach (var shape in shapes)
        {
            Console.WriteLine($"Color: {shape.Color}, Area: {shape.GetArea()}");
        }
    }
}
