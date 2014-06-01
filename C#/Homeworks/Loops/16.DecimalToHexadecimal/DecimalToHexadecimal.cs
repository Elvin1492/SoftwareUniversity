using System;

class DecimalToHexadecimal
{
    static void Main()
    {
        long decimalNumber = long.Parse(Console.ReadLine());
        string hexadecimalNumber = "";
        long rest;

        while (decimalNumber > 0)
        {
            rest = decimalNumber % 16;
            decimalNumber = decimalNumber / 16;
            switch (rest)
            {
                case 0: hexadecimalNumber = "0" + hexadecimalNumber; break;
                case 1: hexadecimalNumber = "1" + hexadecimalNumber; break;
                case 2: hexadecimalNumber = "2" + hexadecimalNumber; break;
                case 3: hexadecimalNumber = "3" + hexadecimalNumber; break;
                case 4: hexadecimalNumber = "4" + hexadecimalNumber; break;
                case 5: hexadecimalNumber = "5" + hexadecimalNumber; break;
                case 6: hexadecimalNumber = "6" + hexadecimalNumber; break;
                case 7: hexadecimalNumber = "7" + hexadecimalNumber; break;
                case 8: hexadecimalNumber = "8" + hexadecimalNumber; break;
                case 9: hexadecimalNumber = "9" + hexadecimalNumber; break;
                case 10: hexadecimalNumber = "A" + hexadecimalNumber; break;
                case 11: hexadecimalNumber = "B" + hexadecimalNumber; break;
                case 12: hexadecimalNumber = "C" + hexadecimalNumber; break;
                case 13: hexadecimalNumber = "D" + hexadecimalNumber; break;
                case 14: hexadecimalNumber = "E" + hexadecimalNumber; break;
                case 15: hexadecimalNumber = "F" + hexadecimalNumber; break;
                default:
                    break;
            }
        }
        Console.WriteLine(hexadecimalNumber);
        
    }
}
