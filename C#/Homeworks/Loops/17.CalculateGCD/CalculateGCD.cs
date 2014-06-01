using System;

class CalculateGCD
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        //Replace values of "a" and "b" if a < b
        int c = a;
        if(a < b)
        {
            a = b;
            b = c;
        }
        // dclare variable for the reminderand the GCD
        int remainder;
        int GCD;
        while (true)
        {
            remainder = a % b;
            if (remainder == 0)
            {
                GCD = b;
                break;
            }
            a = b;
            b = remainder;
        }
        if (GCD < 0)
        {
            GCD = -GCD;
        }
        Console.WriteLine(GCD);

    }
}

