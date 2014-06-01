using System;

class ExchangeIfreater
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = a;

        if( a > b)
        {
            a = b;
            b = c;    
        }
        Console.WriteLine("{0} {1}", a,b);
    }
}

