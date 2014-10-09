import java.awt.Canvas;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.image.BufferedImage;

/**
 * A class for the game-engine implementing the main game logic
 * @author Software University
 */
@SuppressWarnings("serial")
public class GameEngine extends Canvas implements Runnable {
	
	/**
	 *Constants holding the current game's Snake and Apple objects
	 * and the points count 
	 */
	public static Snake mySnake;
	public static Apple myApple;
	static int points;
	
	/**
	 * Private fields holding the dimensions of the game board canvas
	 */
	private Graphics globalGraphics;
	private Thread runThread;
	public static final int WIDTH = 600;
	public static final int HEIGHT = 600;
	private final Dimension gameDimensions = new Dimension(WIDTH, HEIGHT);
	
	static boolean gameRunning = false;
	
	
	/* (non-Javadoc)
	 * A method for painting the game board canvas
	 * @see java.awt.Canvas#paint(java.awt.Graphics)
	 */
	public void paint(Graphics g){
		this.setPreferredSize(gameDimensions);
		globalGraphics = g.create();
		points = 0;
		
		if(runThread == null){
			runThread = new Thread(this);
			runThread.start();
			gameRunning = true;
		}
	}
	
	/* (non-Javadoc)
	 * A method for running the game engine
	 * @see java.lang.Runnable#run()
	 */
	public void run(){
		while(gameRunning){
			mySnake.tick();
			render(globalGraphics);
			try {
				Thread.sleep(100);
			} catch (Exception e) {
				// TODO: 
			}
		}
	}
	
	/**
	 * A constructor for creating a new game
	 */
	public GameEngine(){	
		mySnake = new Snake();
		myApple = new Apple(mySnake);
	}
		
	/**
	 * A method for rendering the game objects Snake, Apple and Point
	 * @param g - AWT Graphics
	 */
	public void render(Graphics g){
		g.clearRect(0, 0, WIDTH, HEIGHT+25);
		
		g.drawRect(0, 0, WIDTH, HEIGHT);			
		mySnake.drawSnake(g);
		myApple.drawApple(g);
		g.drawString("score= " + points, 10, HEIGHT + 25);		
	}
}

