CREATE TABLE [dcr].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[EMail] nvarchar(100) not null unique,
	[Password] nvarchar(100) not null,
	Registration_date datetime default getutcdate(),
	City nvarchar(50) default 'unknown'
)
go
create index IX_Users_Email on dcr.Users (EMail)
go
