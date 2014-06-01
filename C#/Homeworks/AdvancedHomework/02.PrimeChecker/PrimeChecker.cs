using System;

class PrimeChecker
{
    //Invoke the method
    static void Main()
    {
        Console.WriteLine("Enter a number to check if it's prime; ");
        long n = long.Parse(Console.ReadLine());
        isPrime(n);
    }
    //Define the boolean method 
    static void isPrime(long number)
    {
        bool prime = true;
        long divider = 2;
        long maxdivider = (long)Math.Sqrt(number);
        while (divider <=maxdivider)
        {
            if (number % divider == 0)
            {
                prime = false;
                break;
            }
            divider++;
        }
        Console.WriteLine(prime);

    }
}
