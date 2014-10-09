import java.awt.Color;
import java.awt.Graphics;
import java.util.Random;

/**
 * A class for the Apple object
 * @author Software University
 */
public class Apple {
	
	/**
	 * A private random generator
	 * A private apple (Point object)
	 * A private color for the apple
	 */
	public static Random randomGenerator;
	private Point apple;
	private Color appleColor;
	
	/**
	 * A constructor for creating a new Apple object
	 * @param s - a snake object
	 */
	public Apple(Snake s) {
		apple = createApple(s);
		appleColor = Color.RED;		
	}
	
	/**
	 * A method for creating a new random Apple object on the game board
	 * @param s - the current Snake object
	 * @return - a new Apple object(Point) on the game board
	 */
	private Point createApple(Snake s) {
		randomGenerator = new Random();
		int x = randomGenerator.nextInt(30) * 20; 
		int y = randomGenerator.nextInt(30) * 20;
		for (Point snakePoint : s.snakeBody) {
			if (x == snakePoint.getCoordinatesX() || y == snakePoint.getCoordinatesY()) {
				return createApple(s);				
			}
		}
		return new Point(x, y);
	}
	
	
	/**
	 * @param g
	 */
	public void drawApple(Graphics g){
		apple.drawPoint(g, appleColor);
	}	
	
	/**
	 * A method for getting the current Apple object
	 * @return - a Point object
	 */
	public Point getApple(){
		return apple;
	}
}
