namespace SoftUniSystem
{
    using System;
    using System.Linq;

    public class EmployeeCRUD
    {
        public static void AddNewEmployee(
            string firstName,
            string lastName,
            string jobTitle,
            string department,
            DateTime hireDate,
            decimal salary,
            string middleName = null,
            string manager = null,
            string town = null,
            string address = null)
        {
            Console.WriteLine("Adding new employee\n--------------------\n");

            var db = new SoftUniEntities();

            var newEmployeeDepartment = db.Departments.FirstOrDefault(d => d.Name == department);
            int newEmployeeDepartmentID = newEmployeeDepartment.DepartmentID;

            int? employeeTownID = null;
            int? employeeManagerID = null;
            int? addedEmployeeAddressID = null;
   

            if (!string.IsNullOrEmpty(manager))
            {
                var employeeManager = db.Employees.FirstOrDefault(e => e.FirstName + " " + e.LastName == manager);
                employeeManagerID = employeeManager.EmployeeID;
            }

            if (!string.IsNullOrEmpty(address))
            {         
                if (!string.IsNullOrEmpty(town))
                {
                    var employeeTown = db.Towns.FirstOrDefault(t => t.Name == town);
                    employeeTownID = employeeTown.TownID;
                }

                var employeeAddress = new Address
                {
                    AddressText = address,
                    TownID = employeeTownID
                };

                db.Addresses.Add(employeeAddress);
                db.SaveChanges();

                var addedEmployeeAddress = db.Addresses.FirstOrDefault(a => a.AddressText == address);
                addedEmployeeAddressID = addedEmployeeAddress.AddressID;
            }

            var newEmployee = new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                JobTitle = jobTitle,
                DepartmentID = newEmployeeDepartmentID,
                HireDate = hireDate,
                Salary = salary,
                MiddleName = middleName,
                AddressID = addedEmployeeAddressID,
                ManagerID = employeeManagerID,
            };

            db.Employees.Add(newEmployee);
            db.SaveChanges();

            Console.WriteLine("Employee added\n--------------------------\n");
        }

        public static void ModifyEmployee(
            int emmpoyeeID,
            string firstName = null,
            string lastName = null,
            string jobTitle = null,
            string department = null,
            DateTime? hireDate = null,
            decimal? salary = null,
            string middleName = null,
            string manager = null,
            string town = null,
            string address = null)
        {
            Console.WriteLine("Modifying employee Number: " + emmpoyeeID + "\n---------------------------\n" );
            var db = new SoftUniEntities();

            var employee = db.Employees.FirstOrDefault(e => e.EmployeeID == emmpoyeeID);

            if (!string.IsNullOrEmpty(firstName))
            {
                employee.FirstName = firstName;
                Console.WriteLine("First name edited.");
            };

            if (!string.IsNullOrEmpty(lastName))
            {
                employee.LastName = lastName;
                Console.WriteLine("Last name edited");
            };

            if (!string.IsNullOrEmpty(jobTitle))
            {
                employee.JobTitle = jobTitle;
                Console.WriteLine("Job titlle edited.");
            };

            if (!string.IsNullOrEmpty(department))
            {
                var editedEmployeeDepartment = db.Departments.FirstOrDefault(d => d.Name == department);
                int editedEmployeeDepartmentID = editedEmployeeDepartment.DepartmentID;
                employee.DepartmentID = editedEmployeeDepartmentID;
                Console.WriteLine("Departament edited.");
            };

            if (hireDate != null)
            {
                employee.HireDate = (DateTime)hireDate;
                Console.WriteLine("Hire date edited.");
            };

            if (salary != null)
            {
                employee.Salary = (decimal)salary;
                Console.WriteLine("Salary edited.");
            };

            if (!string.IsNullOrEmpty(middleName))
            {
                employee.MiddleName = middleName;
                Console.WriteLine("Middle Name edited.");
            };

            if (!string.IsNullOrEmpty(manager))
            {
                var editedEmployeeManager = db.Employees.FirstOrDefault(e => e.FirstName + " " + e.LastName == manager);
                int editedEmployeeManagerID = editedEmployeeManager.EmployeeID;
                employee.ManagerID = editedEmployeeManagerID;
                Console.WriteLine("Manager edited.");
            };

            if (!string.IsNullOrEmpty(town))
            {
                var newTown = db.Towns.FirstOrDefault(t => t.Name == town);
                int newTownID = newTown.TownID;
                employee.Address.TownID = newTownID;
                Console.WriteLine("Town edited.");
            }

            if (!string.IsNullOrEmpty(address))
            {
                employee.Address.AddressText = address;
                Console.WriteLine("Address edited");
            }

            db.SaveChanges();

            Console.WriteLine("Employee number: " + emmpoyeeID + " modified.\n----------------\n");
        }

        public static void DeleteEmployee(int employeeID)
        {
            Console.WriteLine("Deleting employee Number " + employeeID);

            var db = new SoftUniEntities();

            var employee = db.Employees.FirstOrDefault(e => e.EmployeeID == employeeID);
            db.Employees.Remove(employee);
            db.SaveChanges();

            Console.WriteLine("Emplyee deletted.");
        }
    }
}
