CREATE PROCEDURE [dcr].[GetIndividualCustomerById]
	@Id int
AS
select 
u.Id,
u.Registration_date,
u.EMail,
u.City,
i.FirstName,
i.LastName,
i.Gender,
i.Date_of_Birth,
ic.Identity_Code
from
dcr.Users u
inner join dcr.Individuals i on u.Id = i.Id
right join dcr.IndividCustomers ic on u.Id = ic.Id
