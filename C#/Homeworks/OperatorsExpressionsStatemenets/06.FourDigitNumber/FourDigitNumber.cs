using System;

class FourDigitNumber
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int d = n % 10;
        int c = (n/ 10) % 10;
        int b = (n / 100) % 10;
        int a = n / 1000;

        int sumOfDigits = a + b + c + d;

        Console.WriteLine(sumOfDigits);
        Console.WriteLine("{0}{1}{2}{3}", d, c, b, a);
        Console.WriteLine("{0}{1}{2}{3}", d, a, b, c);
        Console.WriteLine("{0}{1}{2}{3}", a, c, b, d);

    }
}

