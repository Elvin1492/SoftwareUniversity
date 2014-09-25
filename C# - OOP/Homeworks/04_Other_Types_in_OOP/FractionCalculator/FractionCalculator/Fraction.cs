
namespace FractionCalculator
{
    using System;

    public struct Fraction
    {
        // define fields for the struct Fraction
        private long numerator;
        private long denominator;

        // define a constructor for the sruct Fraction
        public Fraction(long numerator, long denominator)
            : this()
        {
            long gcd = GCD(numerator, denominator);
            this.Numerator = numerator / gcd;
            this.Denominator = denominator/ gcd;

            if (denominator < 0)
            {
                this.numerator = -numerator;
                this.denominator = Math.Abs(denominator);
            }
        }

        // define properties with validation for the struct Fractin
        public long Numerator
        {
            get { return this.numerator; }
            private set { this.numerator = value; }
        }

        public long Denominator 
        {
            get { return this.denominator; }
            private set
            {
                if (value == 0)
                {
                    throw new DivideByZeroException("Denominator can not be zero!");
                }

                this.denominator = value;
            }
        }

        // overload the '+' operator for additin of fractions
        public static Fraction operator +(Fraction fract1, Fraction fract2)
        {
            long newNumerator = fract1.numerator * fract2.denominator + fract2.numerator * fract1.denominator;
            long newDenomintaor = fract1.denominator * fract2.denominator;

            return new Fraction(newNumerator, newDenomintaor);
        }

        // overload the '-' oprator for substraction of fractions
        public static Fraction operator -(Fraction fract1, Fraction fract2)
        {
            long newNumerator = fract1.numerator * fract2.denominator - fract2.numerator * fract1.denominator;
            long newDenomintaor = fract1.denominator * fract2.denominator;

            return new Fraction(newNumerator, newDenomintaor);
        }

        // a private static method to get the GreatestCommonDivisor od two long numbers
        private static long GCD(long first, long second)
        {
            return second == 0 ? first : GCD(second, first % second);
        }

        // override the ToString method to print the tresult on the console
        public override string ToString()
        {
            return String.Format("{0}", (decimal)this.numerator / this.denominator); 
        }
    }
}
