using System;

class GravitationOnTheMoon
{
    static void Main()
    {
        double weight = double.Parse(Console.ReadLine());

        const double gravityIndex = 0.17;
        double weightOnMoon = weight * gravityIndex;
        Console.WriteLine("Weight on the Moon:{0: 0.000000}",weightOnMoon);

    }
}
