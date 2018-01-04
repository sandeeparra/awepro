USE [ISW]
GO

/****** Object:  Table [dbo].[Customer]    Script Date: 12/29/2017 2:58:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'dbo.Customer',N'U') IS NOT NULL
BEGIN
DROP TABLE DBO.Customer
END

GO

CREATE TABLE [dbo].[Customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] nvarchar(100) NULL,
	[MigrationType] int NULL,
	[AssignedDate] [datetime] NULL,
	[UnassignedDate] [datetime] NULL,
	[HVC] [bit] NULL,
	[Exception] [bit] NULL,
	[ExceptionDetail] [nvarchar](100) NULL,
	[state] [nvarchar](100) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


