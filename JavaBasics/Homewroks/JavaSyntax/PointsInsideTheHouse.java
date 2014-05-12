import java.util.Scanner;

public class PointsInsideTheHouse {
	//Write a program to check whether a point is inside or outside the house below.
	//The point is given as a pair of floating-point numbers, separated by a space. 
	//Your program should print "Inside" or "Outside". 
	
	public static void main(String[] args) {
		// Read input from the console
		Scanner reader = new Scanner(System.in);
		System.out.println("Enter coordinates 'a' and 'b' on a single line"
				+ " separetaed by a whitespace: ");
		double pointA = reader.nextDouble();
		double pointB = reader.nextDouble();
		
		//Invoke the methods "insideTriangle" and "insideRectangles"
		boolean pointIsInside = insideRectangles(pointA, pointB) || insideTriangle(pointA,pointB);
		if (pointIsInside) {
			System.out.println("Inside");
		}
		else {
			System.out.println("Outside");
		}
	}
	
	//A method to check if the point is inside one of the three rectangles(right or left)
	public static boolean insideRectangles(double pointA, double pointB ){
		boolean insideLeft = (pointA >= 12.5 && pointA <= 17.5 && pointB >= 8.5 && pointB <= 13.5);
		boolean insideRight = (pointA >= 20.0 && pointA <= 22.5 && pointB >= 8.5 && pointB <= 13.5);
		boolean insideRectangles = (insideLeft || insideRight);
		return insideRectangles;
	}
	
	//A method to check if the point is inside the triangle
	public static boolean insideTriangle(double pointA,double pointB){
		//Declare the points of the triangle  ABC
	    double aX = 12.5; double aY = 8.5;
	    double bX = 22.5; double bY = 8.5;
	    double cX = 17.5; double cY = 3.5;
	//If point 'P' is inside the triangle ABC(or lies on one of its side then the sum of
	// the areas of triangle ABP + BCP + ACP == area of triangle ABC.
	    double abc = Math.abs(aX  * (bY - cY) + bX * (cY - aY) + cX * (aY - bY));
        double abp = Math.abs(aX  * (bY - pointB) + bX * (pointB - aY) + pointA * (aY - bY));
        double acp = Math.abs(aX  * (pointB - cY) + pointA * (cY - aY) + cX * (aY - pointB));
        double bcp = Math.abs(pointA * (bY - cY) + bX * (cY - pointB) + cX * (pointB - bY));
		boolean insideTriangle = (abp + acp + bcp == abc);
		return insideTriangle;
	}
	
}
