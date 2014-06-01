using System;

class NullValuesArithmetics
{
    static void Main()
    {
        int? n = null;
        double? d = null;

        Console.WriteLine(n);
        Console.WriteLine(d);

        n = 5;
        d = 1.26704;
        Console.WriteLine(n);
        Console.WriteLine(d);


    }
}