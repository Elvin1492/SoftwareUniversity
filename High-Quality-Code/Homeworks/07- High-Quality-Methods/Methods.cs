using System;
using System.ComponentModel;

namespace Methods
{
    public class Methods
    {
        public static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentOutOfRangeException("All sides of the triagnle should be positive integer numbers.");
            }
            else if (a + b <= c)
            {
                throw new ArgumentOutOfRangeException(c.ToString(), "Side C must be bigger than the sum of side A and side B");
            }
            else if (a + c <= b)
            {
                throw new ArgumentOutOfRangeException(b.ToString(), "Side B must be bigger than the sum of side A and side C");
            }
            else if (b + c <= a)
            {
                throw new ArgumentOutOfRangeException(a.ToString(), "Side A must be bigger than the sum of side B and side C");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

            return area;
        }

        static string NumberToDigit(int number)
        {
            switch (number)
            {
                case 0:
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    throw new ArgumentException(String.Format("Number {0} can not be converted", number));
            }
        }

        static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException(" Parameter Elements can not be null or empty");
            }

            int maxElement = int.MinValue;
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] > maxElement)
                {
                    maxElement = elements[i];
                }
            }

            return maxElement;
        }

        static void PrintAsNumber(object number, string format)
        {
            if ((number is int) || (number is double) || (number is float) || (number is long) || (number is decimal))
            {
                switch (format)
                {
                    case "f":
                        Console.WriteLine("{0:f2}", number);
                        break;
                    case "%":
                        Console.WriteLine("{0:p0}", number);
                        break;
                    case "r":
                        Console.WriteLine("{0,8}", number);
                        break;
                    default:
                        throw new ArgumentException("The specified format is not valid");
                }
            }
            else
            {
                throw new ArgumentException("Number is not valid.");
            }
        }

        static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));

            return distance;
        }

        static bool LineIsHorizontal(double x1, double y1, double x2, double y2)
        {
            return y1 == y2;
        }

        static bool LineIsVertical(double x1, double y1, double x2, double y2)
        {
            return x1 == x2;
        }
        static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));

            Console.WriteLine(NumberToDigit(5));

            Console.WriteLine(FindMax(5));

            PrintAsNumber(1375234.3462d, "f");
            PrintAsNumber(50.89m, "%");
            PrintAsNumber(-230.6773547434743354272f, "r");

            Console.WriteLine(CalcDistance(3, -1, 3, 2.5));
            Console.WriteLine(LineIsHorizontal(3, -1, 3, 2.5));
            Console.WriteLine(LineIsVertical(3, -1, 3, 2.5));

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia, born at 07.03.1992";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results, born at  03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}",
            peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
