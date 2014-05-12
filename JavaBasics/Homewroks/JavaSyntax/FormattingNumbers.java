
import java.util.Scanner;

public class FormattingNumbers {
	//Write a program that reads 3 numbers: an integer a (0 ≤ a ≤ 500), a floating-point b and a 
	//floating-point c and prints them in 4 virtual columns on the console. 
	
	public static void main(String[] args) {
		//Read the input from the console
		Scanner reader = new Scanner(System.in);
		System.out.println("Enter 3 numbers: an integer 'a' , and floating-points 'b' and 'c'\n"
				+ "on a sigle line: ");
		int a = reader.nextInt();
		double b = reader.nextDouble();
		double c = reader.nextDouble();
		String hexadcimal = Integer.toHexString(a).toUpperCase();
		String binary = String.format("%10s", Integer.toBinaryString(a)).replace(' ', '0');
		
		//if 'c' is a whole number we print it without digits after the sign
		if ( c == Math.floor(c)) {
			System.out.printf("|%-10s|%s|%10.2f|%-10.0f|\n",hexadcimal,binary,b,c);
		}
		else {
			System.out.printf("|%-10s|%s|%10.2f|%-10.3f|\n",hexadcimal,binary,b,c);
		}		
	}

}
