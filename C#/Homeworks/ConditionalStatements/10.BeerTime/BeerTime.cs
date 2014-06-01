using System;
using System.Globalization;
using System.Threading;

class Beer
{
    static void Main()
    {
        Console.WriteLine("Enter time in format hh:mm tt:");
        string time = Console.ReadLine();
        DateTime result;
        string whatIsTheTime = null;
        

        if (!DateTime.TryParseExact(time, "hh:mm tt",
            CultureInfo.CurrentCulture,
            DateTimeStyles.None, out result))  
        {
            Console.WriteLine("Invalid time!");
            return;
        }
    
        DateTime startTime = DateTime.Parse("01:00 PM");
        DateTime endTime = DateTime.Parse("03:00 AM");

        if ((result >= startTime) || (result <= endTime)) 
        {
            whatIsTheTime = "beer time";
        }
        else
        {
            whatIsTheTime = "non-beer time";
        }

        Console.WriteLine(whatIsTheTime);
       
    }

}

