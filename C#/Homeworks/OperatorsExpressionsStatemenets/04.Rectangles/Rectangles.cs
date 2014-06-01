using System;

class Rectangles
{
    static void Main()
    {
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        double perimeter = 2 * (width + height);
        double area = width * height;

        Console.WriteLine("Perimeter: {0}", perimeter);
        Console.WriteLine("Area: {0}", area);

    }
}

