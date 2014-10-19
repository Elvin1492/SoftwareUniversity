package Shop.ElectonicsProducts;

import Shop.AgeRestriction;

public class Computer  extends ElectonicsProduct{

	public Computer(String name, double price, int quantity,
			AgeRestriction ageRestrication) {
		super(name, price, quantity, ageRestrication);
		this.setGuarantee(24);
	}
	
	@Override
	public double getPrice() {
		if (this.getQuantity() > 1000) {
			 this.price *= 0.95;
		}
		return this.price;
	}
}
