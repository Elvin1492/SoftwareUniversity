using System;

class OddOrEvenInteger
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        bool odd = true;

        if(n % 2 == 0)
        {
            odd = false;
            Console.WriteLine(odd);
        }
        else if(n % 2 != 0)
        {
            Console.WriteLine(odd);
        }
   

    }
}

