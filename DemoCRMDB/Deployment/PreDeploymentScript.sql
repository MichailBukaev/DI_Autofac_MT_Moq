print N'Begin DemoCRMDB pre deployment process.'

if exists(select 1 from master.dbo.sysdatabases where name = N'$(DatabaseName)'
  and exists(select 1 from sys.objects where Name = 'DbVersion' and type = 'U'))
begin
  declare @curver varchar(64)
  select @curver = cast(Id as varchar(64)) from dbo.DbVersion

  declare @dbVer nvarchar(8)
  declare @param nvarchar(500)
  if exists (select 1 from sys.columns where Name = N'DbVersion' and Object_ID = Object_ID(N'dbo.DbVersion'))
  begin
    set @param = N'@dbVerOut nvarchar(8) OUTPUT';
    exec sp_executesql N'select @dbVerOut = DbVersion from dbo.DbVersion', @param, @dbVerOut = @dbVer output;
  end

  if @curver is null
    set @curver = ''

  if @curver = 'x.x.xxxx.xxxx' --recreate DB
    set @curver = ''  

  -- update to current version 
  if @curver < N'$(DbVer)'
  begin
  :r .\Upgrade_predeploy_x.x.xxxx.xxxx.sql
  end
end