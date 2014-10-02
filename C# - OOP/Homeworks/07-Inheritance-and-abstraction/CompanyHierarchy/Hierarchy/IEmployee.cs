
namespace CompanyHierarchy.Hierarchy
{
    public interface IEmployee : IPerson
    {
        Department Department { get; set; }
        decimal Salary { get;  set; }
    }
}
