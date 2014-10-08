namespace Customer
{
    using System;
    using System.Collections.Generic;

    class CustomerTest
    {
        static void Main()
        {
            List<Payment> booksPayments = new List<Payment>()
            {
                new Payment("C# programming", 10),
                new Payment("Java programming",10),
            };

            Customer baiStamat = new Customer("Stvrii", "Evstatiev", "Prokopiev", "5605964823", "Sofia,\"Tzar Boris 3\" 66",
                "0888666333", "stamat@gmail.com", booksPayments, CustomerType.Regular);
            Customer baiStamat2 = new Customer("Stvrii", "Evstatiev", "Prokopiev", "5605964823", "Sofia,\"Tzar Boris 3\" 66",
                "0888666333", "stamat@gmail.com", booksPayments, CustomerType.Regular);
            Customer baiStavrii = new Customer("Stamat", "Stavrev", "Karpache", "5605964822", "London,\"Mayfair Str\" 33",
                "0888888888", "stavrii@gmail.com", booksPayments, CustomerType.Diamond);

            Console.WriteLine(baiStamat.CompareTo(baiStamat2));
            Console.WriteLine(baiStavrii != baiStamat);
            Console.WriteLine();

            Customer baiStavriiCloning = (Customer)baiStavrii.Clone();
            baiStavrii.AddPayment(new Payment("JavaScript the good sides", 10));
            
            Console.WriteLine(baiStavrii);
            Console.WriteLine();
            Console.WriteLine(baiStavriiCloning);
        }
    }
}
