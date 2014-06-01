using System;

class SortThreeNumbers
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());

        double biggestNumber = 0;
        double middleNumber  = 0;
        double leastNumber = 0;
        //case "a" is the biggest number
        if (a >= b && b >= c )
        {
           biggestNumber = a;
           middleNumber = b;
           leastNumber = c;
        }
        else if(a >= b && b <= c && a >= c)
        {
           biggestNumber = a;
           middleNumber = c;
           leastNumber = b; 
        }     
        //case "b" is the biggest number
        if (b >= a && a >=c )
        {
           biggestNumber = b;
           middleNumber = a;
           leastNumber = c;
        }
        else if(b >= a && c >= a && b >= c)
        {
           biggestNumber = b;
           middleNumber = c;
           leastNumber = a;
        }

        //case "c" is the biggest number
         if (c >= b && b >= a)
        {
           biggestNumber = c;
           middleNumber = b;
           leastNumber = a;
        }
         else if(c >= b && a >= b && c >= a)
         {
            biggestNumber = c;
            middleNumber = a;
            leastNumber = b;
         }

        Console.WriteLine("{0} {1} {2}", biggestNumber, middleNumber,leastNumber);
    }
}

