
namespace StringBuilderExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    // define a class to hold the extension methods
    public static class ExtensionMethods
    {
        // define an extension method for extracting a substring
        public static String Substring(this StringBuilder str, int startIndex, int length)
        {
            string origanl = str.ToString();
            int originalStrLenght = origanl.Length;
            if (startIndex < 0 || startIndex > originalStrLenght || startIndex + length > originalStrLenght)
            {
                throw new ArgumentOutOfRangeException("index", "Index was out of range");
            }

            String newString = "";
            for (int i = startIndex; i < startIndex + length; i++)
            {
                newString += origanl[i];
            }
            
            return newString;
        }

        // define an exension method for removing text from a string
        public static StringBuilder RemoveText(this StringBuilder str, string text)
        {
            string originalString  = str.ToString();
            string newString = Regex.Replace(originalString, text, String.Empty, RegexOptions.IgnoreCase);

            str.Clear();
            str.AppendLine(newString);

            return str;
        }

        // define an exension method for appending elemetns from a colectin
        public static StringBuilder AppendAll<T>(this StringBuilder str, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                str.Append(item.ToString() + " ");
            }

            return str;
        }
    }
}
