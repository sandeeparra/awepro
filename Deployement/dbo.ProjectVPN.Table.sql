USE [ISW]
GO
/****** Object:  Table [dbo].[ProjectVPN]    Script Date: 12/29/2017 4:17:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectVPN](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[projectname] [nvarchar](100) NULL,
	[customername] [nvarchar](100) NULL,
	[projectdetail] [nvarchar](1000) NULL,
	[projectowner] [nvarchar](100) NULL,
	[currentsummary] [nvarchar](1000) NULL,
	[nextsteps] [nvarchar](100) NULL,
	[status] [nvarchar](50) NULL,
 CONSTRAINT [PK_ProjectVPN] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
