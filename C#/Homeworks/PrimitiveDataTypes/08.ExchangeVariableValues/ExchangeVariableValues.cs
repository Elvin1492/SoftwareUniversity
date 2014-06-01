using System;

class ExchangeVariableValues
{
    static void Main()
    {
        int a = 5;
        int b = 10;

        int exchagedA;
        int exchangeB;

        exchagedA = b;
        exchangeB = a;

        Console.WriteLine("{0} {1}", a, b);
        Console.WriteLine("{0} {1}", exchagedA, exchangeB);

    }
}

