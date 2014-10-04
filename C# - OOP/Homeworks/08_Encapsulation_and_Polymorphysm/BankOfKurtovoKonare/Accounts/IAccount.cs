namespace BankOfKurtovoKonare.Accounts
{
    using BankOfKurtovoKonare.Customers;

    public interface IAccount 
    {
        ICustomer Customer{ get; }
        decimal Balance { get; }
        double Interest { get; }

        void CaluclateInterest(int months);
        void DepositMoney(decimal depositSum);
    }
}
