using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        bool thirdIs7 = true;
        if((n/100)% 10 == 7)
        {
            Console.WriteLine(thirdIs7);
        }
        else
        {
            thirdIs7 = false;
            Console.WriteLine(thirdIs7);
        }
        
    }
}

