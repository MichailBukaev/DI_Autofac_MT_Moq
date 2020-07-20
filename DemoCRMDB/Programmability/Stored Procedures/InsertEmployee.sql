CREATE PROCEDURE [dcr].[InsertEmployee]
	@Id INT out,
	@EMail nvarchar(100),
	@Password nvarchar(100),
	@City nvarchar(50),
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Gender char(1),
	@Date_of_Birth date,
	@Dept_Id int,
	@Position_Id int,
	@Supervisor_Id int,
	@Registration_date datetime
AS
begin

begin transaction;

set @Id = next value for dcr.UsersId
begin try

insert dcr.Users (Id, EMail, [Password], City) values
(@Id, @EMail, @Password, @City)

insert  dcr.Individuals (Id, FirstName, LastName, Gender, Date_of_Birth) values
(@Id, @FirstName, @LastName, @Gender, @Date_of_Birth)

insert dcr.Employees(Id, Dept_Id, Position_Id, Supervisor_Id) values
(@Id, @Dept_Id, @Position_Id, @Supervisor_Id)

commit transaction;

end try
begin catch
	rollback transaction;
	throw;
end catch

end
