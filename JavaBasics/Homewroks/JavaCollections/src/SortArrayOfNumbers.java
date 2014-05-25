import java.util.Arrays;
import java.util.Scanner;

public class SortArrayOfNumbers {
	//Write a program to enter a number n and n integer numbers and sort and print them. 
	//Keep the numbers in array of integers: int[]. 
	
	public static void main(String[] args){ 
		//Read the input from the console, create an array with length "n",store the input in it ,sort
		//the array and print it
		Scanner reader = new Scanner(System.in);
		int n = reader.nextInt(); 
		reader.nextLine();
		int[] numbers = new int[n];
		for (int i = 0; i < n; i++) {
			numbers[i] = reader.nextInt();
		}
		Arrays.sort(numbers);
		for (int i : numbers) {
			System.out.print( i + " ");
		}
	}

}
