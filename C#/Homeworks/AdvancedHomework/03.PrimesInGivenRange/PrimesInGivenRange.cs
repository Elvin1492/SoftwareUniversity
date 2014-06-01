using System;
using System.Collections.Generic;
using System.Linq;

class PrimesInGivenRange
{
//  static void Main()
//  {
//      Console.WriteLine("Enter a star number: ");
//      int n = int.Parse(Console.ReadLine());
//      Console.WriteLine("Enter an end number: ");
//      int m = int.Parse(Console.ReadLine());
//      primecheck(n, m);
//  } 
    //Define method to find prime numbers in range and return them in a list
    static void Main()
    {
        int startNumn = int.Parse(Console.ReadLine());
        int endNumm = int.Parse(Console.ReadLine());

        for (int i = startNumn; i <= endNumm; i++)
        {
            int divider = 2;
        int maxdivider = (int)Math.Sqrt(i);
            while (divider <= maxdivider)
            {
                if (i % divider == 0)
                {
                    break;
                }
                else if(i % divider != 0)
                {
                    Console.Write("{0}, ", i);
                    contin

                }           
            }
        }
    }
   
}
