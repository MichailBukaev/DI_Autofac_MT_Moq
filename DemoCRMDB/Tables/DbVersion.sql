CREATE TABLE [dbo].[DbVersion]
(
  Id varchar(64) not null constraint DF_DbVersion_Id default(''),
  Created datetime not null constraint DF_DbVersion_Created default getutcdate(), 
  [Type]  nvarchar(32) not null constraint DF_DbVersion_Type default('production'),
  DbVersion nvarchar(8) null
)
