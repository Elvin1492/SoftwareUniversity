package Geometry.PlaneShapes;

import Geometry.Shape;
import Geometry.Vertices.*;
import Geometry.Interfaces.*;

public abstract class PlaneShape extends Shape implements PerimeterMeasurable, AreaMeasurable{

	public PlaneShape(Vertex a) {
		this.vertices = new Vertex2D[3];
		this.vertices[0] = a;
	}
	
	@Override
	public abstract double getArea();

	@Override
	public abstract double getPerimeter();

	@Override
	public String toString() {
		String result = String.format("Perimeter: %.2f, Area: %.2f" , this.getPerimeter(), this.getArea());
		return super.toString() + result;
	}
}