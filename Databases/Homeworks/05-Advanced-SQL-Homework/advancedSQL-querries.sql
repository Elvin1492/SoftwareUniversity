------------------------------------------------------------------------------------------------------------------------------

-- Problem - 01: Names and salaries of the employees that take the minimal salary in the company(with nested SELECT statement)

SELECT
	FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName AS [Employee Name],
	Salary
FROM Employees
WHERE Salary = (SELECT
	MIN(Salary)
FROM Employees)

------------------------------------------------------------------------------------------------------------------------------

-- Problem - 02: Names and salaries of the employees whose salary is up to 10% higher thane the minimal company slary

SELECT
	FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName AS [Employee Name],
	Salary
FROM Employees
WHERE Salary <= (SELECT
	MIN(Salary)
FROM Employees)
* 1.10

------------------------------------------------------------------------------------------------------------------------------

-- Problem - 03: Names, salaries and department of the employees who take the minimal slary in their department

SELECT
	e.FirstName + ' ' + ISNULL(e.MiddleName, '') + ' ' + e.LastName AS [Full Name],
	e.Salary,
	d.Name AS [Department Name]
FROM Employees e
INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE e.Salary = (SELECT
	MIN(Salary)
FROM Employees
WHERE DepartmentID = d.DepartmentID)

------------------------------------------------------------------------------------------------------------------------------

-- Problem - 04: The average salary in department #1

SELECT
	d.DepartmentID AS [Department ID],
	d.Name AS [Department Name],
	AVG(e.Salary) AS [Average Salary]
FROM Employees e
INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE d.DepartmentID = 1
GROUP BY	d.DepartmentID,
			d.Name

------------------------------------------------------------------------------------------------------------------------------

-- Problem - 05: The average salary in department Sales

SELECT
	AVG(e.Salary) AS [Average Salary for Sales Department]
FROM Employees e
INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

------------------------------------------------------------------------------------------------------------------------------

-- Problem - 06: The number of employees in the Sales department 

SELECT
	COUNT(e.EmployeeID) AS [Number of Employees in Sales Department]
FROM Employees e
INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

------------------------------------------------------------------------------------------------------------------------------

-- Problem - 07: The number of employees who have manager

SELECT
	COUNT(EmployeeID) AS [Number of employees that have manager]
FROM Employees
WHERE ManagerID IS NOT NULL

------------------------------------------------------------------------------------------------------------------------------

-- Problem - 08: The number of employees who have no  manager

SELECT
	COUNT(EmployeeID) AS [Number of employees that have manager]
FROM Employees
WHERE ManagerID IS NULL

------------------------------------------------------------------------------------------------------------------------------

-- Problem - 09: The average salary for each department

SELECT
	d.Name AS [Department Name],
	AVG(e.Salary) AS [Average Salary]
FROM Employees e
INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name

------------------------------------------------------------------------------------------------------------------------------

-- Problem - 10: The count of all employees in each department and for each town

SELECT
	t.Name AS [Town],
	ISNULL(d.Name, 'NA') AS [Department Name],
	COUNT(e.EmployeeID) AS [Number of Employees]
FROM Employees e
INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
RIGHT OUTER JOIN Addresses a
	ON e.AddressID = a.AddressID
RIGHT OUTER JOIN Towns t
	ON a.TownID = t.TownID
GROUP BY	t.Name,
			d.Name

------------------------------------------------------------------------------------------------------------------------------

-- Problem - 11: All managers that have exactly 5 employees

SELECT
    m.FirstName + ' ' +  m.LastName AS [Manager Name],
	COUNT(m.EmployeeID) AS [Employees Count]
FROM Employees m
INNER JOIN Employees e
	ON m.EmployeeID = e.ManagerID
GROUP BY m.FirstName, m.LastName
HAVING COUNT(m.EmployeeID) = 5

------------------------------------------------------------------------------------------------------------------------------

-- Problem - 12: All employees with their managers

SELECT
	e.FirstName + ' ' + e.LastName AS [Employee],
	ISNULL(m.FirstName + ' ' + m.LastName, 'No Manager') AS [Manager]
FROM Employees e
LEFT OUTER JOIN Employees m
	ON e.ManagerID = m.EmployeeID

------------------------------------------------------------------------------------------------------------------------------

-- Problem - 13: All employees with their managers whose last names have exactly 5 characters

SELECT
	e.FirstName + ' ' + e.LastName AS [Employee],
	ISNULL(m.FirstName + ' ' + m.LastName, 'No Manager') AS [Manager]
