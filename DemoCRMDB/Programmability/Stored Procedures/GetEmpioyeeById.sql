CREATE PROCEDURE [dcr].[GetEmpioyeeById]
@Id int
AS
select *
from dcr.EmpoyeesView
where Id = @Id

