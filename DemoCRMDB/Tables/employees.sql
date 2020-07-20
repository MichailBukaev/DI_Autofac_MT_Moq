CREATE TABLE [dcr].[Employees]
(
	[Id] int not null primary key foreign key references dcr.Users (Id),
	Dept_Id int not null foreign key references dcr.Departaments(Id),
	Position_Id int not null foreign key references dcr.Positions (Id),
	Supervisor_Id int foreign key references dcr.Employees (Id)
)
