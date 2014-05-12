import java.util.Scanner;

public class PointsInsideAFigure {
	//Write a program to check whether a point is inside or outside of the figure below. 
	//The point is given as a pair of floating-point numbers,separated by a space.
	//Your program should print "Inside" or "Outside". 
	
	public static void main(String[] args) {
		//Read the input from the console
		Scanner reader = new Scanner(System.in);
		System.out.println("Enter coordinates 'a' and 'b' separetaed by a whitespace");
		double pointA = reader.nextDouble();
		double pointB = reader.nextDouble();
		//Check for the point if it's inside the figure with the method "pointInsideFigure" 
		//and print the result
		boolean pointInside = pointInsideFigure(pointA, pointB);
		if (pointInside) {
			System.out.println("Inside");
		}
		else {
			System.out.println("Outside");
		}	
	}
	//A method to check if the point is inside the figure using three separate booleans 
	//for each rectangle(upper, left and right
	public static boolean pointInsideFigure(double pointA, double pointB){
		boolean insideUpper = (pointA >= 12.5 && pointA <= 22.5 && pointB >= 6 && pointB <= 8.5);
		boolean insideLeft = (pointA >= 12.5 && pointA <= 17.5 && pointB >= 8.5 && pointB <= 13.5);
		boolean insideRight = (pointA >= 20.0 && pointA <= 22.5 && pointB >= 8.5 && pointB <= 13.5);
		boolean insideFigure = (insideUpper || insideLeft || insideRight);
		return insideFigure;
	}

}
