using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfKurtovoKonare.Accounts
{
    using BankOfKurtovoKonare.Customers;

    public class DepositAccount : Account, IAccount, IWithdrawable
    {
        public DepositAccount(ICustomer customer, decimal balance, double interest)
            : base(customer, balance, interest)
        {
        }

        public override void CaluclateInterest(int period)
        {
            if (this.Balance < 1000 && period > 0)
            {
                Console.WriteLine("Your balance is less than 1000.00. An interest can not be accrued");
            }
            else
            {
                base.CaluclateInterest(period);
            }
        }

        public virtual void WithdrawMoney(decimal withdrawSum)
        {
            decimal withdraw = withdrawSum;
            if (withdraw > this.Balance)
            {
                Console.WriteLine(String.Format("Insufficient funds.Your balance is {0:N2} " +
                    "try witdrawing a smaller sum.", this.Balance));
            }
            else
            {
                this.Balance -= withdrawSum;
            }
        }
    }
}
