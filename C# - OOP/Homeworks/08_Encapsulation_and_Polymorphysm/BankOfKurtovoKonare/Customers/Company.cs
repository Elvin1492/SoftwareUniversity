namespace BankOfKurtovoKonare.Customers
{
    public class Company : Customer, ICustomer
    {
        public Company(string name, int id)
            : base(name, id)
        {
        }
    }
}
