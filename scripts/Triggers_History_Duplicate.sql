IF OBJECT_ID(N'dbo.recordhistoryupdate',N'TR') IS NOT NULL
BEGIN
DROP TRIGGER dbo.recordhistoryupdate
END

GO
create trigger dbo.recordhistoryupdate on dbo.tbl_ISW_Data after update
as 
begin
set nocount on;
insert into dbo.tbl_ISW_Data_History(
	ParentId,
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
	PowerBIUpdated,[AssignBy]
      ,[AssignDate]
      ,[transferredDate]
      ,[migrationCompleted]
      ,[ResourceName]
      ,[ResourceDeliveryGroupName]
      ,[taskId]
      ,[unitId]
      ,[processlinename]) select id,[CustomerName],
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
end
go

IF OBJECT_ID(N'dbo.recordhistoryinsert',N'TR') IS NOT NULL
BEGIN
DROP TRIGGER dbo.recordhistoryinsert
END
go

create trigger dbo.recordhistoryinsert  on dbo.tbl_ISW_Data after insert
as
begin
set nocount on;
insert into dbo.tbl_ISW_Data_History(ParentId,[CustomerName],
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
	[updateddate],[MigrationApplied],
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
      ,[processlinename]) select id,[CustomerName],
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
end
go


IF OBJECT_ID(N'dbo.recordhistorydelete',N'TR') IS NOT NULL
BEGIN
DROP TRIGGER dbo.recordhistorydelete
END
go

create trigger dbo.recordhistorydelete  on dbo.tbl_ISW_Data after delete
as
begin
set nocount on;
insert into dbo.tbl_ISW_Data_History(ParentId,[CustomerName],
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
	PowerBIUpdated,[AssignBy]
      ,[AssignDate]
      ,[transferredDate]
      ,[migrationCompleted]
      ,[ResourceName]
      ,[ResourceDeliveryGroupName]
      ,[taskId]
      ,[unitId]
      ,[processlinename]) select id,[CustomerName],
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
      ,[processlinename] from deleted
end
go


