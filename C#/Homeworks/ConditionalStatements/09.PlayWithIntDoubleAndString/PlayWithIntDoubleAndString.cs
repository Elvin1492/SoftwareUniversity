using System;

class PlayWithIntDoubleAndString
{
    static void Main()
    {
        Console.WriteLine("Please choose a type to enter: \n 1 --> int \n 2 --> double \n 3 --> string");
        int number = int.Parse(Console.ReadLine());

        if( number == 1 )
        {
            Console.WriteLine("Please enter an int");
            int integer = int.Parse(Console.ReadLine());
            integer += 1;
            Console.WriteLine(integer);
        }

        if (number == 2)
        {
            Console.WriteLine("Please enter a double");
            double doubleinput = double.Parse(Console.ReadLine());
            doubleinput += 1;
            Console.WriteLine(doubleinput);
        }
        if (number == 3)
        {
            Console.WriteLine("Please enter a string");
            string stringinput = Console.ReadLine();
            stringinput += "*";
            Console.WriteLine(stringinput);
        }

    }
}
