using System; 

class FibonacNumber
{
    //Invoke the method
    static void Main()
    {
        Console.WriteLine("Enter number \"n\" to get the Nth fibonacci number: ");
        int n = int.Parse(Console.ReadLine());
        fibonaci(n);
    }
    //Define the method
    static void fibonaci(int nMemeber)
    {       
        int fibonacinumber = 0;
        int firstMember = 0;
        int secondmember = 1;
        for (int i = 0; i < nMemeber; i++)
        {
            fibonacinumber = firstMember + secondmember;
            firstMember = secondmember;
            secondmember = fibonacinumber;
        }
        Console.WriteLine(fibonacinumber);
    }
}

