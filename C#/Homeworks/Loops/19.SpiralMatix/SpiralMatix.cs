using System;

class matrix
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n,n];
        int length0 = matrix.GetLength(0);
        int length1 = matrix.GetLength(1);
        //asign with values elements on first row
        for (int row = 0; row < 1; row++)
			{
                for (int col = 0; col < length1; col++)
                {
                    matrix[row,col] = col + 1 ;
                }                			 
			}
        //assign with values last elements on row
        for (int row = 1; row < length0; row++)
        {
            for (int col = n - 1; col < n; col++)
            {
                matrix[row,col] = n + row;                
            }      
        }
        //asign with values elements on last row
        for (int row = n - 1; row < length0; row++)
        {
            for (int col = 0 ; col < length1; col++)
            {
                matrix[row, col] = 3 * n - 2  - col;
            }
            
        }
        //asign with values first elements from row 2 to row n - 1;
        int counter = 0;
        for (int row = length0 - 2; row >= 1; row--)
        {            
            for (int col = 0; col < 1; col++)
            {
                matrix[row, col] = 3 * n - 1 + counter;
            }
            counter++;
        }
        
        //print the matrix
        for (int row = 0; row < length0; row++)
        {
            for (int col = 0; col < length1; col++)
            {
                Console.Write("{0}    ", matrix[row,col]);
            }
            Console.WriteLine();
        }
            
    }
}

