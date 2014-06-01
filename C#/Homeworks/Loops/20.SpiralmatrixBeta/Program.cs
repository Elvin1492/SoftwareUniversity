    using System;
 class SpiralMatrix
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
 
            int currentNumber = 1;
            int start = 0;
            int ending = n;
            do
            {
                //top side
                for (int i = start; i < ending; i++)
                {
                    matrix[start, i] = currentNumber;
                    currentNumber++;
                }
                //right side
                for (int i = start + 1; i < ending; i++)
                {
                    matrix[i, ending - 1] = currentNumber;
                    currentNumber++;
                }
                //bottom side
                for (int i = ending - 2; i >= start; i--)
                {
                    matrix[ending - 1, i] = currentNumber;
                    currentNumber++;
                }
                //left side
                for (int i = ending - 2; i >= start+1; i--)
                {
                    matrix[i, start] = currentNumber;
                    currentNumber++;
                }
                start++;
                ending--;
            } while (ending - start > 0);
 
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,4}",matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }

