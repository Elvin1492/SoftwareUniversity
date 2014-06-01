using System;
using System.Numerics;
using System.Linq;

class TrailingZeroesInNf
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        BigInteger factorial = 1;


        for (int i = 1; i <= n; i++)
        {
            factorial *= i;
        }
        int counter = 0;
        string factorialAsString = Convert.ToString(factorial);


        for (int i = factorialAsString.Length - 1; i > 0; i--)
        {
            if (factorialAsString[i] == '0')
            {
                counter++;
            }
            else if (factorialAsString[i] != '0')
            {
                break;
            }
        }
        Console.WriteLine(counter);

    }
}
