using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfKurtovoKonare
{
    using BankOfKurtovoKonare.Customers;
    using BankOfKurtovoKonare.Accounts;

    class BankOfKurtovoKonareTest
    {
        static void Main()
        {
            // create some customers 
            ICustomer darikRadio = new Company("Darik Radio", 34567);
            ICustomer citizenKane = new Individual("Charles Kane", 13);
            ICustomer baiStavrii = new Individual("Bai Stavrii", 100);

            // crate a list of accounts and print them on the console
            List<IAccount> accounts = new List<IAccount>
            {
                new LoanAccount(darikRadio, 10056.98m, 9.4),
                new MortgageAccount(citizenKane, 0.01m, 15.54),
                new DepositAccount(baiStavrii, 1000m, 2.6),                
            };

            foreach (var account in accounts)
            {
                Console.WriteLine(account);
            }

            // create a deposit account 
            ICustomer radioEdnorog = new Company("Radio Ednorog", 666);
            IWithdrawable radioEdnorogAccount = new DepositAccount(radioEdnorog, 30450.90m, 4.6);
            Console.WriteLine(radioEdnorogAccount);

            //try to withdraw a sum bigger than the accounts balance
            radioEdnorogAccount.WithdrawMoney(31000); // Insufficient funds.Your balance is 30,450.90 try witdrawing a smaller sum

            // deposit some money and withdraw again
            radioEdnorogAccount.DepositMoney(550);
            radioEdnorogAccount.WithdrawMoney(31000);
            Console.WriteLine(radioEdnorogAccount.Balance); // 0.90

            // try to calculate an interest
            radioEdnorogAccount.CaluclateInterest(8); // Your balance is less than 1000.00. An interest can not be accrued
            Console.WriteLine();

            //check the loan account CalculateInterest method on individuals and companys
            IAccount citizenkaneAccount = new LoanAccount(citizenKane, 19867.01m, 15.54);
            citizenkaneAccount.CaluclateInterest(7);

            Console.WriteLine();

            IAccount darikRadioAccount = new LoanAccount(darikRadio, 10056.98m, 9.4);
            darikRadioAccount.CaluclateInterest(2);

            Console.WriteLine();

            //check the mortgage account CalculateInterest method on individuals and companys
            IAccount baiStavriiAccount = new MortgageAccount(baiStavrii, 1000m, 2.6);
            baiStavriiAccount.CaluclateInterest(7);

            Console.WriteLine();

            ICustomer softUni = new Company("Software Uiversity", 1000);
            IAccount softUniAccount = new MortgageAccount(softUni, 321000m, 2.6);
            softUniAccount.CaluclateInterest(13);
        }
    }
}
