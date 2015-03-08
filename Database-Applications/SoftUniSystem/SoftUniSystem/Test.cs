namespace SoftUniSystem
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class Test
    {
        public static void Main()
        {
            var db = new SoftUniEntities();

            //EmployeeCRUD.AddNewEmployee("Zdravko", "Zheliazkov", "Heavy weight lifter", "Production",
            //    new DateTime(2012, 6, 12), 666, null, "Svetlin Nakov", "Sofia", "Kokaliane 13");

            //var addedEmployee = db.Employees.FirstOrDefault(e => e.FirstName == "Zdravko");
            //var addedEmployeeID = addedEmployee.EmployeeID;
            //Console.WriteLine(addedEmployee);

            //EmployeeCRUD.ModifyEmployee(addedEmployeeID, "Zdravka", "Zheliazkova", null, "Tool Design",
            //    new DateTime(2013, 3, 3), 500, null, "Guy Gilbert", "Seattle", "Suicice Steet 13");

            //Console.WriteLine("Edited employee info:");
            //var editedEmployee = db.Employees.FirstOrDefault(e => e.FirstName == "Zdravka");
            //var editedEmployeeID = editedEmployee.EmployeeID;
            //Console.WriteLine(editedEmployee);

            //EmployeeCRUD.DeleteEmployee(editedEmployeeID);

            //var employeesWithProjectsFom2002 = EmployeeSearch.FindEmployeesByProject();
            //Console.WriteLine("Employees with projects starting in 2002:\n----------------------------------\n");

            //foreach (var emp in employeesWithProjectsFom2002)
            //{
            //    Console.WriteLine(emp);
            //}

            //var employeesWithProjectsFom2002Count = employeesWithProjectsFom2002.Count();
            //Console.WriteLine("Total count:" + employeesWithProjectsFom2002Count);


            //var employeesWithProjectsFom2002UsingNativeSql = EmployeeSearch.FindEmployeesByProjctsUsingNativeSQL();
            //Console.WriteLine("Employees with projects starting in 2002 using native SQL: " +
            //    "\n--------------------------------------------\n");

            //foreach (var emp in employeesWithProjectsFom2002UsingNativeSql)
            //{
            //    Console.WriteLine(emp.FirstName + " " + emp.LastName);
            //}

            //var employeesWithProjectsFom2002UsingNativeSqlCount = employeesWithProjectsFom2002UsingNativeSql.Count();
            //Console.WriteLine("Total count:" + employeesWithProjectsFom2002UsingNativeSqlCount);


            //var employeesByDepartmentAndManager = EmployeeSearch.FindEmployeesByDepartmentAndManager("Sales", "Stephen Jiang");
            //Console.WriteLine("Employees by department and manager:\n-----------------------------------------\n");

            //foreach (var emp  in employeesByDepartmentAndManager)
            //{
            //    Console.WriteLine(emp);
            //}

            //var employeesByDepartmentAndManagerCount = employeesByDepartmentAndManager.Count();
            //Console.WriteLine("Total count: " + employeesByDepartmentAndManagerCount);

            //var newEmployeeIvan = new Employee
            //{
            //    FirstName = "Ivan",
            //    LastName = "Ivanov",
            //    JobTitle = "Bachkator",
            //    DepartmentID = 13,
            //    HireDate = new DateTime(2014, 1, 10),
            //    Salary = 10000,
            //    MiddleName = null,
            //    ManagerID = 108,
            //    AddressID = 166
            //};

            //var newEmployeeIvanka = new Employee
            //{
            //    FirstName = "Ivanka",
            //    LastName = "Ivanova",
            //    JobTitle = "Gold Digger",
            //    DepartmentID = 12,
            //    HireDate = new DateTime(2014, 1, 10),
            //    Salary = 5000,
            //    MiddleName = null,
            //    ManagerID = 140,
            //    AddressID = 166
            //};

            //var newEmployees = new List<Employee>();
            //newEmployees.Add(newEmployeeIvan);
            //newEmployees.Add(newEmployeeIvanka);

            //ProjectCRUD.CreateProject("Project Ivanovi", "How to make your husband desperately praying for divorce",
            //    new DateTime(1985, 1, 1), new DateTime(2015, 12, 12), newEmployees);

            //var project = db.Projects.FirstOrDefault(p => p.Name == "Project Ivanovi");
            //Console.WriteLine(project);

            //var employees = db.usp_SelectProjectsByEmployees("ivan", "ivanov");
            //Console.WriteLine(employees.Count());

            var employeess = db.usp_GetProjectsByEmployeeName("ivan", "ivanonv");

    


        }
    }
}
