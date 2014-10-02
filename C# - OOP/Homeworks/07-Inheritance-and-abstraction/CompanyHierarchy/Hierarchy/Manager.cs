
namespace CompanyHierarchy.Hierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    // define a class Manager which derives from Employee and implements IManager
    public class Manager : Employee, IManager
    {
        private List<Employee> employeeList;

        public Manager(string firstname, string lastname, int id, decimal salary, Department departmen,
            List<Employee> employeeList)
            : base(firstname, lastname, id, salary, departmen)
        {
            this.EmployeeList = employeeList;
        }

        public List<Employee> EmployeeList
        {
            get { return new List<Employee>(this.employeeList); }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Employee List", "Employee List can not be empty." );
                }

                this.employeeList = new List<Employee>(value);
            }
        }

        // override the ToString() method
        public override string ToString()
        {
            StringBuilder employees = new StringBuilder();
            employees.AppendLine(" Employeses under command:");

            foreach (var employee in this.employeeList)
            {
                employees.AppendLine(employee.ToString());
            }

            return base.ToString() + employees.ToString();
        }
    }
    
}
