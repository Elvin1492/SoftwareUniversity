using System;

class CalculateNfKf
{
    static void Main()
    
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        int factorial = 1;
        for (int i = n; i > k; i--)
        {
            factorial *= i;
        }
        Console.WriteLine(factorial);
    }
}
