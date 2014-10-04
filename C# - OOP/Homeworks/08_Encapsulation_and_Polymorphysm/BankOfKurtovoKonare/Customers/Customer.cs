namespace BankOfKurtovoKonare.Customers
{
    using System;

    public abstract class Customer : ICustomer
    {
        private string name;
        private int id;

        public Customer(string name, int id)
        {
            this.Name = name;
            this.ID = id;
        }

        public string Name
        {
            get
            {
                return this.name; 
            }

            protected set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 1)
                {
                    throw new ArgumentException("Customer's name can not be less than 1 charachter.");
                }

                this.name = value;
            }
        }

        public int ID
        {
            get 
            {
                return this.id;
            }

            protected set
            {
                if (value < 0 || value > 1000000)
                {
                    throw new ArgumentOutOfRangeException("ID","ID should be a number in the range [1.. 1 000 000]");    
                }

                this.id = value;
            }
        }

        public override string ToString()
        {
            return String.Format("Customer: {0}, Name: {1}, ID: {2}", this.GetType().Name, this.name, this.id);
        }
    }
}
