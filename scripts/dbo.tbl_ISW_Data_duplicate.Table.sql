USE [ISW]
GO
/****** Object:  Table [dbo].[tbl_ISW_Data_duplicate]    Script Date: 12/29/2017 4:17:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'dbo.tbl_ISW_Data_duplicate', N'U') IS NOT NULL
BEGIN 
	DROP TABLE [DBO].[tbl_ISW_Data_duplicate]
END
GO

CREATE TABLE [dbo].[tbl_ISW_Data_duplicate](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](500) NULL,
	[CategoryName] [nvarchar](500) NULL,
	[MigrationType] [nvarchar](500) NULL,
	[MigrationWindow] [int] NULL,
	[MigrationGroup] [int] NULL,
	[MigrationDate] [datetime] NULL	,
	[ExpectedKickOff] [datetime] NULL, 
	[MigratorName] [nvarchar](150) NULL,
	[PeerReviewer] [nvarchar](150) NULL,
	[DMName] [nvarchar](150) NULL,
	[LastKickOffEmailSent] [datetime] NULL, 
	[KickOffStatus] [nvarchar](100) NULL, 
	[ScheduleCount] int NULL,
	[SuccessCount] int NULL,
	[InProgressCount] int NULL,
	[FailedCount] int NULL,
	[CurrentPowerBICount] int NULL,
	[PreviousPowerBICount] int NULL,
	EventStatus nvarchar(100) NULL,
	UpdateStatus nvarchar(100) NULL,
	LastUpdateEmailSent datetime NULL,
	CurrentSummary nvarchar(500) NULL,
	CommentsForDelayKickOff nvarchar(500) NULL,
	NextUpdateTime datetime NULL,
	Exception nvarchar(50) NULL,
	[ScheduledDate] [datetime] NULL,
	[ActivityName] [nvarchar](100) NULL,
	[TotalUnits] [int] NULL,
	[username] nvarchar(100) null,
	[parent_id] [int] NULL,
 CONSTRAINT [PK_tbl_ISW_Data_duplicate] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


