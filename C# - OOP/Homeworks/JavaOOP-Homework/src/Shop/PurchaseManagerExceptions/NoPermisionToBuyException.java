package Shop.PurchaseManagerExceptions;

public class NoPermisionToBuyException extends PurchaseManagerException {
	public NoPermisionToBuyException() {
		super("The customer has no permission to buy this product.");
	}
}
