using System;

class Square_Root
{
    //define a static method for calculating sqrt root
    public static void CalculateSqrt()
    {
        Console.WriteLine("Enter a number:");
        try
        {
            int number = int.Parse(Console.ReadLine());
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid Number");
            }
            
            double result = Math.Sqrt(number);
            Console.WriteLine("Sqare root of {0:0.##} is: {1:0.##}", number, result);
        }
        catch(FormatException)
        {
            Console.Error.WriteLine("Invalid Number");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.Error.WriteLine("Invalid Number");
        }
        finally
        {
            Console.WriteLine("Goodbye");
        }
    }


    //test the method
    static void Main()
    {
        CalculateSqrt();
    }
}

