import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class CombineListsOfLetters {
	//Write a program that reads two lists of letters l1 and l2 and combines them: appends all letters
	//c from l2 to the end of l1, but only when c does not appear in l1. Print the obtained combined list. 
	///All lists are given as sequence of letters separated by a single space, each at a separate line. 
	//Use ArrayList<Character> of chars to keep the input and output lists

	public static void main(String[] args) {
		//Read the input and parse it to char arrays
		Scanner reader = new Scanner(System.in);
		char[] l1 = reader.nextLine().replaceAll(" ", "").toCharArray();
		char[] l2 = reader.nextLine().replaceAll(" ", "").toCharArray();
		
		//Create two char ArrayLists and add the char arrays elements to them
		ArrayList<Character> list1 = new ArrayList<>();
		ArrayList<Character> list2 = new ArrayList<>();     
		for (int i = 0; i < l1.length; i++) {
			list1.add(l1[i]);
		}
		for (int i = 0; i < l2.length; i++) {
		    list2.add(l2[i]);	
		}

		//remove from list2 all characters appearing in list1 and then add list2 to list1;
		list2.removeAll(list1);
		list1.addAll(list2);
		for (Character character : list1) {
			System.out.print(character + " ");
		}
		System.out.println();
	}
}
