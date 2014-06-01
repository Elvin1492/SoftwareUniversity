using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int min = int.Parse(Console.ReadLine());
        int max = int.Parse(Console.ReadLine());

        Random range = new Random();
        for (int i = 0; i < n; i++)
        {
            Console.Write(range.Next(min, max) + " ");
        }
        
    }
}

