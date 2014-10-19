package Shop.PurchaseManagerExceptions;

public class ProductOutOfStockException extends PurchaseManagerException {
	public ProductOutOfStockException() {
		super("This product is out of stock.");
		
	}
}
