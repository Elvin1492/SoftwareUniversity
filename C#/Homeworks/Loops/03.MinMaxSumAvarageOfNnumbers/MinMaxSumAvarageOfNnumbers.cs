using System;
using System.Linq;

class MinMaxSumAvarageOfNnumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];
        for (int i = 0; i < n; i++)
        {           
            numbers[i] = int.Parse(Console.ReadLine());              
        }
        Console.WriteLine("Max: " + numbers.Max());
        Console.WriteLine("Min: " + numbers.Min());
        Console.WriteLine("Sum: " + numbers.Sum());
        Console.WriteLine("Avarage: {0:0.00}", numbers.Average());
    }
}

