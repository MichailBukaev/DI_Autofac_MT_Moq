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
print N'Begin Post-deployment.'

declare @curver nvarchar(64)
select @curver = cast([Id] as nvarchar(64)) from dbo.DbVersion

declare @dbVer nvarchar(8)
select @dbVer = DbVersion from dbo.DbVersion


if @curver is null
begin
  set @curver = ''
  print N'Current version is: ' + @curver
  print N'--Inserting initial data: ' + @curver
  :r .\InsertData.sql
  if upper(N'$(DbType)') = 'MOCK'
  begin
    print 'Inserting mock-data:'
  end
end
if @curver like N'1.0.%'
begin
  if @dbVer < N'20200724'
  begin
  :r .\Upgrade_postdeploy_20200724.sql
  end
end
set @dbVer = N'20200724'

if @curver < N'$(DbVer)'
begin
  :r .\Upgrade_postdeploy_x.x.xxxx.xxxx.sql
end

exec dbo.SetDbVersion N'$(DbVer)', N'$(DbType)', @dbVer;

print N'End Post-deployment.'
