USE [ISW]
GO
/****** Object:  Table [dbo].[tbl_ISW_Data]    Script Date: 12/29/2017 4:17:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ISW_Data](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](500) NULL,
	[CategoryName] [nvarchar](150) NULL,
	[ScheduledDate] [datetime] NULL,
	[ActivityName] [nvarchar](100) NULL,
	[MigrationWindow] [int] NULL,
	[MigrationGroup] [int] NULL,
	[TotalUnits] [int] NULL,
	[MigrationDate] [datetime] NULL,
	[SubStatus] [nvarchar](50) NULL,
	[Review] [nvarchar](50) NULL,
	[Status] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NULL,
	[UpdatedDate] [nvarchar](50) NULL CONSTRAINT [updateDateColumn]  DEFAULT (getdate()),
	[completed] [int] NULL,
	[inprogress] [int] NULL,
	[failed] [int] NULL,
 CONSTRAINT [PK_tbl_ISW_Data] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
