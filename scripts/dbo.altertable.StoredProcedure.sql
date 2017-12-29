USE [ISW]
GO
/****** Object:  StoredProcedure [dbo].[altertable]    Script Date: 12/29/2017 4:17:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[altertable]
@local ISW_parameter READONLY,@username nvarchar(50)
as
BEGIN
set nocount on;
declare @id int;
declare @selectedId int;
declare @l table([ID] int identity(1,1),[CustomerName] [nvarchar](500) NULL,
	[CategoryName] [nvarchar](150) NULL,
	[ScheduledDate] [datetime] NULL,
	[ActivityName] [nvarchar](100) NULL,
	[MigrationWindow] [int] NULL,
	[MigrationGroup] [int] NULL,
	[TotalUnits] [int] NULL,
	[MigrationDate] [datetime] NULL,
	completed int null,inprogress int null,failed int null)
insert into @l(CustomerName,CategoryName,ScheduledDate,ActivityName,MigrationWindow,MigrationGroup,TotalUnits,MigrationDate,completed,inprogress,failed) 
select CustomerName,CategoryName,ScheduledDate,ActivityName,MigrationWindow,MigrationGroup,TotalUnits,MigrationDate,completed,inprogress,failed from @local;
While Exists (Select * from @l)
begin
select top 1 @id = id from @l
set @selectedId = 0;
select @selectedId = isw.id from 
			dbo.tbl_ISW_Data as isw 
			inner join 
			@l as t 
			on 
			isw.CustomerName = t.CustomerName and 
			isw.CategoryName = t.CategoryName and 
			isw.ActivityName = t.ActivityName and 
			isw.MigrationWindow = t.MigrationWindow	and 
			isw.MigrationGroup = t.MigrationGroup where t.id = @id
IF (@selectedId = 0)
			insert into tbl_ISW_Data(CustomerName,CategoryName,ScheduledDate,ActivityName,MigrationWindow,MigratioNGroup,TotalUnits,MigratioNDate,UserName,completed,inprogress,failed)
			select CustomerName,CategoryName,ScheduledDate,ActivityName,MigrationWindow,MigrationGroup,TotalUnits,MigrationDate,@username,completed,inprogress,failed from @l as t where t.id = @id
ELSE
		insert into tbl_ISW_Data_duplicate(CustomerName,CategoryName,ScheduledDate,ActivityName,MigrationWindow,MigratioNGroup,TotalUnits,MigratioNDate,UserName,completed,inprogress,failed,parent_id)
			select CustomerName,CategoryName,ScheduledDate,ActivityName,MigrationWindow,MigrationGroup,TotalUnits,MigrationDate,@username,completed,inprogress,failed,@selectedId from @l as t where t.id = @id

		   

delete @l where id = @id
end

END


GO
