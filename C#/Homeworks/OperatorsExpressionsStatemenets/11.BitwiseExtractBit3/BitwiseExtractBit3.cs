using System;

class BitwiseExtractBit3
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int nright3 = n >> 3;
        int bit = nright3 & 1;
        Console.WriteLine(bit);

    }
}

