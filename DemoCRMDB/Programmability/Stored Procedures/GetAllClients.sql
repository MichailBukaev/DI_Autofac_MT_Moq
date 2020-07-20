CREATE PROCEDURE [dcr].[GetAllClients]
AS
select 
i.Id, 
concat(i.FirstName, ' ', i.LastName) as Client_name, 
c.Identity_Code
from dcr.IndividCustomers c
left join Individuals i on c.Id = i.Id
union
select 
b.Id, 
b.[Name], 
b.Identity_Code 
from dcr.BusinesseCustomers b