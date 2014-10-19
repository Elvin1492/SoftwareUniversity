package Geometry;

import java.util.Arrays;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;

import Geometry.Vertices.*;
import Geometry.Shape;
import Geometry.PlaneShapes.*;
import Geometry.SpaceShapes.*;
import Geometry.Interfaces.*;

public class GeometryTest {

	public static void main(String[] args) {
		
		Shape[] figures = new Shape[]{
		  new Triangle(new Vertex2D(0, 0), new Vertex2D(2,0), new Vertex2D(0,2)),
		  new Rectangle(new Vertex2D(0, 0), 5, 5),
		  new Circle(new Vertex2D(1,1),3.33),
		  new SquarePyramid(new Vertex3D(5,6,7), 4, 6),
		  new Cuboid(new Vertex3D(2,2,0),4, 5, 6),
		  new Sphere(new Vertex3D(0, -6, 8), 5.6),
		};
		
		for (Shape shape : figures) {	
			System.out.println(shape);
		}
		
		System.out.println();

		Arrays.stream(figures)
		.filter(f -> f instanceof VolumeMeasurable)
		.filter(f -> ((VolumeMeasurable)f).getVolume() > 40.0)
		.forEach(f -> System.out.println(f));
		
		System.out.println();
				
		Comparator<Shape> byPerimeter  = (f1,  f2) -> {
			PerimeterMeasurable Shape1 = (PerimeterMeasurable) f1;
			PerimeterMeasurable Shape2 = (PerimeterMeasurable) f1;			
            return (int) (Shape1.getPerimeter() - Shape2.getPerimeter()) ;
		};

		Arrays.stream(figures)
		.filter(f -> f instanceof PlaneShape)
		.sorted(byPerimeter)
		.forEach(f -> System.out.println(f));				
	}
}

