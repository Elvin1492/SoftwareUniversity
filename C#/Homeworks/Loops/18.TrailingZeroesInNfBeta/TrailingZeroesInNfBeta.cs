using System;

    class TrailingZeroesInNfBeta
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            int five = 5;
            while (five < n)
            {
                counter += n / five;
                five *= 5;
            }
            Console.WriteLine(counter);
        }
    }

