---------- Problem 3. Create the same table in MySQL --------------------- 

CREATE TABLE partitioned_table (
date_column datetime NOT NULL,
text_column varchar(100) NOT NULL,
CONSTRAINT PK_partitioned_table_date_column PRIMARY KEY (date_column) 
);


ALTER TABLE partitioned_table PARTITION BY RANGE COLUMNS (date_column) (
  PARTITION 1990_p VALUES LESS THAN ('1990-01-01'),
  PARTITION 2000_p VALUES LESS THAN ('2000-01-01'),
  PARTITION 2010_p VALUES LESS THAN ('2010-01-02'),
  );


DELIMITER $$
CREATE PROCEDURE insertEnries()
BEGIN
	SET @start = 1;
	SET @date = STR_TO_DATE('19900202 1030','%Y%m%d %h%i');

	START TRANSACTION;
		WHILE @start < 1000000 DO
		INSERT INTO partitioned_table   
        VALUES(@date , CAST(@start AS  char(100)));
		SET @start= @start + 1;
		SET @date = DATE_ADD(@date, INTERVAL 10 MINUTE);
		END WHILE;
	COMMIT;
END

DELIMITER $$
CALL insertEnries();

---- search for dates bewtween 1992 -1997 in partition 1 -----------
DELIMITER $$
SELECT * FROM partitioned_table
WHERE date_column BETWEEN STR_TO_DATE('19920202 1130','%Y%m%d %h%i') AND 
 STR_TO_DATE('19970202 1130','%Y%m%d %h%i');

---- search for dates bewtween 1998 -2003 in partition 1 and 2-----------
DELIMITER $$
SELECT * FROM partitioned_table
WHERE date_column BETWEEN STR_TO_DATE('19980202 1130','%Y%m%d %h%i') AND 
 STR_TO_DATE('20030202 1130','%Y%m%d %h%i');




