using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfKurtovoKonare.Accounts
{
    using BankOfKurtovoKonare.Customers;

    public class MortgageAccount: Account, IAccount
    {
        public MortgageAccount(ICustomer customer, decimal balance, double interest)
            : base(customer, balance, interest)
        {
        }

        public override void CaluclateInterest(int period)
        {
            decimal result = 0;
            if (this.Customer.GetType().Name == "Individual")
            {
                if (period > 6)
                {
                    base.CaluclateInterest(period - 6);
                    Console.WriteLine("No interest is accrued for the first 6 months on Individuals Mortgage Accounts");
                }
                else if (period <= 6 && period > 0)
                {
                    Console.WriteLine("No interest is accrued for the first 6 months on Individuals Mortgage accounts");
                }
                else if(period < 0)
                {
                    base.CaluclateInterest(period);
                }
            }
            else if (this.Customer.GetType().Name == "Company")
            {
                if (period <= 12)
                {
                    result = this.Balance * (decimal)(1 + (this.Interest / 2) / 100 * period) - this.Balance;
                    PrintCalculatedInterest(period, result);
                    Console.WriteLine("Interest for the first 12 months on Companys Mortgage Accounts is half reduced.");                   
                }
                else if (period > 12)
                {
                    result = this.Balance * (decimal)(1 + (this.Interest / 2) / 100 * 12 +
                        this.Interest / 100 * (period - 12)) - this.Balance;
                    PrintCalculatedInterest(period, result);
                    Console.WriteLine("Interest for the first 12 months on Companies Mortgage Accounts is half reduced.");                    
                }
                else if(period < 0)
                {
                    base.CaluclateInterest(period);
                }
            }
        }
    }
}
