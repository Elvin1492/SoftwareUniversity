package Geometry.SpaceShapes;

import Geometry.SpaceShapes.*;
import Geometry.Vertices.*;

public class Cuboid extends SpaceShape {
     private double width;
     private double height;
     private double depth;
     
	public Cuboid(Vertex a, double width, double height, double depth) {
		super(a);
		this.setWidth(width);
		this.setHeight(height);
		this.setDepth(depth);
	}

	public double getWidth() {
		return this.width;
	}

	private void setWidth(double width) {
		if (width <= 0) {
			throw new IllegalArgumentException("Width can not be a negative number");
		}
		
		this.width = width;
	}

	public double getHeight() {
		return this.height;
	}

	private void setHeight(double height) {
		if (height <= 0) {
			throw new IllegalArgumentException("Height can not be a negative number");
		}
		
		this.height = height;
	}

	public double getDepth() {
		return this.depth;
	}

	private void setDepth(double depth) {
		if (depth <= 0) {
			throw new IllegalArgumentException("Depth can not be a negative number");
		}
		
		this.depth = depth;
	}

	@Override
	public double getVolume() {
		double volume  = this.width * this.height * this.depth;
		return volume;
	}

	@Override
	public double getArea() {
		double area = 2 * (this.width * this.height + this.depth * this.height + 
				this.width * this.depth);
		return area;
	}
}
