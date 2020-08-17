CREATE PROCEDURE [dcr].[InsertBusinesseCustomer]
	@Id INT out,
	@EMail nvarchar(100),
	@Password nvarchar(100),
	@City nvarchar(50),
	@Name nvarchar(50),
	@Identity_Code nvarchar(50),
	@Registration_date datetime
AS
begin

begin transaction;

set @Id = next value for dcr.UsersId
begin try

insert dcr.Users (Id, EMail, [Password], City) values
(@Id, @EMail, @Password, @City)

insert dcr.BusinesseCustomers (Id, [Name], Identity_Code) values
(@Id, @Name, @Identity_Code)

commit transaction;

end try
begin catch
	rollback transaction;
	throw;
end catch

end
