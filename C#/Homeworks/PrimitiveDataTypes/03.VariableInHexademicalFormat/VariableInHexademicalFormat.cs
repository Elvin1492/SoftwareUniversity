using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        int n= int.Parse(Console.ReadLine());

        string hexValue = n.ToString("X");
        string hexValue2 = string.Format("{0:X}", n);
        int decValue = Convert.ToInt32(hexValue, 16);

        Console.WriteLine(n.ToString("X"));
        Console.WriteLine(string.Format("{0:X}", n));
        Console.WriteLine(Convert.ToInt32(hexValue, 16));
       
    }

        
}

