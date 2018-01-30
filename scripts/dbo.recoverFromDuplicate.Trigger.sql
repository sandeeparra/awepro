


Alter trigger dbo.recoverFromDuplicate on dbo.tbl_ISW_Data_duplicate instead of update
as 
begin
set nocount on;
insert into dbo.tbl_ISW_Data(
	[CustomerName],
	[CategoryName],
	[MigrationType],
	[MigrationWindow],
	[MigrationGroup],
	[ExpectedKickOff], 
	[MigratorName],
	[PeerReviewer],
	[DMName],
	[LastKickOffEmailSent], 
	[KickOffStatus], 
	[ScheduleCount],
	[SuccessCount],
	[InProgressCount],
	[FailedCount],
	[CurrentPowerBICount],
	[PreviousPowerBICount],
	EventStatus,
	UpdateStatus,
	LastUpdateEmailSent,
	CurrentSummary,
	CommentsForDelayKickOff,
	NextUpdateTime,
	[ScheduledDate],
	[ActivityName],
	[updatedby],
	[updateddate],
	[MigrationApplied],
	[KBUsed],
	[Effort],
	PowerBIUpdated
	,[AssignBy]
      ,[AssignDate]
      ,[transferredDate]
      ,[migrationCompleted]
      ,[ResourceName]
      ,[ResourceDeliveryGroupName]
      ,[taskId]
      ,[unitId]
      ,[processlinename]) select [CustomerName],
	CategoryName,
	[MigrationType],
	[MigrationWindow],
	[MigrationGroup],
	[ExpectedKickOff], 
	[MigratorName],
	[PeerReviewer],
	[DMName],
	[LastKickOffEmailSent], 
	[KickOffStatus], 
	[ScheduleCount],
	[SuccessCount],
	[InProgressCount],
	[FailedCount],
	[CurrentPowerBICount],
	[PreviousPowerBICount],
	EventStatus,
	UpdateStatus,
	LastUpdateEmailSent,
	CurrentSummary,
	CommentsForDelayKickOff,
	NextUpdateTime,
	[ScheduledDate],
	[ActivityName],
	[updatedby],
	[updateddate],
	[MigrationApplied],
	[KBUsed],
	[Effort],
	PowerBIUpdated,[AssignBy]
      ,[AssignDate]
      ,[transferredDate]
      ,[migrationCompleted]
      ,[ResourceName]
      ,[ResourceDeliveryGroupName]
      ,[taskId]
      ,[unitId]
      ,[processlinename] from inserted
	declare @exception int;
	set @exception = 0;
	select @exception = exception from inserted 
	if (@exception = 1)--1.Customer doesnt exists 2.duplicate Customer
	BEGIN
	insert into Customer(name,exception) select CustomerName,'automated. record found in an event. confirm?'  from inserted 
	END
	
	delete from tbl_ISW_Data_duplicate where id = (select id from inserted)
end
go
