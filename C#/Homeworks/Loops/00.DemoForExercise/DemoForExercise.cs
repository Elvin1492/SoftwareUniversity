using System;

class DemoForExercise
{
    static void Main()
    {
        //prime number check with a while loop
        int number = int.Parse(Console.ReadLine());
        int divider = 2;
        int maxDivider = (int)Math.Sqrt(number);
        bool isPrime = true;

        while(isPrime && (divider <= maxDivider))
        {
            if (number % divider == 0)
            {
                isPrime = false;
            }
            divider ++;
        }
        Console.WriteLine("Number is prime {0}",isPrime);
        // prime number check with a for loop
        bool prime = true;
        for (int i = 2; i <= maxDivider; i++)
        {
            if (number % i == 0)
            {
                prime = false;
            }
        }
        Console.WriteLine("Number is prime: {0}",prime);
        Console.WriteLine();
        // factorial N! with a while loop
        int numberF = int.Parse(Console.ReadLine());
        int factorial = 1;
        while(true)
        {
            if(numberF <= 1)
            {
                break;
            }

            factorial *= numberF;
            numberF--;
        }
        Console.WriteLine("N! {0}",factorial);
        //factorial N! with a for loop
        for (int i = numberF; i >= 1; i--)
        {
            factorial *= numberF;
        }
        Console.WriteLine("N! {0}",factorial);
        //factorial N! with a do while loop
        do
        {
            factorial *= numberF;
            numberF--;
        }
        while (numberF >= 1);
        Console.WriteLine("N! {0}", factorial);
        Console.WriteLine();
        //product of numbers between N and M with a do while loop
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        int product = 1;

        do
        {
            product *= n;
            n++;            
        } while (n <= m);
        Console.WriteLine("Product is: {0}", product);
        //product of numbers between N and M with a for loop
        int product2 = 1;
        for (int i = n; i <= m; i++)
        {
            product2 *= n;      
        }
        Console.WriteLine("Product is: {0}", product);
        Console.WriteLine();
        //Printing a triangle of digits with a nested for loop
        int triangle = int.Parse(Console.ReadLine());

        for (int row = 1; row <= triangle; row++)
        {
            for (int col = 1; col <= row; col++)
            {
                Console.Write("{0} " , col);
            }
            Console.WriteLine();
        }
        Console.WriteLine();

    }
}

