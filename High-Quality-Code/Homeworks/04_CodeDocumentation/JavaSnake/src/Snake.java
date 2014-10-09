import java.awt.Color;
import java.awt.Graphics;
import java.util.LinkedList;

/**
 * A class for the Snake object
 * @author Software University
 *
 */
public class Snake{
	
	/**
	 * A private LinkedList field for storing the points of the snake body
	 * A private Color for the snakeColor
	 * A private field for X and Y coordiantes velocity 
	 */
	LinkedList<Point> snakeBody = new LinkedList<Point>();
	private Color snakeColor;
	private int velocityX, velocityY;
	
	/**
	 *A constructor for creating a new Snake object  
	 */
	public Snake() {
		snakeColor = Color.GREEN;
		snakeBody.add(new Point(300, 100)); 
		snakeBody.add(new Point(280, 100)); 
		snakeBody.add(new Point(260, 100)); 
		snakeBody.add(new Point(240, 100)); 
		snakeBody.add(new Point(220, 100)); 
		snakeBody.add(new Point(200, 100)); 
		snakeBody.add(new Point(180, 100));
		snakeBody.add(new Point(160, 100));
		snakeBody.add(new Point(140, 100));
		snakeBody.add(new Point(120, 100));

		velocityX = 20;
		velocityY = 0;
	}
	
	/**
	 * A method for drawing a Snake object using AWT Graphics
	 * @param  AWT Graphics
	 */
	public void drawSnake(Graphics g) {		
		for (Point point : this.snakeBody) {
			point.drawPoint(g, snakeColor);
		}
	}
	
	/**
	 * A method for adding new Point objects to the Snake body and checking if the Snake 
	 * object has hit a wall or itself
	 */
	public void tick() {
		Point newPointPosition = new Point((snakeBody.get(0).getCoordinatesX() + velocityX), 
				(snakeBody.get(0).getCoordinatesY() + velocityY));
		
		if (newPointPosition.getCoordinatesX() > GameEngine.WIDTH - 20) {
		 	GameEngine.gameRunning = false;
		} else if (newPointPosition.getCoordinatesX() < 0) {
			GameEngine.gameRunning = false;
		} else if (newPointPosition.getCoordinatesY() < 0) {
			GameEngine.gameRunning = false;
		} else if (newPointPosition.getCoordinatesY() > GameEngine.HEIGHT- 20) {
			GameEngine.gameRunning = false;
		} else if (GameEngine.myApple.getApple().equals(newPointPosition)) {
			snakeBody.add(GameEngine.myApple.getApple());
			GameEngine.myApple = new Apple(this);
			GameEngine.points += 50;
		} else if (snakeBody.contains(newPointPosition)) {
			GameEngine.gameRunning = false;
			System.out.println("You ate yourself");
		}	
		
		for (int i = snakeBody.size()-1; i > 0; i--) {
			snakeBody.set(i, new Point(snakeBody.get(i-1)));
		}	
		snakeBody.set(0, newPointPosition);
	}

	/**
	 * A method for getting the X coordinates velocity
	 * @return - X coordinates velocity
	 */
	public int getVelocityX() {
		return this.velocityX;
	}

	/**
	 * A method for setting the X coordinates velocity
	 * @param velocityX - X coordinates velocity
	 */
	public void setVelocityX(int velocityX) {
		this.velocityX = velocityX;
	}

	/**
	 * A method for getting the Y  coordinates velocity
	 * @return -Y coordinates velocity
	 */
	public int getVelocityY() {
		return this.velocityY;
	}

	/**
	 * A method for setting the Y coordinates velocity
	 * @param velocityY - Y coordinates velocity
	 */
	public void setVelocityY(int velocityY) {
		this.velocityY = velocityY;
	}
}
