namespace Customer 
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Customer : IComparable<Customer>, ICloneable
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private string id;
        private string address;
        private string mobilePhone;
        private string email;
        private List<Payment> payments;
        private CustomerType type;

        public Customer(string firstName, string middleName,string lastName, string id, string address, string mobilePhone,
            string email, List<Payment> payments, CustomerType type)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Id = id;
            this.Address = address;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Payments = payments;
            this.Type = type;
        }

        public string FirstName
        {
            get { return this.firstName; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("First name", "First name can not be null.");
                }
                if (value.Length < 2)
                {
                    throw new ArgumentException("First name can not be less than two charachters.");
                }

                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get { return this.middleName; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Middle name", "First name can not be null.");
                }
                if (value.Length < 2)
                {
                    throw new ArgumentException("Middle name can not be less than two charachters.");
                }

                this.middleName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Last name", "Last name can not be null.");
                }
                if (value.Length < 2)
                {
                    throw new ArgumentException("Last name can not be less than two charachters.");
                }

                this.lastName = value;
            }
        }

        public string Id
        {
            get { return this.id; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("ID", "ID can not be null.");
                }
                if (value.Length != 10)
                {
                    throw new ArgumentException("ID should be a ten digit number.");
                }

                foreach (var charachter in value)
                {
                    if (!Char.IsDigit(charachter))
                    {
                        throw new ArgumentException("ID should contain only digits");
                    }
                }

                this.id = value;
            }
        }

        public string Address
        {
            get { return this.address; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Address", "Address can not be null.");
                }

                this.address = value;
            }
        }

        public string MobilePhone
        {
            get { return this.mobilePhone; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Mobile Phone", "Mobile Phone can not be null.");
                }
                if (value.Length != 10)
                {
                    throw new ArgumentException("Mobile Phone should be a ten digit number.");
                }

                foreach (var charachter in value)
                {
                    if (!Char.IsDigit(charachter))
                    {
                        throw new ArgumentException("Mobile Phone should contain only digits");
                    }
                }

                this.mobilePhone = value;
            }
        }

        public string Email
        {
            get { return this.email; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Email", "Email can not be null.");
                }

                var email = new System.Net.Mail.MailAddress(value);
                if (!(email.Address == value))
                {
                    throw new ArgumentException("Email is not valid.");
                }

                this.email= value;
            }
        }

        public List<Payment> Payments 
        {
            get { return new List<Payment>(this.payments); }
            private set
            {
                this.payments = new List<Payment>(value);
            }
        }

        public CustomerType Type 
        {
            get { return this.type; }
            set
            {
                this.type = value;
            }
        }

        public override bool Equals(object anotherCustomer)
        {
            Customer otherCustomer = anotherCustomer as Customer;

            if (otherCustomer == null)
            {
                return false; 
            }

            if (this.firstName == otherCustomer.firstName &&
                this.middleName == otherCustomer.middleName &&
                this.lastName == otherCustomer.lastName &&
                this.id == otherCustomer.id)
            {
                return true;
            }

            return false;
        }

        public void AddPayment(Payment newPayment)
        {
            this.payments.Add(newPayment);
        }

        public override string ToString()
        {
            StringBuilder paymentsList = new StringBuilder();
            foreach (var payment in this.payments)
            {
                paymentsList.AppendLine(payment.ToString());
            }

            string payments = paymentsList.ToString();

            return String.Format("Name: {0} {1} {2}, ID: {3}\nAddress: {4}, Phone: {5}, Email: {6}\nPaymetns:\n{7}" + 
            "Customer Type: {8}", this.firstName, this.middleName, this.lastName, this.id, this.address, this.mobilePhone,
            this.email, payments, this.type);
        }

        public override int GetHashCode()
        {
            return this.firstName.GetHashCode() ^ this.middleName.GetHashCode() ^ this.lastName.GetHashCode() ^
                this.id.GetHashCode() ^ this.address.GetHashCode() ^ this.mobilePhone.GetHashCode() ^
                this.email.GetHashCode() ^ this.payments.GetHashCode() ^ this.type.GetHashCode();
        }

        public static bool operator ==(Customer firstCustomer, Customer secondCustomer)
        {
            return Customer.Equals(firstCustomer, secondCustomer);
        }

        public static bool operator !=(Customer firstCustomer, Customer secondCustomer)
        {
            return !(Customer.Equals(firstCustomer, secondCustomer));
        }

        public int CompareTo(Customer otherCustomer)
        {
            if (this.firstName != otherCustomer.firstName)
            {
                return this.FirstName.CompareTo(otherCustomer.FirstName);
            }

            if (this.id != otherCustomer.id)
            {
                return this.Id.CompareTo(otherCustomer.id);
            }

            return 0;
        }

        public object Clone()
        {
            List<Payment> paymentsClone = new List<Payment>();
            foreach (var payment in this.payments)
            {
                Payment paymentClone = (Payment)payment.Clone();
                paymentsClone.Add(paymentClone);
            }

            Customer customerClone = new Customer(this.firstName, this.middleName, this.lastName, this.id, this.address,
                this.mobilePhone, this.email, paymentsClone,this.type);

            return customerClone as Customer;
        }
    }
}
