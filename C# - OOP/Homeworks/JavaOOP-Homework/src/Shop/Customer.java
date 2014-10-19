package Shop;

public class Customer {
	private String name;
	private int age;
	private double balance;
	public Customer(String name, int age, double balane) {
		super();
		this.setName(name);
		this.setAge(age);
		this.setBalane(balane);
	}
	
	public String getName() {
		return this.name;
	}
	
	private void setName(String name) {
		if (name != null && name.length() < 2) {
			throw new IllegalArgumentException("Name can not be nul or empty");
		}
		this.name = name;
	}
	
	public int getAge() {
		return this.age;
	}
	
	private void setAge(int age) {
		if (age <= 0) {
			throw new IllegalArgumentException("Age can not be zero or negative number");
		}
		this.age = age;
	}
	
	public double getBalane() {
		return this.balance;
	}
	
	public void setBalane(double balance) {
		if (balance <= 0) {
			throw new IllegalArgumentException("Balance can not be zero or negative number");
		}
		this.balance = balance;
	}

	@Override
	public String toString() {
		return "Customer Name: " + name + ", age: " + age + ", balance: "
				+ balance + " lv.";
	}
}
