using System;

class ComparingFloats
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());

        const double eps = 0.000001;
        bool equal = false;

        double difference = b - a;
        if(difference < 0)
        {
            difference = -difference;
        }

        if (difference > eps)
        {
            Console.WriteLine(equal);
        }
        else if(difference <= eps)
        {
            equal = true;
            Console.WriteLine(equal);
        }
    }
}

