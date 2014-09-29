
namespace StringBuilderExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    // a class to test the StringBuilder extensions
    public class StringBuilderTest
    {      
        static void Main()
        {
            StringBuilder testString =  new StringBuilder();
            testString.Append("This is the string we'll be performig ou tests on. And this is just another sentence");

            // test the Substring method
            string result = testString.Substring(0,4);
            Console.WriteLine(result); // output is 'this'
            
            // test the RemoveText method
            testString.RemoveText("this");
            Console.WriteLine(testString);
            
            // test the AppendAll<T> method
            var listDoubles = new List<double>() { 1.0, 2.4, 3.8 };
            testString.AppendAll(listDoubles);
            Console.WriteLine(testString);

        }

    }
}
