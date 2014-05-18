import java.util.Scanner;

public class SymmetricNumbersInRange {
	//Write a program to generate and print all symmetric numbers in given range [start…end].
	//A number is symmetric if its digits are symmetric toward its middle. 
	//For example, the numbers 101, 33, 989 and 5 are symmetric,
	//but 102, 34 and 997 are not symmetric

	public static void main(String[] args) {
		Scanner reader = new Scanner(System.in);
		System.out.println("Enter a range of numbers [start.....end]: ");
		int start = reader.nextInt();
		int end = reader.nextInt();
		//Go through the numbers with a for loop invoke the method "symmetricNumber"
		//every time to check if the numbers is symmetric and print it if it is.
		for (int i = start; i <= end; i++) {
			if (symmetricNumber(i)) {
				System.out.printf("%d ", i);
			}	
		}
	}
	//A method to check for a number if its symmetric
	public static Boolean symmetricNumber(int number){
		boolean isSymmetric = false;
		String input = Integer.toString(number);
			for (int i = 0; i < input.length() / 2; i++) {
				if (input.charAt(i) == input.charAt(input.length() -1- i)) {
					isSymmetric = true;
				}
				else {
					isSymmetric = false;
					break;
				}
			}
		return isSymmetric;
	}
}
