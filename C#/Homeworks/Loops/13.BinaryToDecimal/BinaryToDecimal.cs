using System;
using System.Linq;

class BinaryToDecimal
{
    static void Main()
    {
        string input = Console.ReadLine();
        long decimalnumber = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if(input[i] == '0')
            {
                continue;
            }
            else
            {
                decimalnumber += (long)Math.Pow(2,(input.Length - i - 1));           
            }
        }
        Console.WriteLine(decimalnumber);
        //With the build in function
        long binary = Convert.ToInt64(input, 2);
        Console.WriteLine(binary);
            
    }
}

