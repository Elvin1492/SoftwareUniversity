package Geometry.PlaneShapes;

import Geometry.Vertices.*;

public class Rectangle  extends PlaneShape{
    private double width;
    private double height;
    
	public Rectangle(Vertex a, double width, double height){
		super(a);		
		this.setWidth(width);
		this.setHeight(height);
	}
	
	public double getWidth() {
		return this.width;
	}

	private void setWidth(double width) {
		if (width <= 0 ) {
			throw new IllegalArgumentException("Width cannot be a negative number");
		}
		this.width = width;
	}

	public double getHeight() {
		return this.height;
	}
	
	private void setHeight(double height) {
		if (height <= 0) {
			throw new IllegalArgumentException("Height cannot be a negative number");
		}
		this.height = height;
	}

	@Override
	public double getArea() {
		double area = this.width * this.height;
		return area;
	}

	@Override
	public double getPerimeter() {
		double perimeter = 2 * (this.width + this.height);
		return perimeter;
	}

}
