using System;
using System.Linq;

    class RandomizeTheNumbers1toNBeta
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                numbers[i] = i + 1; 
            }

            Random range = new Random();
            numbers = numbers.OrderBy(t => range.Next()).ToArray();

            for (int i = 0; i < n; i++)
            {
                Console.Write(numbers[i] + " ");
            }
            
        }
    }

