import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class ListOfProducts{
	//Create a class Product to hold products, which have name (string) and price (decimal number).
	//Read from a text file named "Input.txt" a list of products. Each ;product will be in format name 
	//+ space + price. You should hold the products in objects of class Product. Sort the products
	//by price and write them in format price + space + name in a file named "Output.txt".
	//Ensure you close correctly all used resources. 
	
	public static void main(String args[]){
		//Create an Array list of type 'Product' to store the products
		ArrayList<Product> products  = new ArrayList<Product>();
		//Open the file 'input.txt' to read from it and copy/write to file 'output.txt'
		try{
			BufferedReader reader = new BufferedReader(new FileReader("src/input.txt"));
			BufferedWriter writer = new BufferedWriter(new FileWriter("src/output.txt"));
			String input;
			while ((input = reader.readLine()) != null) {
				String[] splited = input.split(" ");
				products.add(new Product(splited[0], Double.parseDouble(splited[1])));
			}
			
			Collections.sort(products);
			for (Product product : products) {
				writer.write(product.getPrice() + " " + product.getName() +"\r\n");
			}
			reader.close();
			writer.close();
		} catch (IOException exeption) {
			System.out.println("Error");
            exeption.printStackTrace(); 
		}	
	}
}
