USE [ISW]
GO
/****** Object:  UserDefinedTableType [dbo].[ISW_parameter]    Script Date: 12/29/2017 4:17:37 PM ******/
CREATE TYPE [dbo].[ISW_parameter] AS TABLE(
	[CustomerName] [nvarchar](500) NULL,
	[CategoryName] [nvarchar](150) NULL,
	[ScheduledDate] [datetime] NULL,
	[ActivityName] [nvarchar](100) NULL,
	[MigrationWindow] [int] NULL,
	[MigrationGroup] [int] NULL,
	[TotalUnits] [int] NULL,
	[MigrationDate] [datetime] NULL,
	[completed] [int] NULL,
	[inprogress] [int] NULL,
	[failed] [int] NULL
)
GO
