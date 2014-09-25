using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionCalculator
{
    // test the struct Fraction
    class FractionTest
    {
        static void Main()
        {
            Fraction fraction1 = new Fraction(22, 7);
            Fraction fraction2 = new Fraction(40, 4);
            Fraction addition = fraction1 + fraction2;
            Fraction substraction = fraction1 - fraction2;
       
            Console.WriteLine(addition.Numerator);
            Console.WriteLine(addition.Denominator);
            Console.WriteLine(addition);
            Console.WriteLine(substraction);
             
            // throw an exception by passing '0' for denominatore
            Fraction fraction3 = new Fraction(23, 0);
            Console.WriteLine(fraction3);
        }
    }
}
