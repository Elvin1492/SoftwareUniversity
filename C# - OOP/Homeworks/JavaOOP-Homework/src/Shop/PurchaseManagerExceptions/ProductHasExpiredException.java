package Shop.PurchaseManagerExceptions;

public class ProductHasExpiredException extends PurchaseManagerException {
	public ProductHasExpiredException() {
		super("This product has expired");
	}
}
