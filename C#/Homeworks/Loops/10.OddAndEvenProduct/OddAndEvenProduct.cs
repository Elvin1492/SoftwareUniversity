using System;

class OddAndEvenProduct
{
    static void Main()
    {
        //Read the input from the console as a string array and split the whitespaces
        string[] input = Console.ReadLine().Split();
        int[] numbers = new int[input.Length];

        int oddProduct = 1;
        int evenProduct = 1;
        //parse the string array to an integer array
        for (int i = 0; i < input.Length; i++)
        {
            numbers[i] = int.Parse(input[i]);
             
        }
        //get the numbers at odd position from the integer array and calculate the oddProduct
        for (int j = 0; j < input.Length; j += 2)
        {
            oddProduct *= numbers[j];
        }
        //get the numbers at even position from the integer array and calculate the evenProduct
        for (int k = 1; k < input.Length; k += 2)
        {
            evenProduct *= numbers[k];
        }
        //check if the evenProdcut is equal to the oddprodcut
        if (evenProduct == oddProduct)
        {
            Console.WriteLine("yes");
            Console.WriteLine("product = {0}",oddProduct);
        }
        else if (evenProduct != oddProduct)
        {
            Console.WriteLine("no");
            Console.WriteLine("odd_product = {0}", oddProduct);
            Console.WriteLine("even_product = {0}",evenProduct);
        }
       
    }
}

       