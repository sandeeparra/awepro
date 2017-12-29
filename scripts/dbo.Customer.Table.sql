USE [ISW]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 12/29/2017 4:17:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MigrationType] [nvarchar](100) NULL,
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
