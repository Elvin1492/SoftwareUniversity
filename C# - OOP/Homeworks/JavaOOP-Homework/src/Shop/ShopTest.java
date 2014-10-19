package Shop;

import java.util.Arrays;
import java.util.Comparator;
import java.util.List;

import Geometry.Shape;
import Geometry.Interfaces.PerimeterMeasurable;
import Shop.Product;
import Shop.FoodProducts.*;
import Shop.ElectonicsProducts.*;
import Shop.PurchaseManagerExceptions.*;
import Shop.Interfaces.*;

public class ShopTest {
	public static void main(String[] args){
	  	Product cigars = new FoodProduct("420 Blaze it fgt", 
	  			6.90, 1400, AgeRestriction.ADULT, "2014-11-11");
	  	Customer pecata = new Customer("Pecata", 17, 30.00);
	  	Customer gopeto = new Customer("Gopeto", 18, 0.44);
	  	Customer baiStavrii = new Customer("Stavrii", 88, 888.88);
	  	
	  	System.out.println(cigars);
	  	System.out.println(pecata);
	  	try {
	  		PurchaseManager.ProcessPurchase(pecata, cigars);
		} catch (PurchaseManagerException exception) {
			System.err.println(exception.getMessage());
		}
	  	
	  	System.out.println(gopeto);
	  	try {
	  		PurchaseManager.ProcessPurchase(gopeto, cigars);
		} catch (PurchaseManagerException exception) {
			System.err.println(exception.getMessage());
		}

	  	System.out.println(baiStavrii);
	  	try {
	  		PurchaseManager.ProcessPurchase(baiStavrii, cigars);
		} catch (PurchaseManagerException exception) {
			System.err.println(exception.getMessage());
		}
	  	
	  	System.out.println("Cigars quantity: " +cigars.getQuantity());
	  	System.out.println("Bai Stavrii's balance: " + baiStavrii.getBalane());
	  	System.out.println();
	  	
	  	List<Product> productsList = Arrays.asList(
	  			new FoodProduct("Whiskey", 33.79, 666, AgeRestriction.ADULT, "2114-10-30"),
	  			new FoodProduct("Bananas", 3.79, 1000, AgeRestriction.NONE, "2014-10-30"),  			
	  			new Computer("Toshiba Satelite", 1333.79, 33, AgeRestriction.NONE),
	  			new Appliance("Refrigerator", 2333.79, 333, AgeRestriction.NONE),
	  			new Appliance("TV SET", 3333.79, 133, AgeRestriction.NONE),
	  			new FoodProduct("Beer", 1.79, 1111, AgeRestriction.ADULT, "2014-12-31")
	  			);
	  	
	  	Comparator<Product> byDateOfExpiry = (p1, p2) -> Long.compare(
	  			((FoodProduct) p1).getDaysUntilExpiry(), ((FoodProduct) p2).getDaysUntilExpiry());
		
	  	System.out.println(productsList.stream()
	  	.filter(pr -> pr instanceof Expireable)
	  	.sorted(byDateOfExpiry)
	  	.findFirst().get().getName());
	  	
	  	System.out.println();
	  	
	  	Comparator<Product> byPrice = (pr1, pr2) -> Double.compare(
	  		pr1.getPrice(), pr2.getPrice());
	  	
	    productsList.stream()
	  	.filter(pr -> pr.getAgeRestrication() == AgeRestriction.ADULT)
	  	.sorted(byPrice)
	  	.forEach(pr -> System.out.println(pr));
	}
}
