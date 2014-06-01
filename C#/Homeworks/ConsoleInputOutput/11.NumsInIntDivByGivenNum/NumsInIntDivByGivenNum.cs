using System;

class NumsInIntDivByGivenNum
{
    static void Main()
    {
        int start = int.Parse(Console.ReadLine());
        int end = int.Parse(Console.ReadLine());

        int counter = 0;
        for (int i = start; i <= end; i++)
        {
            if( i % 5 == 0)
            {
                counter++;
            }
        }

        Console.WriteLine(counter);
    }
}
