package Shop.ElectonicsProducts;

import Shop.AgeRestriction;
import Shop.Product;


public abstract class ElectonicsProduct extends Product{
	protected int guarantee;
 
	public ElectonicsProduct(String name, double price, int quantity,
			AgeRestriction ageRestrication) {
		super(name, price, quantity, ageRestrication);
	}
		
	public int getGuarantee() {
		return this.guarantee;
	}

	protected void setGuarantee(int guarantee) {
		this.guarantee = guarantee;
	}

	@Override
	public String toString() {
		return super.toString() + "\nGuarantee period: " + this.guarantee + " months";
	}
}
