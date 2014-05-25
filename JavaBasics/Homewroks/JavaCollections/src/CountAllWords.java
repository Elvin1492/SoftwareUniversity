import java.util.Scanner;


public class CountAllWords {
	//Write a program to count the number of words in given sentence.
	///Use any non-letter character as word separator.

	public static void main(String[] args) {
		Scanner reader = new Scanner(System.in);
		String input = reader.nextLine();
		//Split the text using any non- letter characters as separator 
		String[] splitted = input.split("[^a-zA-Z]+");
		//Get the length of the array string which is the count of words
		int countOfWords = splitted.length;
		System.out.println(countOfWords);

	}

}
