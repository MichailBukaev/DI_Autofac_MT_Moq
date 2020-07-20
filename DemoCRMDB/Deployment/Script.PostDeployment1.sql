/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
insert dcr.Departaments values
('bank')
insert dcr.Positions values
('operation'),
('Head operation')

declare @Id int
declare @Id_Dept int
declare @Id_Pos int
declare @Id_supervisor int

exec dcr.InsertIndividualCustomer @Id out, 'test1@test.test', '123', 'moscow', 'test1', 'test1', 'M', '01-01-2000', '123456', null

exec dcr.InsertIndividualCustomer @Id out, 'test2@test.test', '123', 'moscow', 'test2', 'test2', 'M', '01-01-2000', '123457', null
select @Id_Dept = Id from dcr.Departaments where Name_of_dept = 'bank'
select @Id_Pos = Id from dcr.Positions where [Name] = 'Head operation'
insert dcr.Employees (Id, Dept_Id, Position_Id) values
(@Id, @Id_Dept, @Id_Pos)

exec dcr.InsertIndividualCustomer @Id out, 'test3@test.test', '123', 'moscow', 'test3', 'test3', 'M', '01-01-2000', '123458', null

exec dcr.InsertIndividualCustomer @Id out, 'test4@test.test', '123', 'moscow', 'test4', 'test4', 'M', '01-01-2000', '123459', null
insert dcr.BusinesseCustomers (Id, Identity_Code, [Name]) values
(@Id, '987654321', 'test4 OOO')

select @Id_Pos = Id from dcr.Positions where [Name] = 'operation'
select @Id_supervisor = Id from dcr.Users where EMail = 'test2@test.test'
exec dcr.InsertEmployee @Id out, 'test5@test.test', '123', 'moscow', 'test5', 'test5', 'M', '01-01-2000', @Id_Dept, @Id_Pos, @Id_supervisor, null

exec dcr.InsertBusinesseCustomer @Id out, 'test6@test.test', '123', 'spb', 'test6 OOO', '123456789', null



