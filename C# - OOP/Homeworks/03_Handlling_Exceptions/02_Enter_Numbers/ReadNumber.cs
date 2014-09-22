using System;

class ReadNumber
{
    //define a stitic method ReadNumber()
    public static void ReadNumbers(int start, int end)
    {
        Console.WriteLine("Plese enter a number:");
        int number = int.Parse(Console.ReadLine());

        if (number < start || number > end)
        {
            throw new ArgumentOutOfRangeException(number.ToString(),
                String.Format("Number should be in the range [{0}..{1}]", start, end));
        }
    }

    static void Main()
    {
        for (int i = 0; i < 10; i++)
        {
            try
            {
                ReadNumbers(1, 100);
            }
            catch (FormatException)
            {
                Console.Error.WriteLine("Invalid Number");
                Console.WriteLine("Try again:");
                i--;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.Error.WriteLine("Number should be in the range [1..100]");
                Console.WriteLine("Try again:");
                i--;
            }
        }
    }
}