import java.util.Scanner;

public class RectangleArea {
	//Write a program that enters the sides of a rectangle (two integers a and b)
	//and calculates and prints the rectangle's area. Examples:
	public static void main(String[] args) {
		//Read the input from the console
		Scanner reader = new Scanner(System.in);
		System.out.println("Enter an integer number for side A: ");
		int sideA = Integer.parseInt(reader.next());
		System.out.println("Enter an integer number for side B: ");
		int sideB = Integer.parseInt(reader.next());
		//Invoke the method for calculation  and print the result
		calculateRectangleAra(sideA, sideB);
	}
	//A method for the calculation of the rectangle's area
	public static void calculateRectangleAra(int sideA, int sideB){
		int rectangleArea = 2 * (sideA + sideB);
		System.out.printf("The rectangle's area is: %d\n",rectangleArea);
	}
}
