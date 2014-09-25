
namespace GenericList
{
    using System;

    // testing the GenericList
    class GenericListTest
    {
        static void Main()
        {
            // display the version of the GenericList using the VersionAttribute
            Type type = typeof(GenericList<>);
            object[] versionAttributes = type.GetCustomAttributes(typeof(VersionAttribute),true);
            foreach (VersionAttribute attribute in versionAttributes)
            {
                Console.WriteLine("Version: " + attribute.Major + "." + attribute.Minor);
            }

            // create a new list of integers with size 1
            var intList = new GenericList<int>(1);

            // add an element to the list to test the AddElement() method
            intList.AddElement(1); // the list now is as follows: 1

            // add another element to the list to test the private ResizeArray() method
            intList.AddElement(2); // the list now is as follows: 1, 2

            // insert an element to test the InsertAtIndex() method
            intList.InsertAtIndex(0, 0); // the list now is as follows: 0, 1, 2,
 
            /// remove an element to test the RemoveAtIndex() method
            intList.RemoveAtIndex(2);  // the list now is as follows: 0, 1
            intList.AddElement(2); // the list now is as follows: 0, 1, 2

            // test the ToString() method printing the list elements
            Console.WriteLine(intList); // the output is: 0, 1, 2

            // test the Min() and Max() method
            Console.WriteLine(intList.Min()); // the output is:0
            Console.WriteLine(intList.Max()); //the output is: 2

           // create a new list of strings with the default size and add some ellements to it
            var stringList = new GenericList<string>();
            stringList.AddElement("first element"); // the list now is as follows: first element
            stringList.AddElement("second element"); // the list now is as follows: first element, second element

            // test the IndexOf() method 
            Console.WriteLine(stringList.IndexOf("first element")); //the ooutput is '0'

            //test the Contains() method
            Console.WriteLine(stringList.Contains("second element")); // the output is trut

            //test the ClearList() method 
            Console.WriteLine(stringList); /// the list now is as follows: first element, second element
            stringList.ClearList();
            Console.WriteLine(stringList); // the output is "The GenreicList is empty"
        }
    }
}
