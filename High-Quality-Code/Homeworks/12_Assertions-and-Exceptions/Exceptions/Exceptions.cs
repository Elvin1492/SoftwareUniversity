using System;
using System.Collections.Generic;
using System.Text;

class Exceptions
{
    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        int endIndex = startIndex + count;

        // if start index is invalid return empty array
        if (startIndex > arr.Length || startIndex < 0)
        {
            return new T[0];
        }

        // if count iexceeds array lenngth return elemets to the end  of the array
        if (endIndex > arr.Length)
        {
            endIndex = arr.Length;
        }

        List<T> result = new List<T>();
      
        for (int i = startIndex; i < endIndex; i++)
        {
            result.Add(arr[i]);
        }

        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (count > str.Length || count < 0)
        {
            return "Invalid count!";
        }
        StringBuilder result = new StringBuilder();
        for (int i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }
        return result.ToString();
    }

    public static void CheckPrime(int number)
    {
        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                throw new NumberNotPrimeException("The number is not prime!");
            }
        }
    }

    static void Main()
    {
        var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
        Console.WriteLine(substr);

        var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
        Console.WriteLine(String.Join(" ", subarr));

        var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
        Console.WriteLine(String.Join(" ", allarr));

        var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
        Console.WriteLine(String.Join(" ", emptyarr));

        var invalidSubsequenceStaratIndex = Subsequence("Hello!".ToCharArray(), -1, 9); // Returns empty array
        Console.WriteLine(invalidSubsequenceStaratIndex);

        var outOfRangeCountSubsequence = Subsequence("Hello!".ToCharArray(), 0, 9); // returns the availabe elements of the array
        Console.WriteLine(outOfRangeCountSubsequence);

        Console.WriteLine(ExtractEnding("I love C#", 2));
        Console.WriteLine(ExtractEnding("Nakov", 4));
        Console.WriteLine(ExtractEnding("beer", 4));
        Console.WriteLine(ExtractEnding("Hi", 100));
        Console.WriteLine(ExtractEnding("Hi", -100));

        try
        {
            CheckPrime(23);
            Console.WriteLine("23 is prime.");
        }
        catch (NumberNotPrimeException ex )
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            CheckPrime(33);
            Console.WriteLine("33 is prime.");
        }
        catch (NumberNotPrimeException ex)
        {
            Console.WriteLine(ex.Message);
        }

        List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
           // new SimpleMathExam(-2) Will throw ArgumentOutOfRangeException
           // new CSharpExam(155), Will throw ArgumentOutOfRangeException
        };
        Student peter = new Student("Peter", "Petrov", peterExams);
        double peterAverageResult = peter.CalcAverageExamResultInPercents();
        Console.WriteLine("Average results = {0:p0}", peterAverageResult);
    }
}
