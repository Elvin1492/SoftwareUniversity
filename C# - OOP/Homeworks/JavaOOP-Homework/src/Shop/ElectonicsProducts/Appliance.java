package Shop.ElectonicsProducts;

import Shop.AgeRestriction;

public class Appliance extends ElectonicsProduct {

	public Appliance(String name, double price, int quantity,
			AgeRestriction ageRestrication) {
		super(name, price, quantity, ageRestrication);
		this.setGuarantee(6);
	}
	
	@Override
	public double getPrice() {
		if (this.getQuantity() < 50) {
			 this.price *= 1.05;
		}
		return this.price;
	}	
}
