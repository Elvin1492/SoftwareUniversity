using System;

//testing the program
namespace LaptopShop
{
    class Program
    {
        static void Main()
        {
            //testing the battery class
            Battery firstBattery = new Battery("model1", 1.6f);
            Battery secondBattery = new Battery("model2");
            //first laptop has only the mandatoray model and price
            Laptop firstLaptop = new Laptop("Lenovo Yoga 2 Pro", 2259.00M);
            Console.WriteLine(firstLaptop);
            //second laptop has all properties plus all properties from the battery object
            Laptop secondLaptop = new Laptop("Lenovo Yoga 2 Pro", 2259.00M, "Lenovo",
                "Intel Core i5-4210U 2-core, 1.70 - 2.70 GHz, 3MB cache", 8, "Intel HD Graphics 4400", 128, 13.3f,firstBattery);
            Console.WriteLine(secondLaptop);
            //third laptop has some properties plus some proprtes from the battery object
            Laptop thirdLaptop = new Laptop("Lenovo Yoga 2 Pro", 2259.00M,"Lenovo",ram: 6, hdd: 512, battery: secondBattery);
            Console.WriteLine(thirdLaptop);
        }
    }
}