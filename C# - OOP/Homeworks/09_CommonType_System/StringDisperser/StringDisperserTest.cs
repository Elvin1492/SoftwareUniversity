using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringDisperser
{
    public class StringDisperserTest
    {
        static void Main()
        {
            var namesList = new StringDisperser("gosho", "pesho", "tanio");
            Console.WriteLine(namesList);

            var languagesList = new StringDisperser("C#", "JAVA", "JavaScript");
            Console.WriteLine(namesList.Equals(languagesList));

            var languageListClone = languagesList.Clone();
            languagesList.Words = new string[] {"gosho", "pesho", "tanio" };           
            Console.WriteLine(languageListClone);

            Console.WriteLine(namesList.CompareTo(languagesList));

            foreach (var letter in namesList)
            {
                Console.Write(letter + " ");
            }
  
        }
    }
}
