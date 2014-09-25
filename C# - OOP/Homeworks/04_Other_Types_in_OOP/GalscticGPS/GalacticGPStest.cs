
using System;
using GalscticGPS;

// test the struct Location and the enum Planet
class GalacticGPStest
{ 
    static void Main()
    {
        Location home = new Location(18.037986, 28.870097, Planet.Earth);
        Console.WriteLine(home);

        home.Latitude += 29.65432;
        home.Longitude += 34.65432;
        home.Planet = (Planet)Enum.Parse(typeof(Planet), "Jupiter");
        Console.WriteLine(home);

        // pass invalid argument to cause an exception
        var invalidLocation = new Location(12.45, -81.24, Planet.Mars); //this will throw an ArgumentOutOfRange Exception
        Console.WriteLine(invalidLocation);
    }
}
