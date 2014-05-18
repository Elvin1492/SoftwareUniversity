import java.util.Scanner;

public class Generate3LetterWords {
	//Write a program to generate and print all 3-letter words consisting of given set of 
	//characters. For example if we have the characters 'a' and 'b', all possible words 
	//will be "aaa", "aab", "aba", "abb", "baa", "bab", "bba" and "bbb". The input
	//characters are given as string at the first line of the input. Input characters are
	//unique (there are no repeating characters). 
	
	public static void main(String[] args) {
        Scanner reader = new Scanner(System.in);
        String input = reader.nextLine();
        char[] letters = input.toCharArray();
		//Print the combinations				
		for (int i = 0; i < input.length(); i++) {
			for (int j = 0; j < input.length(); j++) {
				for (int j2 = 0; j2 < input.length(); j2++) {
				System.out.printf("%s%s%s ", letters[i], letters[j],letters[j2]);	
				}
			}
		}
	}
}
