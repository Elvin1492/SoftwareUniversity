package Geometry.SpaceShapes;

import Geometry.SpaceShapes.*;
import Geometry.Vertices.*;

public class Sphere extends SpaceShape {
	private double radius;

	public Sphere(Vertex a, double radius) {
		super(a);
		this.setRadius(radius);
	}

	public double getRadius() {
		return this.radius;
	}

	private void setRadius(double radius) {
		if (radius <= 0) {
			throw new IllegalArgumentException("Radius can not be a negative number");
		}
		
		this.radius = radius;
	}

	@Override
	public double getVolume() {
		double volume = 4.0 / 3.0 * Math.PI * Math.pow(this.radius, 3);
		return volume;
	}

	@Override
	public double getArea() {
		double area = 4 * Math.PI * Math.pow(this.radius,2);
		return area;
	}
}
