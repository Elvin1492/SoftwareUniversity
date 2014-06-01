using System;

class FibonaciNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int previous = -1;
        int next = 1;

        for (int i = 0; i < n; i++)
        {
            int sum = next + previous;
            previous = next;
            next = sum;
            Console.Write(next + " ");
        }

        Console.WriteLine();

    }
}

