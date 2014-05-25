import java.util.Scanner;


public class CountSubstringOccurrences {
	//Write a program to find how many times given string appears in given text as substring. 
	//The text is given at the first input line. The search string is given at the second input line.
	//The output is an integer number. Please ignore the character casing. 

	public static void main(String[] args) {
		//Read the text and the substring we'll be looking for, and parse them to lower cases
		Scanner reader = new Scanner(System.in);
		String text= reader.nextLine().toLowerCase();
		String subsrig = reader.nextLine().toLowerCase();
		// Set a counter to count the matching substrings and get the index of the first one matching
		int index = text.indexOf(subsrig);
		int counter = 0;
		
		//Go through the text and search for the index of the matching substring, each time starting 
		//from the index after the index of the previously found matching substring until we get 
		//a mismatch: '-1'(meaning there are no more matching substrings
		
		while (index != -1) {
			index = text.indexOf(subsrig, index + 1);
			counter ++;
		}
		System.out.println(counter);
		
	}

}
