CREATE TABLE [dcr].[IndividCustomers]
(
	[Id] int not null primary key foreign key references dcr.Users (Id) unique,
	Identity_Code  nvarchar (50) unique,
)
