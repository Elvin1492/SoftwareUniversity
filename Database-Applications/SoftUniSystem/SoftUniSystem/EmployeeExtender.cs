namespace SoftUniSystem
{
    using System;
    using System.Linq;

    public partial class Employee
    {
        public override string ToString()
        {
            var db = new SoftUniEntities();

            string managerName = "N/A";
            if (this.ManagerID != null)
            {
                var manager = db.Employees.FirstOrDefault(e => e.EmployeeID == this.ManagerID);
                managerName = manager.FirstName + " " + manager.LastName;
            };

            string townName = "";
            if (this.Address.TownID != null)
            {
                townName = this.Address.Town.Name;
            }

            return string.Format(" Name: {0} {1} {2}\n --------------------------\n" + 
                " JobTite: {3}\n Department: {4}\n Salary: {5:0.00}\n Manager: {6}\n Hire Date: {7}\n Addess: {8}\n",
                this.FirstName,
                this.MiddleName != null ? this.MiddleName : "",
                this.LastName, 
                this.JobTitle, 
                this.Department.Name,
                this.Salary,
                managerName,
                this.HireDate,
                this.AddressID != null ? this.Address.AddressText + " " + townName  : "N/A");
        }
    }
}