FROM Employees e
LEFT OUTER JOIN Employees m
	ON e.ManagerID = m.EmployeeID
WHERE LEN(e.LastName) = 5

------------------------------------------------------------------------------------------------------------------------------

-- Problem - 14: Display the current date time in format "day.month.year hour:minutes:seconds:milliseconds"

SELECT
	CONVERT(NVARCHAR(20), GETDATE(), 104) + ' ' + CONVERT(NVARCHAR(20), GETDATE(), 114) AS [Current datetime]

------------------------------------------------------------------------------------------------------------------------------

-- Problem - 15: Create table Users

CREATE TABLE Users(
UserID int IDENTITY,
Username nvarchar(100) NOT NULL UNIQUE,
UserPassword nvarchar(128) NOT NULL,
FullName nvarchar(100) NOT NULL,
LastLogin DATETIME,
CONSTRAINT PK_Users PRIMARY KEY(UserID),
CONSTRAINT CK_Users_UserPassword CHECK (LEN(UserPassword) > 5 )
)

GO

------------------------------------------------------------------------------------------------------------------------------

-- Problem - 16: Create view to display users that have been in the system today

CREATE VIEW  VisitorsToday AS
SELECT
	Username AS [User],
	FullName AS [Full Name],
	LastLogin AS [Login time]
FROM Users
WHERE LastLogin > DATEADD(DAY, -1, GETDATE())     
--- WHERE DAY(LastLogin) = DAY(GETDATE()) ----
GO

SELECT
	*
FROM VisitorsToday

------------------------------------------------------------------------------------------------------------------------------

-- Problem - 17: Create table Groups

CREATE TABLE Groups(
GroupID int IDENTITY,
Name nvarchar(20) NOT NULL,
CONSTRAINT PK_Gropus PRIMARY KEY(GroupID),
CONSTRAINT UK_Groups_Name UNIQUE(Name)
)

GO

------------------------------------------------------------------------------------------------------------------------------

-- Problem - 18: Add column GRoupID to Users, add foreign key for GroupID

ALTER TABLE Users ADD GroupID int
 
ALTER TABLE Users
ADD CONSTRAINT FK_Users_Groups FOREIGN KEY(GroupID) REFERENCES Groups(GroupID)

------------------------------------------------------------------------------------------------------------------------------

-- Problem - 19: Insert several records in the Groups and User tables

INSERT INTO Groups (Name)
	VALUES ('admins'),
	('regular'),
	('bullshit');

GO

INSERT INTO Users (Username, UserPassword, FullName, LastLogin, GroupID)
	VALUES ('testUser', '123456', 'Test User full name', GETDATE(), NULL),
	('pesho', '12345678', 'Pesho Peshev', NULL, 1),
	('gosho', 'parola123', 'Gosho Goshev', CONVERT(DATETIME, '20150213', 112), 1),
	('penka', 'tainaparola', 'Penka Chorbadjieva', CONVERT(DATETIME, '20150213', 112), NULL),
	('Tonka', 'topcheto', 'Tonka topchieva', CONVERT(DATETIME, '20051231', 112), 2);

GO

------------------------------------------------------------------------------------------------------------------------------

-- Problem - 20: Update some of the records in the Groups and User tables

UPDATE Users
SET	Username = 'ChangedUsername',
	FullName = 'Changed ful name'
WHERE Username = 'testUser'

UPDATE Groups
SET Name = 'user'
WHERE Name = 'regular'

------------------------------------------------------------------------------------------------------------------------------

-- Problem - 21: Delete some of the records in the Groups and User tables

DELETE FROM Users
WHERE Username = 'penka'

DELETE FROM Groups
WHERE Name = 'bullshit'

------------------------------------------------------------------------------------------------------------------------------

-- Problem - 22: Insert in the users table the names of all employees from the Employee tables

INSERT INTO Users (Username, UserPassword, FullName, LastLogin, GroupID)
	SELECT
		LEFT(FirstName, 1) + ISNULL(UPPER(MiddleName), '_') + LOWER(LastName),
		LEFT(FirstName, 1) + LOWER(LastName) + 'pass',
		FirstName + ' ' + LastName,
		NULL,
		NULL
	FROM Employees

------------------------------------------------------------------------------------------------------------------------------

-- Problem - 23: Change the password to NULL for all users who have not been in the system since 10.03.2010

ALTER TABLE Users 
ALTER COLUMN UserPassword nvarchar(100) NULL

