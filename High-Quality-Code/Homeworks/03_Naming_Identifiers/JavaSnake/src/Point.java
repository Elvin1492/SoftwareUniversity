import java.awt.Color;
import java.awt.Graphics;
import java.awt.Rectangle;

public class Point {
	private int coordinatesX, coordinatesY;
	private final int WIDTH = 20;
	private final int HEIGHT = 20;
	
	public Point(Point p){
		this(p.coordinatesX, p.coordinatesY);
	}
	
	public Point(int x, int y){
		this.coordinatesX = x;
		this.coordinatesY = y;
	}	
		
	public int getCoordinatesX() {
		return this.coordinatesX;
	}
	public void setCoordinatesX(int x) {
		this.coordinatesX = x;
	}
	public int getCoordinatesY() {
		return this.coordinatesY;
	}
	public void setCoordinatesY(int y) {
		this.coordinatesY = y;
	}
	
	public void drawPoint(Graphics g, Color color) {
		g.setColor(Color.BLACK);
		g.fillRect(coordinatesX, coordinatesY, WIDTH, HEIGHT);
		g.setColor(color);
		g.fillRect(coordinatesX+1, coordinatesY+1, WIDTH-2, HEIGHT-2);		
	}
	
	public String toString() {
		return "[x=" + coordinatesX + ",y=" + coordinatesY + "]";
	}
	
	public boolean equals(Object object) {
        if (object instanceof Point) {
            Point currentPoint = (Point)object;
            return (coordinatesX == currentPoint.coordinatesX) && (coordinatesY == currentPoint.coordinatesY);
        }
        return false;
    }
}
