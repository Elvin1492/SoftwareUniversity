using System;
using System.Linq;

class Program
{
    static void Main()
    {
        long input = long.Parse(Console.ReadLine());
        long rest;        
        string binaryNUmber = "";
        if (input == 0)
        {

            Console.WriteLine("0");
        }
        else
        {
            while (input > 0)
            {
                rest = input % 2;
                input = input / 2;
                binaryNUmber = rest.ToString() + binaryNUmber;
            }
        }
        Console.WriteLine(binaryNUmber);  
       
    }
}

