import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.nio.Buffer;
import java.util.ArrayList;
import java.util.Locale;
import java.util.Scanner;

public class OrderOfProducts {
	//Create a class Product to hold products, which have name (string) and price 
	//(decimal number). Read from a text file named "Products.txt" a list of product with
	//prices and keep them in a list of products. Each product will be in format name + space 
	//+ price. You should hold the products in objects of class Product. Read from a text file
	//named "Order.txt" an order of products with quantities. Each order line will be in format
	//product + space + quantity. Calculate and print in a text file "Output.txt" the total
	//price of the order. Ensure you close correctly all used resources. 

    public static void main(String[] args)  {
        
        ArrayList<Product> products = new ArrayList<Product>();
        //Read the products from the file products.txt and store them in an ArratList
        try (BufferedReader reader = new BufferedReader(new FileReader("src/products.txt"))){
        	String input = null;
                while ((input = reader.readLine()) != null) {
                	String[] splitted = input.split(" ");
                	products.add(new Product(splitted[0], Double.parseDouble(splitted[1])));         
                } 
        }catch (Exception exception) {
			System.err.println("Error");
			exception.printStackTrace();
		}
        //Read the orders from the file orders get the quantities and prices.Go through
        //the array list products and if the current product has a match calculate the total sum
        double result = 0;
        try (BufferedReader reader = new BufferedReader(new FileReader("src/order.txt"))) {
        	String input = null;
                while ((input = reader.readLine()) != null) {
                	    String[] splitted = input.split(" ");
                        double quantity = Double.parseDouble(splitted[0]);
                        String currentProduct = splitted[1];
                        for (Product product : products) {
                                if (product.getName().equals(currentProduct)) {
                                        result += quantity * product.getPrice();
                                }
                        }
                }     
                reader.close(); 
        }catch (Exception exception) {
        	System.err.println("Error");
			exception.printStackTrace();
		}
        //Open an output stream to store the result total price in the file total.txt
        try (BufferedWriter writer = new BufferedWriter(new FileWriter("src/total.txt"))) {
                writer.write(String.format("%.2f", result));
            writer.close();
        }catch (Exception exception) {
        	System.err.println("Error");
			exception.printStackTrace();
		}
}
}
