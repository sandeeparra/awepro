IF OBJECT_ID(N'dbo.customerupdatetrigger',N'TR') IS NOT NULL
BEGIN
DROP TRIGGER dbo.customerupdatetrigger
END

GO
create trigger dbo.customerupdatetrigger on dbo.Customer instead of update
as 
begin
set nocount on;
insert into dbo.Customer_History(
	[Name],
	[MigrationType],
	[AssignedDate] ,
	[UnassignedDate],
	[HVC] ,
	[Exception] ,
	[ExceptionDetail],
	[state],
	[updatedby] ,
	[updatedDate] ,
	ParentId ) select [Name],
	[MigrationType],
	[AssignedDate] ,
	[UnassignedDate],
	[HVC] ,
	[Exception] ,
	[ExceptionDetail],
	[state],
	[updatedby] ,
	[updatedDate] ,
	ID from inserted
end
go

IF OBJECT_ID(N'dbo.customerinserttrigger',N'TR') IS NOT NULL
BEGIN
DROP TRIGGER dbo.customerinserttrigger
END
go

create trigger dbo.customerinserttrigger  on dbo.Customer after insert
as
begin
set nocount on;
insert into dbo.Customer_History(
	[Name],
	[MigrationType],
	[AssignedDate] ,
	[UnassignedDate],
	[HVC] ,
	[Exception] ,
	[ExceptionDetail],
	[state],
	[updatedby] ,
	[updatedDate] ,
	ParentId ) select [Name],
	[MigrationType],
	[AssignedDate] ,
	[UnassignedDate],
	[HVC] ,
	[Exception] ,
	[ExceptionDetail],
	[state],
	[updatedby] ,
	[updatedDate] ,
	ID from inserted
end
go


IF OBJECT_ID(N'dbo.customerdeletetrigger',N'TR') IS NOT NULL
BEGIN
DROP TRIGGER dbo.customerdeletetrigger
END
go

create trigger dbo.customerdeletetrigger  on dbo.Customer after delete
as
begin
set nocount on;
insert into dbo.Customer_History(
	[Name],
	[MigrationType],
	[AssignedDate] ,
	[UnassignedDate],
	[HVC] ,
	[Exception] ,
	[ExceptionDetail],
	[state],
	[updatedby] ,
	[updatedDate] ,
	ParentId ) select [Name],
	[MigrationType],
	[AssignedDate] ,
	[UnassignedDate],
	[HVC] ,
	[Exception] ,
	[ExceptionDetail],
	[state],
	[updatedby] ,
	[updatedDate] ,
	ID from deleted
end
go


