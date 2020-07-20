CREATE TABLE [dcr].[Positions]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	[Name] nvarchar(50) unique
)
go
create index IX_Name_of_position on dcr.Positions ([Name])