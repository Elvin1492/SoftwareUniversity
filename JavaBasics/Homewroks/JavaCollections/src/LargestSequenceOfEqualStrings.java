import java.util.Scanner;


public class LargestSequenceOfEqualStrings {
	//Write a program that enters an array of strings and finds in it the largest sequence of equal
	//elements. If several sequences have the same longest length, print the leftmost of them. 
	//The input strings are given as a single line, separated by a space

	public static void main(String[] args) {
		//read the input as a single line,split it and store it in a string array.
		Scanner reader = new Scanner(System.in);
		String[] input = reader.nextLine().split(" ");
		//Create two int variables to store the current length of the sequence and the best length, 
		//and a string vriable to store the most frequent string
		int currentlength = 1;
		int bestlength = 1;
		String bestString = input[0]; 
		//Go through the array and each time the current length is bigger than the best one store
		//its length and the best string at this position
		for (int i = 0; i < input.length - 1; i++) {
			if (input[i].equals(input[i+ 1]) ) {
				currentlength ++;
			}
			else {
				currentlength = 1;
			}
			if (currentlength > bestlength) {
				bestlength = currentlength;
				bestString = input[i];
			}		
		}
		//Print the best string 'bestlength' times
			 for (int i = 0; i < bestlength; i++) {
					System.out.print(bestString + " ");
				}		
		}         
	}

