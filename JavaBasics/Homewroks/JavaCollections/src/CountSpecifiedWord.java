import java.util.Scanner;

public class CountSpecifiedWord {
	//Write a program to find how many times a word appears in given text. 
	//The text is given at the first input line. The target word is given at the second input line.
	//The output is an integer number. Please ignore the character casing. 
	//Consider that any non-letter character is a word separator. 
	
	public static void main(String[] args) {
		Scanner reader = new Scanner(System.in);
		String input = reader.nextLine();
		String word = reader.nextLine();
		//Split the text using any non- letter characters as separator 
		String[] splitted = input.split("[^a-zA-Z]+");
		int counter = 0;
		String comparedString = "";
		//Go through the split array and check each element if it's equal to the given word(disregard of
		//upper and lower cases)and count the matches.
		for (int i = 0; i < splitted.length; i++) {
			comparedString = splitted[i].toLowerCase();
			if (comparedString.equals(word.toLowerCase())) {
				counter ++;
			}
		}
		System.out.println(counter);

	}

}
