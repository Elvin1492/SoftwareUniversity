import java.util.Scanner;

public class TriangleArea {
	//Write a program that enters 3 points in the plane (as integer x and y coordinates),
	//calculates and prints the area of the triangle composed by these 3 points. 
	//Round the result to a whole number. 
	//In case the three points do not form a triangle, print "0" as result
	
	public static void main(String[] args) {
	//Read the input from the console
		Scanner reader = new Scanner(System.in);
		System.out.println("Enter coordinates for point A: ");
		double aX = reader.nextDouble();
		double aY = reader.nextDouble();
		System.out.println("Enter coordinates for point B: ");
		double bX = reader.nextDouble();
		double bY = reader.nextDouble();
		System.out.println("Enter coordinates for point C: ");
		double cX = reader.nextDouble();
		double cY = reader.nextDouble();
		//Calculate the sides of the triangle by invoking the method ' calculateSides'
		double sideA = calculateSides(aX,aY,bX,bY);
		double sideB = calculateSides(bX, bY, cX, cY);
		double sideC = calculateSides(aX, aY, cX, cY);
		//Check if the points can form a triangle by invoking the method "formTriangle"
		//and calculate the triangle's area with the method "calculateArea"
		boolean legitimate = formTriangle(sideA, sideB, sideC);
		if (legitimate) {
			double triangleArea = calculateArea(sideA, sideB, sideC);
			double resultRounded = Math.round(triangleArea);
			System.out.printf("%.0f\n",resultRounded);
		}
		else {
			System.out.println("0");
		}
	}
	
	//A method to calculate the sides of the triangle
	public static double calculateSides(double ax, double ay, double bx, double by){
		double side = (double)Math.sqrt((double)Math.pow(bx-ax,2)+(double)Math.pow(by-ay,2));
		return side;
	}
	//A method to check if the three points can form a triangle
	public static boolean formTriangle(double sideA, double sideB, double sideC ){
		boolean formTriangle = 
		(sideA + sideB > sideC) && (sideA + sideC > sideB) && (sideB + sideC > sideA);
		return formTriangle;
		}
	//A method to calculate the triangle's area
	public static double calculateArea(double sideA, double sideB, double sideC){
		double p = (sideA + sideB +sideC)/2.0;
		double area = (double)Math.sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));
		return area;
	}

}
