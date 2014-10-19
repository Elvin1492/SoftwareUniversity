package Shop;


import Shop.Interfaces.Buyable;

public abstract class Product implements Buyable {
	private String name;
	protected double price;
	private int quantity;
	private AgeRestriction ageRestrication;
	
	public Product(String name, double price, int quantity,
			AgeRestriction ageRestrication) {
		super();
		this.setName(name);
		this.setPrice(price);;
		this.setQuantity(quantity);
		this.setAgeRestrication(ageRestrication);;
	}

	public String getName() {
		return this.name;
	}
	
	private void setName(String name) {
		if (name == null || name.length() < 2) {
			throw new IllegalArgumentException("Name can not be null or an empty string");
		}
		
		this.name = name;
	}
	
	public double getPrice() {
		return this.price;
	}
	
	private void setPrice(double price) {
		if (price < 0.0) {
			throw new IllegalArgumentException("Price cannot be zero or negative");
		}
		
		this.price = price;
	}
	
	public int getQuantity() {
		return this.quantity;
	}
	
	public void setQuantity(int quantity) {
		if (quantity <= 0) {
			throw new IllegalArgumentException("Qunatity can not be zero or a negative number");
		}
		
		this.quantity = quantity;
	}
	
	public AgeRestriction getAgeRestrication() {
		return this.ageRestrication;
	}
	
	private void setAgeRestrication(AgeRestriction ageRestrication) {
		this.ageRestrication = ageRestrication;
	}

	@Override
	public String toString() {
		return  this.getClass().getSimpleName() + " Name: " + this.name + ", Price: " +
				this.getPrice() + " lv. , Quantity: " + this.quantity + ", Age Restrication: " +
				this.ageRestrication;
	}		
}
