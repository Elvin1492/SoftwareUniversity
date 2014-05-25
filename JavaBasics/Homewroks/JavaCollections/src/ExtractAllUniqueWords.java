import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;
import java.util.Set;
import java.util.TreeSet;

public class ExtractAllUniqueWords {
	//At the first line at the console you are given a piece of text. Extract all words from it and
	//print them in alphabetical order. Consider each non-letter character as word separator. 
	//Take the repeating words only once. Ignore the character casing. Print the result words in a 
	//single line, separated by spaces
 
	public static void main(String[] args) {
		//Read the input form the console, parse it to lower case and then split it from all
		//non-letter characters 
		Scanner reader = new Scanner(System.in);
		String input = reader.nextLine().toLowerCase();
		String[] split = input.split("[^a-zA-Z]+");
		
		//Sort the split  array alphabetically 
		Arrays.sort(split);
		
		//Create a string ArrayList, go through the array string 'split' and add to the list each string
		//that doesn't yet appear in it.
		ArrayList<String> listOfStrings = new ArrayList<>();
		for (String string : split) {
			if (!listOfStrings.contains(string)) {
				listOfStrings.add(string);
			}
		}
		
		//Print the ArrayList
		for (String string : listOfStrings) {
			System.out.print(string + " ");
		}
		System.out.println();
		//Another way using sets.Create a set, go through the split array and add each word to the TreeSet
		Set<String> unique = new TreeSet<>();
		for (String string : split) {
			unique.add(string);
		}
		for (String string : unique) {
			System.out.print(string  +  " ");
		}
	}
}
