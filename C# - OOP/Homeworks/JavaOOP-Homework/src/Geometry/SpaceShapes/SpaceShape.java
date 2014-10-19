package Geometry.SpaceShapes;

import java.util.Arrays;

import Geometry.Shape;
import Geometry.Interfaces.*;
import Geometry.Vertices.*;

public abstract class SpaceShape extends Shape implements AreaMeasurable, VolumeMeasurable {
	public SpaceShape(Vertex a) {
		this.vertices = new Vertex3D[1];
		this.vertices[0] = a;
	}

	@Override
	public abstract double getVolume();

	@Override
	public abstract double getArea();

	@Override
	public String toString() {
		String result = String.format("Volume: %.2f, Area: %.2f" , this.getVolume(), this.getArea());
		return super.toString() + result;
	}
}
