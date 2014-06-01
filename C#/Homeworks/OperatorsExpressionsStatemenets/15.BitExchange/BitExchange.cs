using System;

class BitsExchange
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        //get third and twentyfourth bit 
        int mask = 1 << 3;
        int thirdBit = (mask & number) >>3;
        mask = 1 << 24;
        int twentyFourthBit = (mask & number) >> 24;      

        //check if third bit is 0 or 1 and asign twentfourth bit with its value
        if(thirdBit == 0)
        {
           mask = ~(1 << 24);
           number = number & mask;          
        }
        else if(thirdBit == 1)
        {
            mask = 1 << 24;
            number = number | mask;
        }

       //check if twentyfourth bit is 0 or 1 and asign third bit with its value
        if(twentyFourthBit == 0)
        {
            mask = ~(1 << 3);
            number = number & mask;
        }
        else if (twentyFourthBit == 1)
        {
            mask = 1 << 3;
            number = number | mask;   
        }
 
        //get fourth and twentyfifth bit 
        mask = 1 << 4;
        int fourthBit = (mask & number) >> 4;
        mask = 1 << 25;
        int twentyFifthBit = (mask & number) >> 25;

        //check if fourth bit is 0 or 1 and asign twentfifth bit with its value
        if (fourthBit == 0)
        {
            mask = ~(1 << 25);
            number = number & mask;
        }
        else if (fourthBit == 1)
        {
            mask = 1 << 25;
            number = number | mask;
        }

        //check if twentyfifth bit is 0 or 1 and asign fourth bit with its value
        if (twentyFifthBit == 0)
        {
            mask = ~(1 << 4);
            number = number & mask;
        }
        else if (twentyFifthBit == 1)
        {
            mask = 1 << 4;
            number = number | mask;
        }

        //get fifth and twentysixth bit 
        mask = 1 << 5;
        int fifthBit = (mask & number) >> 5;
        mask = 1 << 26;
        int twentySixthBit = (mask & number) >> 26;

        //check if fifth bit is 0 or 1 and asign twentysixth bit with its value
        if (fifthBit == 0)
        {
            mask = ~(1 << 26);
            number = number & mask;
        }
        else if (fifthBit == 1)
        {
            mask = 1 << 26;
            number = number | mask;
        }

        //check if twentysixth bit is 0 or 1 and asign fifth bit with its value
        if (twentySixthBit == 0)
        {
            mask = ~(1 << 5);
            number = number & mask;
        }
        else if (twentySixthBit == 1)
        {
            mask = 1 << 5;
            number = number | mask;
        }
        Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));
        Console.WriteLine(number);

    }
}

