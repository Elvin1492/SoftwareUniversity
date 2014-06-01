using System;

class StringsAndObjects
{
    static void Main()
    {
        string first = "Hello";
        string second = "World";
        object concatenated = first + " " + second;
        string objectToString = (string)concatenated;
        Console.WriteLine(objectToString);


    }
}

