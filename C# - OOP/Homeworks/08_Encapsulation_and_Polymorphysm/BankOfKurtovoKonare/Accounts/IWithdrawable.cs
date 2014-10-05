using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfKurtovoKonare.Accounts
{

    // define an interface for accounts that can be witdhrawn from 
    public interface IWithdrawable : IAccount
    {
        void WithdrawMoney(decimal withdrawSum);
    }
}
