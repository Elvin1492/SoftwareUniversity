import java.awt.Color;
import java.awt.Graphics;
import java.awt.Rectangle;


/**
 * @author Software University
 * A class for the main game object Point
 */

public class Point {
	
	/**
	 * Private fields for the coordinates of the point
	 * Constants for the width and height of the point
	 */
	private int coordinatesX, coordinatesY;
	private final int WIDTH = 20;
	private final int HEIGHT = 20;
	
	public Point(Point p){
		this(p.coordinatesX, p.coordinatesY);
	}
	
	/**
	 * A constructor for instancing new Point objects
	 * @param x Coordinates on the X axis for the point
	 * @param y Coordinates on the Y axis for the point
	 */
	public Point(int x, int y){
		this.coordinatesX = x;
		this.coordinatesY = y;
	}	
		
	/**
	 * A method for getting the X coordinates of a Points
	 * @return The X coordinates of a Point
	 */
	public int getCoordinatesX() {
		return this.coordinatesX;
	}
		
	/**
	 * A method for setting the X coordinates of a Points
	 * @param  X coordinates for the Point object
	 */
	public void setCoordinatesX(int x) {
		this.coordinatesX = x;
	}
	
	/**
	 * A method for getting the Y coordinates of a Points
	 * @return The Y coordinates of a Points
	 */
	public int getCoordinatesY() {
		return this.coordinatesY;
	}
	
	/**
	 * A method for setting the Y coordinates of a Points
	 * @param  The Y coordinates of a Point object
	 */
	public void setCoordinatesY(int y) {
		this.coordinatesY = y;
	}
	
	
	/**
	 * A method for drawing a point using AWT Graphics
	 * @param g AWT Graphics
	 * @param color color for the point to be drawn
	 */
	public void drawPoint(Graphics g, Color color) {
		g.setColor(Color.BLACK);
		g.fillRect(coordinatesX, coordinatesY, WIDTH, HEIGHT);
		g.setColor(color);
		g.fillRect(coordinatesX+1, coordinatesY+1, WIDTH-2, HEIGHT-2);		
	}
	
	public String toString() {
		return "[x=" + coordinatesX + ",y=" + coordinatesY + "]";
	}
	
	/* (non-Javadoc)
	 * A method for comparing if two Point objects are equal(colide)
	 * @returns a boolean expression
	 * @see java.lang.Object#equals(java.lang.Object)
	 */
	public boolean equals(Object object) {
        if (object instanceof Point) {
            Point currentPoint = (Point)object;
            return (coordinatesX == currentPoint.coordinatesX) && (coordinatesY == currentPoint.coordinatesY);
        }
        return false;
    }
}
