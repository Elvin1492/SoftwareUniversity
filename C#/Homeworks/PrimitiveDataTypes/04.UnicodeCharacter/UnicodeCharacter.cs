using System;

class Program
{
    static void Main()
    {
        string hexValue = string.Format("{0:X}", 42);
        Console.WriteLine(hexValue);
        char symbol =  '\u002A';
        Console.WriteLine(symbol);
    }
}

