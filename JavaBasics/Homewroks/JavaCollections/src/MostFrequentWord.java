import java.util.Arrays;
import java.util.HashMap;
import java.util.Scanner;
import java.util.TreeMap;

public class MostFrequentWord {
	//Write a program to find the most frequent word in a text and print it, as well as how many times
	//it appears in format "word -> count". Consider any non-letter character as a word separator. 
	//Ignore the character casing. If several words have the same maximal frequency, print all of them 
	//in alphabetical order
	
	public static void main(String[] args) {
		//Read the input form the console, parse it to lower case and then split it from all
	    //non-letter characters 
		Scanner reader = new Scanner(System.in);
		String[] text = reader.nextLine().toLowerCase().split("[^a-zA-Z]+");
		
		//Sort the split  array alphabetically 
		Arrays.sort(text);
		
         //Create a hash-map to store the words and their frequency(number of appearance in the text
		TreeMap<String, Integer> words = new TreeMap<>();
		for (String word: text) {
			Integer frequency = words.get(word);
			if (frequency == null) {
				frequency = 0;
			}
			words.put(word, frequency + 1);
		}
		
		//Get the most frequent element in the TreeMap
		int count = 0;
		int bestCount = 0;
		for (String word : words.keySet()) {
		    count = words.get(word);
		    if (count > bestCount) {
				bestCount = count;
			}
		}
		int counter = 0;
		//Go through the TreeMap and print each word which occurs in the text "bestcount" times
		for (String word : words.keySet()) {
			counter = words.get(word);
			if (counter == bestCount) {
				System.out.println(word + " -> " + bestCount + " times");
			}		
		}	
		
		
	}

}
