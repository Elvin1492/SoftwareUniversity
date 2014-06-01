using System;

class TheBiggestOfThreeNumbers
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());

        double biggestNumber = 0;

         if( (a >= b && b >= c) || (a >= c && c >= b) )
        {       
            biggestNumber = a;
        }
        else if ( (b >= a && a >= c) || (b >= c && c >= a))
        {
            biggestNumber = b;
        }
        else if((c >= b && b >= a) || (c >=a && a >= b))
        {
            biggestNumber = c;
        }

        Console.WriteLine(biggestNumber);
    }
}

