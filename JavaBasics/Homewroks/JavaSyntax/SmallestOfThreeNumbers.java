import java.util.Scanner;
import java.text.*;

public class SmallestOfThreeNumbers {
	//Write a program that finds the smallest of three numbers. 
	public static void main(String[] args) {
	//Read the input from the console
		Scanner reader = new Scanner(System.in);
		DecimalFormat df = new DecimalFormat("0.######");
		System.out.println("Enter three numbers: ");
		double firstNum = reader.nextDouble();
		double secondNum = reader.nextDouble();
		double thirdNUm = reader.nextDouble();
	//Check for the smallest of the three numbers invoking the method "smallestNumber"
        double smallestNum = smallestNumber(firstNum, secondNum, thirdNUm);
       System.out.println(df.format(smallestNum));    
	}
	//A method to find the smallest number
	public static double smallestNumber(double a,double b, double c){
		double smallest = a;
		if (smallest >= b) {
			smallest = b;
		}
		 if (smallest >= c) {
			smallest = c;
		} 		
		return smallest;
	}

}
