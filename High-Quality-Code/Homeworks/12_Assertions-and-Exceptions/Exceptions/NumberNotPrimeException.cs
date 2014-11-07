using System;

public class NumberNotPrimeException : Exception
{
    public NumberNotPrimeException()
        : base() { }

    public NumberNotPrimeException(string message)
        : base(message) {}

 
}