package Shop.PurchaseManagerExceptions;

public class CustomerBalanceException extends PurchaseManagerException{
	public CustomerBalanceException() {
		super("Customers balance: insufficient funds ");
	}
}