UPDATE Users
SET UserPassword = NULL
WHERE LastLogin < CONVERT(DATETIME, '20100310', 112)

------------------------------------------------------------------------------------------------------------------------------

-- Problem - 24: Delete all users without password

ALTER TABLE Users 
ALTER COLUMN UserPassword nvarchar(100) NULL

UPDATE Users
SET UserPassword = NULL
WHERE LastLogin < CONVERT(DATETIME, '20100310', 112)

------------------------------------------------------------------------------------------------------------------------------
-- Problem - 25: The average employee salary foe each Department by JobTitle

SELECT
	d.Name AS [Department Name],
	e.JobTitle,
	AVG(e.Salary) AS [Average Salary]
FROM Employees e
INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY	d.Name,
			e.JobTitle

------------------------------------------------------------------------------------------------------------------------------

-- Problem - 26: Minimum employee salary by department and job title along with some of the employee with that salary 

SELECT
	d.Name AS [Department],
	e.JobTitle,
	e.FirstName + ' ' + e.LastName AS [Name],
	MIN(e.Salary) AS [Min Salary]
FROM Employees e
INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY	d.Name,
			e.JobTitle,
			e.FirstName,
			e.LastName

------------------------------------------------------------------------------------------------------------------------------

-- Problem - 27: The town where maximum number of workers live

SELECT TOP 1
	t.Name AS Town,
	COUNT(e.EmployeeID) AS [Number of employees]
FROM Employees e
LEFT OUTER JOIN Addresses a
	ON e.AddressID = a.AddressID
LEFT OUTER JOIN Towns t
	ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY [Number of employees] DESC

------------------------------------------------------------------------------------------------------------------------------

-- Problem - 28: The number of managers in each town

SELECT
	t.Name AS Town,
	COUNT(DISTINCT e.ManagerID) AS [Number of Managers]
FROM Employees e
JOIN Employees m
	ON e.ManagerID = m.EmployeeID
JOIN Addresses a
	ON m.AddressID = a.AddressID
JOIN Towns T
	ON a.TownID = t.TownID
GROUP BY t.Name

------------------------------------------------------------------------------------------------------------------------------

-- Problem - 29: Create table WorkHours to store reports for each employee

CREATE TABLE WorkHours(
WorkHoursID int IDENTITY NOT NULL,
WorkHoursDate date NULL,
Task nvarchar(100) NOT NULL,
WorkHoursCount int NOT NULL,
Comments nvarchar(MAX) NULL, 
EmployeeID int NOT NULL,
CONSTRAINT PK_WorkHours PRIMARY KEY(WorkHoursID),
CONSTRAINT FK_WorkHours_Emplyees FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID) 
)

------------------------------------------------------------------------------------------------------------------------------

-- Problem - 30: INSERT, UPDATE and DELETE some data in the WorkHours table

INSERT INTO WorkHours (WorkHoursDate, Task, WorkHoursCount, Comments, EmployeeID)
	VALUES (NULL, 'new task', 8, 'no comment', 9),
	(CONVERT(DATETIME, '20150213', 112), 'bullshit task', 0, NULL, 9),
	(CONVERT(DATETIME, '20150210', 112), 'Iimportant task', 10, 'important comment', 3),
	(CONVERT(DATETIME, '20150213', 112), 'bullshit task', 7, NULL, 33),
	(NULL, 'task to be deleted', 666, NULL, 9)

UPDATE WorkHours
SET Comments = 'Updated comment'
WHERE Comments IS NULL

DELETE WorkHours
WHERE Task='task to be deleted'

------------------------------------------------------------------------------------------------------------------------------

-- Problem - 31: Define table WorkHoursLogs to track all changes in the table WorkHours

CREATE TABLE WorkHoursLog(
WorkHoursLogID INT NOT NULL IDENTITY PRIMARY KEY,
WorkHoursID INT NOT NULL,
OldEmployeeID INT NULL,
NewEmployeeID INT NULL,
OldWorkHoursDate date NULL,
NewWorkHoursDate date NULL,
OldTask nvarchar(100) NULL,
NewTask nvarchar(100) NULL,
OldWorkHoursCount int NULL,
NewWorkHoursCount int NULL,
OldComment nvarchar(max) NULL,
NewComment nvarchar(max) NULL,
Command nvarchar(10)
)

GO

