package Shop;

import Shop.FoodProducts.FoodProduct;
import Shop.Interfaces.Expireable;
import Shop.PurchaseManagerExceptions.PurchaseManagerException;
import Shop.PurchaseManagerExceptions.ProductHasExpiredException;
import Shop.PurchaseManagerExceptions.ProductOutOfStockException;
import Shop.PurchaseManagerExceptions.CustomerBalanceException;
import Shop.PurchaseManagerExceptions.NoPermisionToBuyException;

public final class PurchaseManager {
	public static void ProcessPurchase(Customer customer, Product product) throws 
	PurchaseManagerException {
		if (product.getQuantity() == 0) {
			throw new ProductOutOfStockException();
		}

		if (product instanceof Expireable && ((FoodProduct) product).isExpired()) {
				throw new ProductHasExpiredException();
		}
		
		if (customer.getBalane() < product.getPrice()) {
			throw new CustomerBalanceException();
		}
		
		if (customer.getAge() < 18 && product.getAgeRestrication() == AgeRestriction.ADULT) {
			throw new NoPermisionToBuyException();
		}
		
		customer.setBalane(customer.getBalane() - product.getPrice());
		product.setQuantity(product.getQuantity() - 1);
	}
}
