package Geometry.Vertices;

public abstract class Vertex {
	protected double x;
	protected double y;
	
	public Vertex(double x, double y) {
		this.setX(x);
		this.setY(y); 
	}
	
	public double getX() {
		return x;
	}

	private void setX(double x) {
		this.x = x;
	}

	public double getY() {
		return y;
	}

	private void setY(double y) {
		this.y = y;
	}
	
	public static double distanceBetweenPoints(Vertex a, Vertex b){
		double result = Math.sqrt(
				Math.pow(a.getX() - b.getX(), 2) +
				Math.pow(a.getY() - b.getY(), 2));
		return result;		
	}

	@Override
	public String toString() {
		return "[x=" + this.x + ", y=" + this.y + "] ";
	}
}
