
namespace LINQetensionmethods
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    // define a test class
    public class ExtensionMethodsTest
    {
        static void Main()
        {
            // create a new list we'll be performing our tests on
            IEnumerable<string> listItems = new List<string>()
            {
                "Pesho", "Gosho", "Grozdan","Grozdanka", "Penka", "Shikerka", "Stamat", "Stavrii"
            };

            // test the extension method WhereNot()
            var whereNotList = listItems.WhereNot<string>(str => str.StartsWith("S"));
            PrintCollection(whereNotList);

            // test the extension method Repeat()
            var repeatedList = listItems.Repeat(2);
            PrintCollection(repeatedList);

            // test the extenesion method WhereEndsWith()
            var endsWithList = listItems.WhereEndsWith(new List<string>() { "o", "a" });
            PrintCollection(endsWithList);
        }

        // define a method to print the list
        public static void PrintCollection(IEnumerable collection)
        {
            foreach (var item in collection)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
    }
}
