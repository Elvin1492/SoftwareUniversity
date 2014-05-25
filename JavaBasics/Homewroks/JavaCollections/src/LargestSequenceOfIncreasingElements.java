import java.util.Scanner;

import javax.xml.stream.events.StartDocument;


public class LargestSequenceOfIncreasingElements {
	//Write a program to find all increasing sequences inside an array of integers. 
	//The integers are given in a single line, separated by a space. Print the sequences in the order
	//of their appearance in the input array, each at a single line. Separate the sequence elements
	//by a space. Find also the longest increasing sequence and print it at the last line. If several 
	//sequences have the same longest length, print the leftmost of them. 

	public static void main(String[] args) {
		//read the input as a single line,split it and store it in a string array.
		//then parse the string elements into ints and store them in an int array
		Scanner reader = new Scanner(System.in);
		String[] input = reader.nextLine().split(" ");
		int[] numbers = new int[input.length];
		for (int i = 0; i < numbers.length; i++) {
			numbers[i] = Integer.parseInt(input[i]);
		}
		//Initialize variables to store the current length of the sequence, the best length and the
		// position of the last element in the increasing sequence
		int currentLength = 1;
		int bestLength = 1;
		int bestPosition = 0; 
		int startPosition = 0;
		System.out.print(numbers[0]);//print the first element previous print it on the current line

		//Go through the array if each next element is bigger than the previous print it on
		//the current line and increase the current length of the sequence.		
		for (int i = 1; i < numbers.length ; i++) {
			if (numbers[i] > numbers[i - 1] ) {
				System.out.print(" " + numbers[i]);//If 
				currentLength ++;	
			}
			//if the next element is not bigger get the current length at '1' and print the next
			//element on a new line
			else{
				System.out.println();
				System.out.print(numbers[i]);
				currentLength = 1;	
			}
			//get the largest increasing sequence length and the index of its last element
			if (currentLength > bestLength) {
				bestLength = currentLength;
				bestPosition = i;
				startPosition= i - (bestLength -1) ;
			
			}
		}
		//Print the largest increasing sequence on the last line
		System.out.println();
		System.out.print("Largest: ");
		for (int i = startPosition; i <= bestPosition; i++) {
			System.out.print(numbers[i] + " ");
		}
		
		
		
		

	}

}
