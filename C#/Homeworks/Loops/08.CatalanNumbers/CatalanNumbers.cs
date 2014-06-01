using System;
using System.Numerics;

class CatalanNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        BigInteger nomerator = 1;
        BigInteger denominator = 1;
        for (int i = 2 * n ; i > n + 1; i--)
        {
            nomerator *= i;
        }
        for (int j =  1; j <= n; j++)
        {
            denominator *= j;
        }
        Console.WriteLine(nomerator/denominator);
    }
}

