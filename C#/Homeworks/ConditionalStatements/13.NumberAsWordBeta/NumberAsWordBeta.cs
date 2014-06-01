using System;

class NumberAsWord
{
    static void Main()
    {
        Console.Write(" enter number [1..999]: ");
        int number = int.Parse(Console.ReadLine());
        //get the number's digits
        int hundreds = number / 100;
        int tens = (number / 10) % 10;
        int ones = number % 10;

        if (number <= 999 && number > 0)
        {
            //print the hundreds
            switch (hundreds)
            {
                case 0: break;
                case 1: Console.Write(" One hundred "); break;
                case 2: Console.Write(" Two hundred "); break;
                case 3: Console.Write(" Tree hundred "); break;
                case 4: Console.Write(" Four hundred "); break;
                case 5: Console.Write(" Five hundred "); break;
                case 6: Console.Write(" Six hundred "); break;
                case 7: Console.Write(" Seven hundred "); break;
                case 8: Console.Write(" Eight hundred "); break;
                case 9: Console.Write(" nine hundred "); break;
                default: break;
            }
            //print and
            if (number % 100 != 0 && number / 100 != 0)
            {
                Console.Write("and ");
            }
            //print 010 to 019
            switch (tens)
            {
                case 0: break;
                case 1:
                    switch (ones)
                    {
                        case 0: Console.Write("Ten "); break;
                        case 1: Console.Write("Eleven "); break;
                        case 2: Console.Write("Twelve "); break;
                        case 3: Console.Write("Thirteen "); break;
                        case 4: Console.Write("Fourteen "); break;
                        case 5: Console.Write("Fiveteen "); break;
                        case 6: Console.Write("Sixteen "); break;
                        case 7: Console.Write("Seventeen "); break;
                        case 8: Console.Write("Eighteen "); break;
                        case 9: Console.Write("Nineteen "); break;
                        default: break;
                    } break;
                case 2: Console.Write("Twenty "); break;
                case 3: Console.Write("Thirty "); break;
                case 4: Console.Write("Forty "); break;
                case 5: Console.Write("Fifty "); break;
                case 6: Console.Write("Sixty "); break;
                case 7: Console.Write("Seventy "); break;
                case 8: Console.Write("Eighty "); break;
                case 9: Console.Write("Ninety "); break;
                default: break;
            }
            //print the ones
            switch (ones)
            {
                case 0: if (number == 0)
                    {
                        Console.Write("zero");
                    }
                    Console.Write("\n "); break;
                case 1: if (tens == 1) break;
                    Console.WriteLine("One"); break;
                case 2: if (tens == 1) break;
                    Console.WriteLine("Two"); break;
                case 3: if (tens== 1) break;
                    Console.WriteLine("Three "); break;
                case 4: if (tens== 1) break;
                    Console.WriteLine("Four"); break;
                case 5: if (tens== 1) break;
                    Console.WriteLine("Five"); break;
                case 6: if (tens == 1) break;
                    Console.WriteLine("Six"); break;
                case 7: if (tens == 1) break;
                    Console.WriteLine("Seven"); break;
                case 8: if (tens == 1) break;
                    Console.WriteLine("Eight"); break;
                case 9: if (tens == 1) break;
                    if (tens == 1) break;
                    Console.WriteLine("nine"); break;
                default: break;
            }
        }
        else Console.WriteLine(" Out of range! ");
    }
}

