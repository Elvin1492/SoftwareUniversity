using System;

class CheckABitAtGivenPosition
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());

        bool is1 = true;

        int nRightP = n >> p;
        int bit = nRightP & 1;
        
        if(bit == 1)
        {
            Console.WriteLine(is1);
        }
        else
        {
            is1 = false;
            Console.WriteLine(is1);
        }

    }
}

