using System;

class CirclePerimeterAndArea
{
    static void Main()
    {
        double r = double.Parse(Console.ReadLine());

        double perimter = 2 * Math.PI * r;
        double area = Math.PI * Math.Pow(r, 2);
        Console.WriteLine("Perimeter: {0:0.00}", perimter);
        Console.WriteLine("Area: {0:0.00}",area);
    }
}

