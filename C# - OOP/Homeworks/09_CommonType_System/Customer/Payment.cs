namespace Customer
{
    using System;
    using System.Collections.Generic;

    public class Payment : ICloneable
    {
        private string productName;
        private decimal price;

        public Payment(string productName, decimal price)
        {
            this.ProductName = productName;
            this.Price = price;
        }

        public string ProductName 
        {
            get { return this.productName; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Product name", "Product name can not be null.");
                }
                if (value.Length < 2)
                {
                    throw new ArgumentException("Product name can not be less than two charachters.");
                }

                this.productName = value;
            }
        }

        public decimal Price 
        {
            get { return this.price; }
            private set
            {
                if (value < 0 )
                {
                    throw new ArgumentOutOfRangeException("Product price","Price can not be a negative number.");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            return String.Format("Product: {0}, Price: {1}", this.productName, this.price);
        }

        public object Clone()
        {
            Payment paymentClone = new Payment(this.productName, this.price);
            return paymentClone as Payment;
        }
    }
}
