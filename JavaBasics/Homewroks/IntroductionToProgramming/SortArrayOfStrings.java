import java.util.Scanner;
import java.util.Arrays;
public class SortArrayOfStrings {

	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		System.out.println("Enter the number of elements you want to sort:");
		int n = sc.nextInt();
		//Declare an array and use a for loop to read the strings entered from the console
		String[] myArray = new String[n];
		for(int i = 0; i < n; i++){
			myArray[i] = sc.next();
		}
		//Sort the array with the build-in method "sort" from the class Arrays and print the 
		//elements of the the array with a for loop
		Arrays.sort(myArray);
		for(int j = 0; j < n; j++){
			System.out.print(myArray[j] + " ");
		}
		sc.close();
	}
}
