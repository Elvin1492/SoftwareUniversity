import java.util.Scanner;

public class CountOfEqualBitPairs {
//Write a program to count how many sequences of two equal bits ("00" or "11") can be found in 
//the binary representation of given integer number n (with overlapping). 
	
	public static void main(String[] args) {
		//Read input from the console
		Scanner reader = new Scanner(System.in);
		System.out.println("Enter a positive integer number: ");
		int number = reader.nextInt();
		//Invoke the method "bitsPairCounter"
		bitsPairCounter(number);
		}
	
	//A method to count the equal bits pairs in the binary representation of an integer
	public static void bitsPairCounter(int num){
		String binaryNumber = Integer.toBinaryString(num);
		int counter = 0;
		for (int i = 0; i < binaryNumber.length() - 1; i++) {
			if (binaryNumber.charAt(i) == binaryNumber.charAt(i + 1)) {
				counter ++;
			}
		}
		System.out.println(counter);
	}

}
