------------------- Problem 1.Create a table in SQL Server ------------

USE PerformanceTestDB
GO

--Fill table with 10 000 000  entries
DECLARE @n int = 10000000

BEGIN TRAN
WHILE (@n > 0)
BEGIN
INSERT INTO TestTable
	VALUES (GETDATE(), CONVERT(NVARCHAR(50), @n))
SET @n = @n - 1
END
COMMIT TRAN

--Clean Cache and Buffers
DBCC FREEPROCCACHE
DBCC DROPCLEANBUFFERS
GO

--Perform a serach
SELECT
	Date,
	Text
FROM TestTable
WHERE Date >= CONVERT(DATETIME, '2015-02-22 19:22:11.500')
AND Date <= CONVERT(DATETIME, '2015-02-22 19:24:11.500')

------------------- Problem 2.	Add an index to speed-up the search by date  ------------

-- Create a nonclustered index called IX_TestTable_Date
-- on the TestTable table using the Date column. 
CREATE INDEX IX_TestTable_Date
    ON TestTable(Date); 
GO

--Clean Cache and Buffers
DBCC FREEPROCCACHE
DBCC DROPCLEANBUFFERS
GO

--Perform a serach
SELECT
	Date,
	Text
FROM TestTable
WHERE Date >= CONVERT(DATETIME, '2015-02-22 19:22:11.500')
AND Date <= CONVERT(DATETIME, '2015-02-22 19:24:11.500')

