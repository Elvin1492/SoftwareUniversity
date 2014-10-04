namespace BankOfKurtovoKonare.Customers
{
    public class Individual : Customer, ICustomer
    {
        public Individual(string name, int id)
            :base(name, id)
        {
        }
    }
}
