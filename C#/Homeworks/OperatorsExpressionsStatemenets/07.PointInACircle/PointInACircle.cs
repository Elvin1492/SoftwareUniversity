using System;

class Program
{
    static void Main()
    {
        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());

        bool inside = true;
        if( x * x + y * y <= 4)
        {
            Console.WriteLine(inside);
        }
        else
        {
            inside = false;
            Console.WriteLine(inside);
        }

    }
}

