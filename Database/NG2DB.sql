USE [dbbtCARSAp1]
GO
/****** Object:  Table [dbo].[NG2_Cars]    Script Date: 3/3/2017 7:12:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NG2_Cars](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[brand] [varchar](50) NOT NULL,
	[model] [varchar](50) NOT NULL,
	[fuelType] [varchar](50) NULL,
	[bodyStyle] [varchar](50) NULL,
	[topSpeed] [int] NULL,
	[power] [int] NULL,
 CONSTRAINT [PK_NG2_Cars] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[NG2_Cars] ON 

INSERT [dbo].[NG2_Cars] ([id], [brand], [model], [fuelType], [bodyStyle], [topSpeed], [power]) VALUES (4, N'Toyota', N'Vios', N'Diesel', N'car', 100, 150)
INSERT [dbo].[NG2_Cars] ([id], [brand], [model], [fuelType], [bodyStyle], [topSpeed], [power]) VALUES (5, N'Ford', N'Hunter', N'Gas', N'SUV', 120, 160)
SET IDENTITY_INSERT [dbo].[NG2_Cars] OFF
