using System;

class QudraticEquation
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b= double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());

        if (a == 0)
        {
            double x = -c / b;
            Console.WriteLine("x= {0}", x);
        }
        else
        {
            double discriminant = (b * b) - (4 * a * c);

            if (discriminant < 0)
            {
                Console.WriteLine("no real roots");
            }
            else if(discriminant == 0)
            {
                double x = (-b) / (2 * a);
                Console.WriteLine("x1=x2= {0}", x);
            }
            else if(discriminant > 0)
            {
                double x1 = ((-b + Math.Sqrt(discriminant)) /( 2 * a));
                double x2 = ((-b - Math.Sqrt(discriminant)) / (2 * a));
                Console.WriteLine("x1={0}; x2={1}", x1, x2);
            }
        }
    }
}
