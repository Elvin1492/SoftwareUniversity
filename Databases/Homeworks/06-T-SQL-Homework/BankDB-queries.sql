------------------------------------------------------------------------------------------------------------------------------

-- Problem - 01: Create a database with two tables Persons and Accounts 

CREATE DATABASE BankDB
GO

USE BankDB

CREATE TABLE Persons(
PersonID int IDENTITY(1,1) NOT NULL,
FirstName nvarchar(20) NOT NULL,
LastName nvarchar(50) NOT NULL,
SSN varchar(10) NOT NULL,
CONSTRAINT PK_Persons PRIMARY KEY(PersonID))

GO

INSERT INTO Persons (FirstName, LastName, SSN)
	VALUES ('Pesho', 'Peshev', '8810101224'),
	('Gosho', 'Goshev', '8502021004'),
	('Minka', 'Minkova', '9406052442')
GO

CREATE TABLE Accounts(
AccountID int IDENTITY(1,1) NOT NULL,
Balance money  DEFAULT  0,
PersonID int NULL,
CONSTRAINT PK_Accounts PRIMARY KEY(AccountID),
CONSTRAINT FK_Accounts_Persons FOREIGN KEY(PersonID) REFERENCES Persons(PersonID))

GO

INSERT INTO Accounts (Balance, PersonID)
	VALUES (1000, 1),
	(600, 1),
	(100000, 2)
GO

------------------------------------------------------------------------------------------------------------------------------

-- Problem - 02: Create a stored procedure that takes a number as parameter and returns all persons with balance above that number 

CREATE PROCEDURE usp_PeopleWithAccountBalanceAboveSpecified(@amount money = 0)
AS
SELECT
	p.FirstName,
	p.LastName,
	p.SSN,
	a.Balance
FROM Persons p
JOIN Accounts a
	ON p.PersonID = a.PersonID
WHERE a.Balance >= @amount
GO

EXEC usp_PeopleWithAccountBalanceAboveSpecified 1000
GO

------------------------------------------------------------------------------------------------------------------------------

-- Problem - 03: Create a function  that takes as parameters sum, annual interest rate and number of moths and returns calculated interest  

CREATE FUNCTION ufn_CalculateSimpleInterest(@sum money, @yearlyInterest money, @numberOfMonths int)
RETURNS money
AS
BEGIN
RETURN @sum * ( 1 + @yearlyInterest/100.00 * @numberOfMonths/12.00 )
END
GO

DECLARE @funtionOutput money
SELECT
	@funtionOutput = dbo.ufn_CalculateSimpleInterest(1000.00, 3.55, 6.00)
 PRINT @funtionOutput
GO

------------------------------------------------------------------------------------------------------------------------------

-- Problem - 04: Create a procedure with the above function that gives an interest to a person's account with specified id for one month 

CREATE PROCEDURE usp_CalculateBalanceWithOneMonthInterest(@accountID int, @yearlyInterest money) 
AS
SELECT
	p.FirstName + ' ' + p.LastName AS [Peson Name],
	a.Balance AS [Initial Account Balance],
	dbo.ufn_CalculateSimpleInterest(a.Balance, @yearlyInterest, 1) AS [Balance with one month interest]
FROM Persons p
JOIN Accounts a
	ON p.PersonID = a.PersonID
WHERE p.PersonID = @accountID
GO

EXEC usp_CalculateBalanceWithOneMonthInterest	1,
												3.55
GO

------------------------------------------------------------------------------------------------------------------------------

-- Problem - 05: Add two more procedures DepostiMoney and WithdrawMoney 

CREATE PROCEDURE usp_WithdrawMoney(@accountID int, @amount money)
AS
UPDATE Accounts
SET Balance = Balance - @amount
WHERE AccountID = @accountID
GO

EXEC usp_WithdrawMoney	1,
						100
GO

CREATE PROCEDURE usp_DepositMoney(@accountID int,@amount money)
AS
UPDATE Accounts
SET Balance = Balance + @amount
WHERE AccountID = @accountID
GO

EXEC usp_DepositMoney	2,
						300
GO

------------------------------------------------------------------------------------------------------------------------------

-- Problem - 06: Create table Logs. Add trigger to the Accounts table that logs changes on every balance change 

CREATE TABLE AccountsLogs(
AccountsLogsID int IDENTITY(1,1) NOT NULL,
AccountID int NOT NULL,
OldBalance money NOT NULL,
NewBalance money NOT NULL,
CONSTRAINT PK_AccountsLogs PRIMARY KEY(AccountsLogsID),
CONSTRAINT FK_AccountsLogs_Accounts FOREIGN KEY(AccountID) REFERENCES Accounts(AccountID))

GO


CREATE TRIGGER tr_AccoutsUpdate ON Accounts FOR UPDATE
AS
BEGIN
INSERT INTO AccountsLogs (AccountID, OldBalance, NewBalance)
	SELECT
		d.AccountID,
		d.Balance,
		i.Balance
	FROM	DELETED d,
			INSERTED i
END
GO

EXEC usp_DepositMoney	3,
						33333
GO

EXEC usp_WithdrawMoney	3,
						33333
GO

UPDATE Accounts
SET Balance = 50000
WHERE AccountID = 3
GO

SELECT
	*
FROM AccountsLogs
GO


CREATE TRIGGER tr_AccountInserr ON Accounts FOR INSERT
AS
BEGIN
INSERT INTO AccountsLogs (AccountID, OldBalance, NewBalance)
	SELECT
		i.AccountID,
		0,
		i.Balance
	FROM INSERTED i
END
GO

INSERT INTO Accounts (Balance, PersonID)
	VALUES (100000, 3)
GO

SELECT
	*
FROM AccountsLogs
GO


CREATE TRIGGER tr_AccountsDelete ON Accounts FOR DELETE
AS
BEGIN
INSERT INTO AccountsLogs (AccountID, OldBalance, NewBalance)
	SELECT
		d.AccountID,
		d.Balance,
		0
	FROM DELETED d
END
GO

ALTER TABLE Accounts
DROP CONSTRAINT FK_Accounts_Persons;
GO

ALTER TABLE AccountsLogs
DROP CONSTRAINT FK_AccountsLogs_Accounts;
GO


DELETE FROM Accounts
WHERE AccountID = 4
GO

SELECT
	*
FROM AccountsLogs
GO

ALTER TABLE Accounts 
ADD CONSTRAINT FK_Accounts_Persons FOREIGN KEY(PersonID) REFERENCES Persons(PersonID)
GO


ALTER TABLE AccountsLogs WITH NOCHECK
ADD CONSTRAINT FK_AccountsLogs_Accounts FOREIGN KEY(AccountID) REFERENCES Accounts(AccountID)
GO


