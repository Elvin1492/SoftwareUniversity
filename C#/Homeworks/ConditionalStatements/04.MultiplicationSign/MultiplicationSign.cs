using System;

class MultiplicationSign
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());

        string result = null;
       
        if( a == 0 || b == 0 || c == 0)
        {
            result = "0";
        }
        else if (a > 0)
        {
            if ((b > 0 && c > 0) || (b < 0 && c < 0))
            {
                result = "+";
            } 
            else if ((b < 0 && c > 0) ||(b > 0 && c <0) )
            {
                result = "-";
            }
          
        }
        else if (a < 0)
        {
            if ((b > 0 && c < 0) || (b < 0 && c > 0))
            {
                result = "+";
            }
            else if ((b > 0 && c > 0) || (b < 0 && c < 0))
            {
                result = "-";
            }
        }
        Console.WriteLine(result);

    }
}