CREATE TRIGGER tr_WorkHoursUpdate ON WorkHours FOR UPDATE
AS
BEGIN
INSERT INTO WorkHoursLog (WorkHoursID, OldEmployeeID, NewEmployeeID, OldWorkHoursDate, NewWorkHoursDate, OldTask, NewTask, OldWorkHoursCount, NewWorkHoursCount,
OldComment, NewComment, Command)
	SELECT
		d.WorkHoursID,
		d.EmployeeID,
		i.EmployeeID,
		d.WorkHoursDate,
		i.WorkHoursDate,
		d.Task,
		i.Task,
		d.WorkHoursID,
		i.WorkHoursCount,
		d.Comments,
		i.Comments,
		'UPDATE'
	FROM	DELETED d,
			INSERTED i
END
GO

UPDATE WorkHours
SET	WorkHoursDate = GETDATE(),
	WorkHoursCount = 100,
	Comments = 'updated comments to chekc trigger',
	EmployeeID= 13
WHERE WorkHoursID = 3
GO

CREATE TRIGGER tr_WorkHoursDelete ON WorkHours FOR DELETE
AS
BEGIN
INSERT INTO WorkHoursLog (WorkHoursID,OldEmployeeID, NewEmployeeID, OldWorkHoursDate, NewWorkHoursDate, OldTask, NewTask, OldWorkHoursCount, NewWorkHoursCount,
OldComment, NewComment, Command)
	SELECT
		d.WorkHoursID,
		d.EmployeeID,
		NULL,
		d.WorkHoursDate,
		NULL,
		d.Task,
		NULL,
		d.WorkHoursCount,
		NULL,
		d.Comments,
		NULL,
		'DELETE'
	FROM DELETED d
END
GO

DELETE FROM WorkHours
WHERE WorkHoursID = 3
GO

CREATE TRIGGER tr_WorkHoursInsert ON WorkHours FOR INSERT
AS
BEGIN
INSERT INTO WorkHoursLog (WorkHoursID, OldEmployeeID, NewEmployeeID, OldWorkHoursDate, NewWorkHoursDate, OldTask, NewTask, OldWorkHoursCount, NewWorkHoursCount,
OldComment, NewComment, Command)
	SELECT
		i.WorkHoursID,
		NULL, 
		i.EmployeeID,
		NULL,
		i.WorkHoursDate,
		NULL,
		i.Task,
		NULL,
		i.WorkHoursCount,
		NULL,
		i.Comments,
		'INSERT'
	FROM INSERTED i
END
GO

INSERT INTO  WorkHours(WorkHoursDate, Task, WorkHoursCount,Comments,EmployeeID)
VALUES(CONVERT(DATETIME,'20150101',112), 'triggerd task', 666, 'triggered comment', 7)

------------------------------------------------------------------------------------------------------------------------------
-- Problem - 32: Start a transaction. Delete all employees from department 'Sales' along with all dependent records.Rollback transaction at the end.

ALTER TABLE Employees
DROP CONSTRAINT FK_Employees_Departments

ALTER TABLE Departments
DROP CONSTRAINT FK_Departments_Employees

BEGIN TRAN
DELETE e
	FROM Employees e
	INNER JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ROLLBACK
	
ALTER TABLE Employees
ADD CONSTRAINT FK_Employees_Departments
	FOREIGN KEY(DepartmentID)
	REFERENCES Departments(DepartmentID)

ALTER TABLE Departments 
ADD CONSTRAINT FK_Departments_Employees
	FOREIGN KEY(ManagerID)
	REFERENCES Employees(EmployeeID)

------------------------------------------------------------------------------------------------------------------------------

-- Problem - 33: Start a transaction. Drop table EmployeesProjects and restore

BEGIN TRAN
DROP TABLE EmployeesProjects
ROLLBACK

------------------------------------------------------------------------------------------------------------------------------

-- Problem - 34: Back up data from EmployeesProjects into a temporary table. Drop table EmployeesProjects and the restore data 

CREATE TABLE #EmployeesProjectsTemp (
EmployeeID INT NOT NULL,
ProjectID INT NOT NULL)

INSERT INTO #EmployeesProjectsTemp(EmployeeID, ProjectID)
SELECT EmployeeID, ProjectID FROM EmployeesProjects

DROP TABLE EmployeesProjects

CREATE TABLE EmployeesProjects(
  EmployeeID INT FOREIGN KEY REFERENCES Employees(EmployeeID) NOT NULL,
   ProjectID INT FOREIGN KEY REFERENCES Projects(ProjectID) NOT NULL,
)

INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
SELECT EmployeeID, ProjectID FROM #EmployeesProjectsTemp


------------------------------------------------------------------------------------------------------------------------------










































