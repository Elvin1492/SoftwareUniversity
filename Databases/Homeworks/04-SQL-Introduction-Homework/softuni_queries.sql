-----------------------------------------------------------------------------------------------------

-- Problem - 04: All information about all Departments

SELECT  d.DepartmentID, d.Name AS [Department Name], m.FirstName + m.LastName AS [Department Manager]
FROM Departments d
INNER JOIN Employees m
ON d.DepartmentID = m.DepartmentID

-----------------------------------------------------------------------------------------------------

-- Problem - 05: All Departments names

SELECT Name AS [Department Name] 
FROM Departments

-----------------------------------------------------------------------------------------------------

-- Problem - 06: The salary of each Employee

SELECT FirstName + ' ' + LastName AS [Employee name], Salary AS [Employee Salary] 
FROM Employees

-----------------------------------------------------------------------------------------------------
-- Problem - 07: The full name of each Employee

SELECT FirstName + ' ' + LastName AS [Employee Full Name]
FROM Employees

-----------------------------------------------------------------------------------------------------

-- Problem - 08: The email address of each Employee

SELECT EmployeeID, FirstName + '.' + LastName + '@softuni.bg' AS [Email Address]
FROM Employees

-----------------------------------------------------------------------------------------------------

-- Problem - 09: All different Employee's salaries

SELECT DISTINCT Salary AS [Unique Salaries] 
FROM Employees

-----------------------------------------------------------------------------------------------------

-- Problem - 10: All information about all employees whose job title is "Sale Representative"

SELECT * FROM Employees e
 WHERE e.JobTitle = 'Sales Representative'

-----------------------------------------------------------------------------------------------------

-- Problem - 11: Names of all employees whose name starts with 'SA'

SELECT FirstName + ' ' + COALESCE(MiddleName , '') +  ' ' + LastName AS [Names starting with 'SA']
FROM Employees 
 WHERE FirstName LIKE 'SA%'

-----------------------------------------------------------------------------------------------------

-- Problem - 12: Names of all employees whose last name contains 'ei'

SELECT FirstName + ' ' + COALESCE(MiddleName , '') +  ' ' + LastName AS [Names containing 'ei']
FROM Employees 
 WHERE LastName LIKE '%ei%'

-----------------------------------------------------------------------------------------------------

-- Problem - 13: All employees whose salary is between 20000 and 30000

SELECT FirstName + ' ' + COALESCE(MiddleName , '') +  ' ' + LastName AS [Full Name], Salary 
FROM Employees 
 WHERE Salary BETWEEN 20000 AND 30000 

-----------------------------------------------------------------------------------------------------

-- Problem - 14: All employees whose salary is 25000, 14000, 12500 or 23600

SELECT FirstName + ' ' + COALESCE(MiddleName , '') +  ' ' + LastName AS [Full Name], Salary 
FROM Employees 
 WHERE Salary IN(25000, 14000, 12500,23600)

-----------------------------------------------------------------------------------------------------

-- Problem - 15: All employees with no manager

SELECT FirstName + ' ' + COALESCE(MiddleName , '') +  ' ' + LastName AS [Full Name], Salary 
FROM Employees 
 WHERE Salary IN(25000, 14000, 12500,23600)

-----------------------------------------------------------------------------------------------------

-- Problem - 16: All employees with salary above 50000

SELECT FirstName + ' ' + COALESCE(MiddleName , '') +  ' ' + LastName AS [Employes with salary above 50000], Salary
FROM Employees 
 WHERE Salary >= 50000
 ORDER BY Salary DESC

-----------------------------------------------------------------------------------------------------

-- Problem - 17:TOP 5 Best paid employees

 SELECT TOP 5 FirstName + ' ' + COALESCE(MiddleName , '') +  ' ' + LastName AS [TOP 5 Best Paid Employees], Salary
FROM Employees 
 ORDER BY Salary DESC

-----------------------------------------------------------------------------------------------------

-- Problem - 18: All employees along with their addresses (using joins)

SELECT e.FirstName + ' ' + COALESCE(e.MiddleName , '') +  ' ' + e.LastName AS [Full Name],
COALESCE(a.AddressText , 'NA' ) AS [Address],
COALESCE(t.Name, 'NA' ) AS [Town]
FROM Employees e
LEFT OUTER JOIN Addresses a
 ON a.AddressID = e.AddressID
LEFT OUTER JOIN Towns t
 ON  a.TownID = t.TownID

-----------------------------------------------------------------------------------------------------

-- Problem - 19: All employees along with their addresses (using equijoins)

SELECT e.FirstName + ' ' + COALESCE(e.MiddleName , '') +  ' ' + e.LastName AS [Full Name],
COALESCE(a.AddressText , 'NA' ) AS [Address],
COALESCE(t.Name, 'NA' ) AS [Town]
FROM Employees e, Addresses a, Towns t
WHERE e.AddressID = a.AddressID AND a.TownID = t.TownID

-----------------------------------------------------------------------------------------------------

-- Problem - 20: All employees along with their manager

SELECT e.EmployeeID, e.FirstName + ' ' + COALESCE(e.MiddleName , '') +  ' ' + e.LastName AS [Full Name],
COALESCE(m.FirstName + ' ' + COALESCE(m.MiddleName , '') +  ' ' + m.LastName, 'NA' ) AS [Manager Name]
FROM Employees e
LEFT OUTER JOIN Employees m
 ON m.EmployeeID = e.ManagerID

-----------------------------------------------------------------------------------------------------

-- Problem - 21: All employees along with their manager and address

SELECT e.EmployeeID, e.FirstName + ' ' + COALESCE(e.MiddleName , '') +  ' ' + e.LastName AS [Full Name],
a.AddressText AS [Address],
COALESCE(m.FirstName + ' ' + COALESCE(m.MiddleName , '') +  ' ' + m.LastName, 'NA' ) AS [Manager Name]
FROM Employees e
LEFT OUTER JOIN Addresses a
 ON e.AddressID = a.AddressID
LEFT OUTER JOIN Employees m
 ON m.EmployeeID = e.ManagerID

-----------------------------------------------------------------------------------------------------

-- Problem - 22: All Departments and all town names as single list

SELECT Name
FROM Departments
UNION
SELECT Name
FROM Towns

-----------------------------------------------------------------------------------------------------

-- Problem - 23: All employees along with their manager and those who don't have one

SELECT e.EmployeeID, e.FirstName + ' ' + COALESCE(e.MiddleName , '') +  ' ' + e.LastName AS [Full Name],
a.AddressText AS [Address],
COALESCE(m.FirstName + ' ' + COALESCE(m.MiddleName , '') +  ' ' + m.LastName, 'NA' ) AS [Manager Name]
FROM Employees e
LEFT OUTER JOIN Addresses a
 ON e.AddressID = a.AddressID
LEFT OUTER JOIN Employees m
 ON m.EmployeeID = e.ManagerID

-----------------------------------------------------------------------------------------------------

-- Problem - 24: All employees from departments 'Sales' and 'Finances' whose hire date is between 1995 and 2005	

SELECT e.FirstName + ' ' + COALESCE(e.MiddleName , '') +  ' ' + e.LastName AS [Full Name],
d.Name AS [Department], e.HireDate
FROM Employees e
INNER JOIN Departments d
 ON e.DepartmentID = d.DepartmentID 
 WHERE (d.Name = 'Sales' OR d.Name = 'Finance')
 AND (e.HireDate BETWEEN '1995-1-1' AND '2004-12-31')

-----------------------------------------------------------------------------------------------------














