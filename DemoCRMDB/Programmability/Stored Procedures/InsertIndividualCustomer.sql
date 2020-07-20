CREATE PROCEDURE [dcr].[InsertIndividualCustomer]
	@Id INT out,
	@EMail nvarchar(100),
	@Password nvarchar(100),
	@City nvarchar(50),
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Gender char(1),
	@Date_of_Birth date,
	@Identity_Code  nvarchar (50),
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

insert dcr.IndividCustomers (Id, Identity_Code) values
(@Id, @Identity_Code)

commit transaction;

end try
begin catch
    rollback transaction;
    throw;
end catch

end