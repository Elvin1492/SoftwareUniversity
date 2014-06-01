using System;

class DivideBy7and5
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        bool divided = true;

        if( n % 5 == 0 && n % 7 == 0)
        {
            Console.WriteLine(divided);
        }
        else
        {
            divided = false;
            Console.WriteLine(divided);
        }

    }
}

