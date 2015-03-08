namespace SoftUniSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EmployeeSearch
    {
        public static IList<Employee> FindEmployeesByProject()
        {
            var db = new SoftUniEntities();
            var employees = new List<Employee>();

            var projectsEmployees = db.Projects.Where(p => (p.StartDate).Year == 2002).Select(p => p.Employees);

            foreach (var prEm in projectsEmployees)
            {
                foreach (var emp in prEm)
                {
                    employees.Add(emp);
                }
            }

            return employees.Distinct().ToList();
        }

        public static IList<Employee> FindEmployeesByProjctsUsingNativeSQL()
        {
            var db = new SoftUniEntities();

            string nativeSqlQuery = @"SELECT DISTINCT e.[EmployeeID]
                                  ,e.[FirstName]
                                  ,e.[MiddleName]
                                  ,e.[LastName]                                  
                                  ,e.[JobTitle]
                                  ,e.[DepartmentID]               
                                  ,e.[Salary]
                                  ,e.[ManagerID]
                                  ,e.[HireDate]
                                  ,e.[AddressID]
                              FROM [SoftUni].[dbo].[Employees] e
                              JOIN Departments d ON e.DepartmentID = d.DepartmentID
                              JOIN Employees m ON e.ManagerID = m.EmployeeID
                              JOIN Addresses a ON e.AddressID = a.AddressID
                              JOIN Towns t ON a.TownID = t.TownID
                              JOIN EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID
                              JOIN Projects p ON p.ProjectID = ep.ProjectID

                              WHERE YEAR(p.StartDate) = 2002";

            var employees = db.Database.SqlQuery<Employee>(nativeSqlQuery);

            return employees.ToList();
        }


        public static IList<Employee> FindEmployeesByDepartmentAndManager(string department, string manager)
        {
            var db = new SoftUniEntities();

            var employeeManager = db.Employees.FirstOrDefault(m => m.FirstName + " " + m.LastName == manager);
            var employeeManagerID = employeeManager.EmployeeID;

            var employees = db.Employees.Where(e => e.Department.Name == department && e.ManagerID == employeeManagerID);

            return employees.Distinct().ToList();
        }
    }
}
