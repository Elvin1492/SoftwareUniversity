using System;

class FormattingNumbers
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());

        string aBinary = Convert.ToString(a,2).PadLeft(10,'0');

        Console.WriteLine("|{0,-8:X}|{1}|{2,10:F2}|{3,-10:F3}|", a,aBinary,b,c);
    }
}

