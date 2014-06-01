using System;

class HexadecimalToDecimal
{
    static void Main()
    {
        string hexadecimal = Console.ReadLine();
        long decimalNumber = 0;

        for (int i = 0; i < hexadecimal.Length; i++)
        {
            switch (hexadecimal[i])
            {
                case '0': decimalNumber += 0 * (long)Math.Pow(16, hexadecimal.Length - i - 1); break;
                case '1': decimalNumber += 1 * (long)Math.Pow(16, hexadecimal.Length - i - 1); break;
                case '2': decimalNumber += 2 * (long)Math.Pow(16, hexadecimal.Length - i - 1); break;
                case '3': decimalNumber += 3 * (long)Math.Pow(16, hexadecimal.Length - i - 1); break;
                case '4': decimalNumber += 4 * (long)Math.Pow(16, hexadecimal.Length - i - 1); break;
                case '5': decimalNumber += 5 * (long)Math.Pow(16, hexadecimal.Length - i - 1); break;
                case '6': decimalNumber += 6 * (long)Math.Pow(16, hexadecimal.Length - i - 1); break;
                case '7': decimalNumber += 7 * (long)Math.Pow(16, hexadecimal.Length - i - 1); break;
                case '8': decimalNumber += 8 * (long)Math.Pow(16, hexadecimal.Length - i - 1); break;
                case '9': decimalNumber += 9 * (long)Math.Pow(16, hexadecimal.Length - i - 1); break;
                case 'A': decimalNumber += 10 * (long)Math.Pow(16, hexadecimal.Length - i - 1); break;
                case 'B': decimalNumber += 11 * (long)Math.Pow(16, hexadecimal.Length - i - 1); break;
                case 'C': decimalNumber += 12 * (long)Math.Pow(16, hexadecimal.Length - i - 1); break;
                case 'D': decimalNumber += 13 * (long)Math.Pow(16, hexadecimal.Length - i - 1); break;
                case 'E': decimalNumber += 14 * (long)Math.Pow(16, hexadecimal.Length - i - 1); break;
                case 'F': decimalNumber += 15 * (long)Math.Pow(16, hexadecimal.Length - i - 1); break;
                default:
                    break;
            }
        }
        Console.WriteLine(decimalNumber);
        //with the build-in uunction
        decimalNumber = Convert.ToInt64(hexadecimal, 16);
        Console.WriteLine(decimalNumber);
    }
}

