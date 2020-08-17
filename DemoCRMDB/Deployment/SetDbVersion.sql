create procedure dbo.SetDbVersion
  @version varchar(64),
  @mode varchar(32),
  @dbVersion nvarchar(8)
as
  delete from dbo.DbVersion;
  insert into dbo.DbVersion(Id, [Type], DbVersion)
  select @version, @mode, @dbVersion;
return 0
