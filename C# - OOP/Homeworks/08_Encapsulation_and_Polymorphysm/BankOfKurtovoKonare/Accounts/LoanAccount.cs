using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfKurtovoKonare.Accounts
{
    using BankOfKurtovoKonare.Customers;

    public class LoanAccount : Account, IAccount
    {
         public LoanAccount(ICustomer customer, decimal balance, double interest)
            : base(customer, balance, interest)
        {
        }

         public override void CaluclateInterest(int period)
         {
             if (this.Customer.GetType().Name == "Individual")
             {
                 if (period > 3)
                 {
                      base.CaluclateInterest(period - 3);
                      Console.WriteLine("No interest is accrued for the first 3 months on Individuals Loan Accounts");                      
                 }
                 else if(period <= 3 && period > 0)
                 {
                     Console.WriteLine("No interest is accrued for the first 3 months on Individuals Loan Accounts");
                 }
                 else if(period < 0)
                 {
                     base.CaluclateInterest(period);
                 }                 
             }
             else if (this.Customer.GetType().Name == "Company")
             {
                 if (period > 2)
                 {
                     base.CaluclateInterest(period - 2);
                     Console.WriteLine("No interest is accrued for the first 2 months on Companies Loan Accounts");                     
                 }
                 else if (period <= 2 && period > 0)
                 {
                     Console.WriteLine("No interest is accrued for the first 2 months on Companies Loan Accounts");
                 }
                 else if(period < 0)
                 {
                     base.CaluclateInterest(period);
                 }
             }
         }
    }
}
