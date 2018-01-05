USE [ISW]
GO

/****** Object:  Table [dbo].[tbl_ISW_Data]    Script Date: 1/2/2018 6:24:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'dbo.tbl_ISW_Data', N'U') IS NOT NULL
BEGIN 
	DROP TABLE [DBO].[tbl_ISW_Data]
END
GO

CREATE TABLE [dbo].[tbl_ISW_Data](
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
	[ScheduledDate] [datetime] NULL,
	[ActivityName] [nvarchar](100) NULL,	
	[username] nvarchar(100) null,
	[MigrationApplied] bit null,
	[KBUsed] nvarchar(100) null,
	[Effort] int null,
	PowerBIUpdated bit null
 CONSTRAINT [PK_tbl_ISW_Data] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


