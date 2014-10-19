package Geometry;

import Geometry.Vertices.*;

public abstract class Shape {
   protected Vertex[] vertices;

	public Shape() {
		this.vertices = new Vertex[1];
	}

	public Vertex[] getVertices() {
		return this.vertices;
	}

	@Override
	public String toString() {
		StringBuilder result = new StringBuilder();		
		result.append(this.getClass().getSimpleName().toString() + " Coordinates: ");
		for (int i = 0; i < this.vertices.length; i++) {
            if (vertices[i] == null) {
				break;
			}
			result.append("Point " + (i + 1) + vertices[i].toString());
		}
        
		return result.toString();		
	}
}
