using System;

class InsideAcircleOutsideOfTriangle
{
    static void Main()
    {
        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());

        bool insideAcircle = false;


        if( (x -1 ) * (x - 1) + (y - 1) * (y - 1) <= 1.5 * 1.5)
        {
            insideAcircle = true;
        }

        bool outsideArectangle = false;

        if(y > 1 || y < -1)
        {
            outsideArectangle = true;
        }

   
        if( insideAcircle == true && outsideArectangle == true)
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No");
        }


    }
}

