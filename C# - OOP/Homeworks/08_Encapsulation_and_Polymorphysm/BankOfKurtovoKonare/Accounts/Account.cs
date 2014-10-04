namespace BankOfKurtovoKonare.Accounts
{
    using System;
    using BankOfKurtovoKonare.Customers;

    public abstract class Account : IAccount
    {
        private ICustomer customer;
        private decimal balance;
        private double interest;

        public Account(ICustomer customer, decimal balance, double interest)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.Interest = interest;
        }

        public ICustomer Customer
        {
            get 
            {
                return this.customer;
            }

            protected set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Customer","Customer can not be null");
                }

                this.customer = value;
            }
        }

        public decimal Balance
        {
            get 
            {
                return this.balance;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Balance", "Balance can not be a negative number");
                }

                this.balance = value;
            }
        }

        public double Interest
        {
            get
            {
                return this.interest;
            }

            protected set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Interest", "Interest can not be a negative number");
                }

                this.interest = value;
            }
        }

        public void DepositMoney(decimal depositSum)
        {
            decimal deposit = depositSum;
            if (deposit < 0)
            {
                throw new ArgumentOutOfRangeException("Deposit", "Deposit can not be a negative number");
            }

            this.balance += deposit;
        }

        public virtual void CaluclateInterest(int period)
        {
            int months = period;
            if (months < 0)
            {
                throw new ArgumentOutOfRangeException("Period", "Period can not be a negative number");
            }
            else
            {
                decimal result = this.Balance * (decimal)(1 + this.Interest / 100 * period) - this.Balance;
                Console.WriteLine(String.Format("Interest sum on account of {0} with interest rate {1:0.00}%\nfor a {2} months period is: {3:N2} BGN ",
                       this.Customer.Name, this.Interest, period, result));
            }
        }

        protected void PrintCalculatedInterest(int period, decimal result)
        {
            Console.WriteLine(String.Format("Interest sum on account of {0} with interest rate {1:0.00}%\nfor a {2} months period is: {3:N2} BGN ",
                       this.Customer.Name, this.Interest, period, result));
        }

        public override string ToString()
        {
            return String.Format("Account: {0}, {1} \nBalance: {2:0.00} BGN, Interest(monthly): {3:0.00}%\n"
                , this.GetType().Name, this.Customer.ToString(), this.balance, this.interest);
        }
    }
}
