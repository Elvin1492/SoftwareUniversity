
namespace CompanyHierarchy.Hierarchy
{
    using System;

    //defina an abstract class RegularEmployee  which derives from empoyee and implements IRegularEmployee 
    public abstract class RegularEmployee : Employee, IRegularEmployee
    {
        public RegularEmployee(string firstname, string lastname, int id, decimal salary, Department department)
            : base(firstname, lastname, id, salary, department)
        {
        }

        // override the ToString() method
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
