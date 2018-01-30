USE [ISW]
GO
/****** Object:  Table [dbo].[ProjectVPN]    Script Date: 12/29/2017 4:17:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'dbo.[ProjectVPN_History]',N'U') IS NOT NULL
BEGIN
DROP TABLE DBO.ProjectVPN_History
END
GO
CREATE TABLE [dbo].ProjectVPN_History(
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[projectname] [nvarchar](100) NULL,
	[customername] [nvarchar](100) NULL,
	[projectdetail] [nvarchar](1000) NULL,
	[projectowner] [nvarchar](100) NULL,
	[currentsummary] [nvarchar](1000) NULL,
	[nextsteps] [nvarchar](100) NULL,
	[status] int NULL,
	[updatedby] nvarchar(100) null,
	[updatedDate] datetime null,
	ParentId int null
 CONSTRAINT [PK_ProjectVPN_history] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
