CREATE TABLE [dbo].[Customers]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(250) NOT NULL, 
    [LastName] NVARCHAR(250) NOT NULL, 
    [NIF] NCHAR(9) NOT NULL, 
    [Income] NUMERIC(18, 2) NOT NULL, 
    [CreditRating] INT NOT NULL, 
    [CurrentMonthlyOutgoings] NUMERIC(18, 2) NOT NULL
)
