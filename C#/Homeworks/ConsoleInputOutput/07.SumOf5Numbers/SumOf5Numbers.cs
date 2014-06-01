using System;

class SumOf5Numbers
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        double sum = 0;

        for (int i = 0; i < input.Length; i++)
        {
            double n = double.Parse(input[i]);
            sum += n;
        }
        Console.WriteLine(sum);
    }
}

