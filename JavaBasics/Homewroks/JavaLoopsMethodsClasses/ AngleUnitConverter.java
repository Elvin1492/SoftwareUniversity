import java.awt.font.NumericShaper;
import java.util.Scanner;

public class AngleUnitConverter {
	//Write a method to convert from degrees to radians. Write a method to convert from radians 
	//to degrees. You are given a number n and n queries for conversion. Each conversion query 
	//will consist of a number + space + measure. Measures are "deg" and "rad".
	//Convert all radians to degrees and all degrees to radians. Print the results as n lines,
	//each holding a number + space + measure. 
	
	public static void main(String[] args) {
	  Scanner reader = new Scanner(System.in);
	  System.out.println("Enter number 'n' to determine the number of entries: ");
	  int n = Integer.parseInt(reader.nextLine());
	  double[] numbers = new double[n];
	  String[] measure = new String[n];
	//Read the double and store it in the double array 
	//read the next text on the line and store in the String array   
	  for (int i = 0; i < n; i++) {
		  if (reader.hasNextDouble()) {
			  numbers[i] = reader.nextDouble();
		}
		  if (reader.hasNext()) {
			  measure[i] = reader.next();
		}
	  }
	  //Go through both arrays 'n' times check for the string value and invoke one of the methods
	  for (int i = 0; i < n; i++) {
	    if (measure[i].equals("rad")) {
			radiansToDegrees(numbers[i]);
		}
	    else if(measure[i].equals("deg")) {
			degreesToRadians(numbers[i]);
		}
	  }	
	}
	
	//A method to convert degrees to radians
	public static void degreesToRadians(double degrees){
		double radians = (degrees * (double)Math.PI) / 180.0d;
		System.out.printf("%.6f rad\n",radians);		
	}
	//A method to convert radians to degrees
	public static void radiansToDegrees(double radians){
		double degrees = radians * (180.0d /(double)Math.PI);
		System.out.printf("%.6f deg\n ",degrees);		
	}

}
