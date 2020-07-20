CREATE VIEW [dcr].[EmpoyeesView]
AS
select 
u.Id,
u.EMail,
u.Registration_date,
i.FirstName,
i.LastName,
i.Date_of_Birth,
u.City,
e.Dept_Id,
d.Name_of_dept,
e.Supervisor_Id,
concat(se.FirstName, ' ', se.LastName) as Supervisor
from dcr.Users u 
inner join dcr.Employees e on u.Id = e.Id
left join dcr.Individuals i on u.Id = i.Id
left join dcr.Departaments d  on e.Dept_Id = d.Id
left join dcr.Individuals se on e.Supervisor_Id = se.Id
