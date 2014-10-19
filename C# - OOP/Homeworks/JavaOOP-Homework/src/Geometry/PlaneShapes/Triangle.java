package Geometry.PlaneShapes;

import Geometry.Vertices.Vertex;

public class Triangle extends PlaneShape{
	
	public Triangle(Vertex a,Vertex b, Vertex c){
		super(a);
		this.vertices[1] = b;
		this.vertices[2] = c;
		if (!triangleIsValid()) {
			throw new IllegalArgumentException("These three vertices do not form a triangle");
		}
	}

	@Override
	public double getArea() {
		double semiPerimeter =this.getPerimeter() / 2;
		double area = Math.sqrt(semiPerimeter * 
				(semiPerimeter - this.distanceAB()) * 
				(semiPerimeter - this.distanceBC()) *
				(semiPerimeter - this.distanceAC()));
		return area;
	}

	@Override
	public double getPerimeter() {
		double perimeter  = this.distanceAB() + this.distanceBC() + this.distanceAC();
		return perimeter;
	}
	
	private double distanceAB(){
		double distanceAB = Vertex.distanceBetweenPoints(this.vertices[0], this.vertices[1]);
		return distanceAB;
	}
	
	private double distanceBC(){
		double distanceBC = Vertex.distanceBetweenPoints(this.vertices[1], this.vertices[2]);
		return distanceBC;
	}
	
	private double distanceAC(){
		double distanceAC = Vertex.distanceBetweenPoints(this.vertices[0], this.vertices[2]);
		return distanceAC;
	}
	
	private boolean triangleIsValid(){
		 return (this.distanceAB() + this.distanceAC() > this.distanceBC() &&
				 this.distanceBC() + this.distanceAC() > this.distanceAB() &&
				 this.distanceAB() + this.distanceBC() > this.distanceAC());
				 
	}

}