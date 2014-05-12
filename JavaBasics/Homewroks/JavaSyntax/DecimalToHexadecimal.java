import java.util.Scanner;

public class DecimalToHexadecimal {
	//Write a program that enters a positive integer number num and converts and prints it 
	//in hexadecimal form. You may use some built-in method from the standard Java libraries
	public static void main(String[] args) {
		//Read the input from the console
		Scanner reader = new Scanner(System.in);
		System.out.println("Enter a number:");
		int number = reader.nextInt();
		//print the result invoking the method "decimalToHexadecimal"
		decimalToHexadecimal(number);
		//Using the build-in java method 
		String result = Integer.toHexString(number);
		System.out.println(result);
	}
	//A method to convert the decimal number to its hexadecimal value
	public static void decimalToHexadecimal(int number){
		int remainder = 0;
		String hexadecimal = " ";
		while (number > 0) {
			remainder = number % 16 ;
			switch (remainder) {
			case 0: hexadecimal += "0";break;
			case 1: hexadecimal += "1";break;
			case 2: hexadecimal += "2";break;
			case 3: hexadecimal += "3";break;
			case 4: hexadecimal += "4";break;
			case 5: hexadecimal += "5";break;
			case 6: hexadecimal += "6";break;
			case 7: hexadecimal += "7";break;
			case 8: hexadecimal += "8";break;
			case 9: hexadecimal += "9";break;
			case 10: hexadecimal += "A";break;
			case 11: hexadecimal += "B";break;
			case 12: hexadecimal += "C";break;
			case 13: hexadecimal += "D";break;
			case 14: hexadecimal += "E";break;
			case 15: hexadecimal += "F";break;			
			default:
				break;
			}
			number = number / 16;
		}
		//Reverse the string so we can get the hexadecimal and print it
		String output = new StringBuilder(hexadecimal).reverse().toString();
		System.out.println(output);
	}
	
}
