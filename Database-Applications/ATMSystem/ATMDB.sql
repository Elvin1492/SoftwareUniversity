-- Create the database [ATMDB] if it does not exist
IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'ATMDB')
  CREATE DATABASE ATMDB
  COLLATE Latin1_General_CI_AI
GO

USE ATMDB
GO

-- Drop all existing ATMDB tables, so that we can create them
IF OBJECT_ID('CardAccounts ') IS NOT NULL
  DROP TABLE CardAccounts 

-- Create tables
  CREATE TABLE CardAccounts(
	Id int IDENTITY(1,1) NOT NULL,
	CardNumber char(10) NOT NULL,
	CardPIN char(4) NOT NULL,
	CardCash money NOT NULL DEFAULT 0,
	CONSTRAINT PK_CardAccounts PRIMARY KEY(Id)
 )
GO

-- Create tables
  CREATE TABLE TransactionHistory (
	Id int IDENTITY(1,1) NOT NULL,
	CardNumber char(10) NOT NULL,
	TransactionDate datetime NOT NULL,
	Amount money NOT NULL,
	CONSTRAINT PK_TransactionHistory PRIMARY KEY(Id)
 )
GO

-- Insert table data
INSERT CardAccounts (CardNumber, CardPIN, CardCash) VALUES
('1234567890', '1234', 3000),
('6454236435', '4534', 1200),
('9375357935', '4579', 1600),
('5754985720', '6924', 0),
('5843759275', '4545', 5495),
('6475265767', '7754', 400),
('2356576585', '5445', 213.67)


