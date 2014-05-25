import java.util.Arrays;
import java.util.Scanner;

public class SequenceOFEqualStrings {
	//Write a program that enters an array of strings and finds in it all sequences of equal 
   //elements. The input strings are given as a single line, separated by a space

	public static void main(String[] args) { 
		//read the input as a single line,split it and store it in a string array.
		Scanner reader = new Scanner(System.in);
		String input = reader.nextLine();
		String[] splitted = input.split(" ");
		System.out.print(splitted[0]);
		//Go through the array and print every next element which is equal to the previous, if two
		// neighbour elements are not equal print the element on a new line
		for (int i = 1; i < splitted.length; i++) {
			if (splitted[i].equals(splitted[i-1])) {
				System.out.print( " " + splitted[i]);
			}
			else {
				System.out.println();
				System.out.print(splitted[i]);
			}
		
		}
	
	}

}
