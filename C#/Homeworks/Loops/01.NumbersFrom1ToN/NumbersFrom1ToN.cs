using System;

class NumbersFrom1ToN
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        //With a while loop
        int counter = 1;
        while(counter <= n)
        {
            Console.Write("{0} ", counter);
            counter++;
        }
        Console.WriteLine();
        //whit a while do loop
        int counter2 = 1;
        do
        {
            Console.Write("{0} ", counter2);
            counter2++;
        } while (counter2 <= n);
        Console.WriteLine();
        //whith a for loop

        for (int i = 1; i <= n; i++)
        {
            Console.Write("{0} ", i);
        }
        Console.WriteLine();
    }
}

