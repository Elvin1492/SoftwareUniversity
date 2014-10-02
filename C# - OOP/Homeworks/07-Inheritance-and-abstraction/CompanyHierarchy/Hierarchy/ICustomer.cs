
namespace CompanyHierarchy.Hierarchy
{
    public interface ICustomer : IPerson
    {
         decimal NetPurchaseAmount { get; set; }
    }
}
