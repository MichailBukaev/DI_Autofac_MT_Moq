CREATE TABLE [dcr].[BusinesseCustomers]
(
	[Id] int not null primary key foreign key references dcr.Users (Id),
	[Name] nvarchar(50) not null,
	Identity_Code nvarchar (50) not null unique
)
