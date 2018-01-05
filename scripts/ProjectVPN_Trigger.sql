IF OBJECT_ID(N'dbo.ProjectVPNupdatetrigger',N'TR') IS NOT NULL
BEGIN
DROP TRIGGER dbo.ProjectVPNupdatetrigger
END

GO
create trigger dbo.ProjectVPNupdatetrigger on dbo.[ProjectVPN] instead of update
as 
begin
set nocount on;
insert into dbo.ProjectVPN_History(
	[projectname] ,
	[customername],
	[projectdetail],
	[projectowner] ,
	[currentsummary],
	[nextsteps] ,
	[status] ,
	[updatedby],
	[updatedDate],
	ParentId) select[projectname] ,
	[customername],
	[projectdetail],
	[projectowner] ,
	[currentsummary],
	[nextsteps] ,
	[status] ,
	[updatedby],
	[updatedDate],
	ID from inserted
end
go

IF OBJECT_ID(N'dbo.ProjectVPNinserttrigger',N'TR') IS NOT NULL
BEGIN
DROP TRIGGER dbo.ProjectVPNinserttrigger
END
go

create trigger dbo.ProjectVPNinserttrigger  on dbo.ProjectVPN after insert
as
begin
set nocount on;

insert into dbo.ProjectVPN_History(
	[projectname] ,
	[customername],
	[projectdetail],
	[projectowner] ,
	[currentsummary],
	[nextsteps] ,
	[status] ,
	[updatedby],
	[updatedDate],
	ParentId) select[projectname] ,
	[customername],
	[projectdetail],
	[projectowner] ,
	[currentsummary],
	[nextsteps] ,
	[status] ,
	[updatedby],
	[updatedDate],
	ID from inserted
end
go


IF OBJECT_ID(N'dbo.ProjectVPNdeletetrigger',N'TR') IS NOT NULL
BEGIN
DROP TRIGGER dbo.ProjectVPNdeletetrigger
END
go

create trigger dbo.ProjectVPNdeletetrigger  on dbo.ProjectVPN after delete
as
begin
set nocount on;

insert into dbo.ProjectVPN_History(
	[projectname] ,
	[customername],
	[projectdetail],
	[projectowner] ,
	[currentsummary],
	[nextsteps] ,
	[status] ,
	[updatedby],
	[updatedDate],
	ParentId) select[projectname] ,
	[customername],
	[projectdetail],
	[projectowner] ,
	[currentsummary],
	[nextsteps] ,
	[status] ,
	[updatedby],
	[updatedDate],
	ID from deleted
end
go


