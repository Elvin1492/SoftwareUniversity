package Geometry.SpaceShapes;

import Geometry.Vertices.*;

public class SquarePyramid extends SpaceShape{
	private double baseWidth;
	private double height;
	
	public SquarePyramid(Vertex a, double baseWidth, double height) {
		super(a);
		this.setBaseWidth(baseWidth);
		this.setHeight(height);
	}

	public double getBaseWidth() {
		return this.baseWidth;
	}

	private void setBaseWidth(double baseWidth) {
		if (baseWidth <= 0) {
			throw new IllegalArgumentException("Base width can not be a negative number.");
		}
		this.baseWidth = baseWidth;
	}

	public double getHeight() {
		return this.height;
	}

	private void setHeight(double height) {
		if (height <= 0) {
			throw new IllegalArgumentException("Height can not be a negative number.");
		}
		this.height = height;
	}

	@Override
	public double getVolume() {
		double volume = Math.pow(this.baseWidth,2) / 3 * this.height;
		return volume;
	}

	@Override
	public double getArea() {
		double area = this.baseWidth * (this.baseWidth + 
				Math.sqrt(Math.pow(this.baseWidth, 2) + 4 * Math.pow(this.height, 2)));
		return area;
	}
}
