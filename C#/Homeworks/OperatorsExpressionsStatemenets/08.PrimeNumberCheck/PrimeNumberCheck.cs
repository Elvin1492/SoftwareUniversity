using System;

class PrimeNumberCheck
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int divider = 2;
        int maxdivider = (int)Math.Sqrt(n);
        bool prime = true;
        if(n == 1)
        {
            prime = false;
            Console.WriteLine(prime);
         
        }
  
        //with while loop
        while(prime && divider <= maxdivider)
        {
            if (n % divider == 0 && n != 1 )
            {
                prime = false;
            }
            divider++;
        }
        Console.WriteLine(prime);
//with for loop
        for (int i = 2; i < Math.Sqrt(n); i++)
        {
            if (n % i == 0 && n != 1)
            {
                prime = false;
            }
        }
        Console.WriteLine(prime);
    }
}

