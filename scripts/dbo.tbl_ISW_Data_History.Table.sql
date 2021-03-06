USE [ISW]
GO
/****** Object:  Table [dbo].[tbl_ISW_Data_History]    Script Date: 12/29/2017 4:17:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'dbo.tbl_ISW_Data_History', N'U') IS NOT NULL
BEGIN 
	DROP TABLE [DBO].[tbl_ISW_Data_History]
END
GO

CREATE TABLE [dbo].[tbl_ISW_Data_History](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](500) NULL,
	[CategoryName] [nvarchar](500) NULL,
	[MigrationType] [nvarchar](500) NULL,
	[MigrationWindow] [int] NULL,
	[MigrationGroup] [int] NULL,
	[ExpectedKickOff] [datetime] NULL, 
	[MigratorName] [nvarchar](150) NULL,
	[PeerReviewer] [nvarchar](150) NULL,
	[DMName] [nvarchar](150) NULL,
	[LastKickOffEmailSent] [datetime] NULL, 
	[KickOffStatus] int NULL, 
	[ScheduleCount] int NULL,
	[SuccessCount] int NULL,
	[InProgressCount] int NULL,
	[FailedCount] int NULL,
	[CurrentPowerBICount] int NULL,
	[PreviousPowerBICount] int NULL,
	EventStatus int NULL,
	UpdateStatus int NULL,
	LastUpdateEmailSent datetime NULL,
	CurrentSummary nvarchar(500) NULL,
	CommentsForDelayKickOff nvarchar(500) NULL,
	NextUpdateTime datetime NULL,
	[ScheduledDate] [datetime] NULL,
	[ActivityName] [nvarchar](100) NULL,
	[updatedby] nvarchar(100) null,
	[updateddate] datetime null,
	[MigrationApplied] bit null,
	[KBUsed] nvarchar(100) null,
	[Effort] int null,
	PowerBIUpdated bit null,
	ParentId int NULL,
	AssignBy nvarchar(100) null,
	AssignDate datetime null,
	transferredDate date null,
	migrationCompleted nvarchar(50) null,
	ResourceName nvarchar(100) null,
	ResourceDeliveryGroupName nvarchar(100) null,
	taskId int null,
	unitId nvarchar(100) null,
	processlinename nvarchar(100) null
 CONSTRAINT [PK_tbl_ISW_Data_History] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
