CREATE TABLE [dcr].[Individuals]
(
	[Id] int not null primary key foreign key references dcr.Users (Id) unique,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Gender char(1) check (Gender in ('M', 'F')),
	Date_of_Birth date not null
)
