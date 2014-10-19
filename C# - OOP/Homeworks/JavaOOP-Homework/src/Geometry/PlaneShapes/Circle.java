package Geometry.PlaneShapes;

import Geometry.Vertices.Vertex;

public class Circle extends PlaneShape {
	private double radius;

	public Circle(Vertex a,double radius) {
		super(a);
		this.setRadius(radius);
	}
	
	public double getRadius() {
		return this.radius;
	}

	private void setRadius(double radius) {
		if (radius <= 0 ) {
			throw new IllegalArgumentException("Radius cannot be a negative number");
		}
		this.radius = radius;
	}

	@Override
	public double getArea() {
		double area = Math.PI * Math.pow(this.radius, 2);
		return area;
	}

	@Override
	public double getPerimeter() {
		double perimeter = 2 * Math.PI * this.radius;
		return perimeter;
	}
}
