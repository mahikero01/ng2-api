USE [dbbtCARSAp1]
GO
/****** Object:  StoredProcedure [dbo].[BTSS_SetUserSetGroup_Get]    Script Date: 6/9/2017 2:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BTSS_SetUserSetGroup_Get] 
	@user_id nvarchar(25) = NULL, 
	@user_name nvarchar(25) = NULL,
	@user_last_name nvarchar(50) = NULL,
	@user_first_name nvarchar(50) = NULL,
	@user_middle_name nvarchar(50) = NULL,
	@created_date_user datetime = NULL,
	@grp_id nvarchar(25) = NULL,
	@grp_name nvarchar(50) = NULL,
	@grp_desc nvarchar(255) = NULL,
	@created_date_grp datetime = NULL,
	@mod_id nvarchar(25) = NULL,
	@mod_name nvarchar(50) = NULL,
	@mod_desc nvarchar(255) = NULL,
	@created_date_mod datetime = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT 
		A.[user_id]
		,A.[user_name]
		,A.user_last_name
		,A.user_first_name
		,A.user_middle_name
		,A.created_date AS created_date_user
		,C.grp_id
		,C.grp_name 
		,C.grp_desc
		,C.created_date AS created_date_grp
	FROM 
		set_user AS A INNER JOIN set_user_access AS B
			ON A.[user_id] = B.[user_id]
		INNER JOIN set_group AS C
			ON B.grp_id = C.grp_id
	WHERE 
		A.[user_id] = ISNULL(@user_id, A.[user_id])
		AND A.[user_name] = ISNULL(@user_name, A.[user_name])
		AND A.user_last_name = ISNULL(@user_last_name, A.user_last_name)
		AND A.user_first_name = ISNULL(@user_first_name, A.user_first_name)
		AND A.user_middle_name = ISNULL(@user_middle_name, A.user_middle_name)
		AND A.created_date = ISNULL(@created_date_user, A.created_date)
		AND C.grp_id = ISNULL(@grp_id, C.grp_id)
		AND C.grp_name = ISNULL(@grp_name, C.grp_name)
		AND C.grp_desc = ISNULL(@grp_desc, C.grp_desc)
		AND C.created_date = ISNULL(@created_date_grp, C.created_date);
END

GO
/****** Object:  Table [dbo].[NG2_Cars]    Script Date: 6/9/2017 2:43:26 PM ******/
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
/****** Object:  Table [dbo].[set_group]    Script Date: 6/9/2017 2:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[set_group](
	[grp_id] [nvarchar](25) NOT NULL,
	[grp_name] [nvarchar](50) NULL,
	[grp_desc] [nvarchar](255) NULL,
	[created_date] [datetime] NULL CONSTRAINT [DF_set_group_created_date]  DEFAULT (getdate())
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[set_group_access]    Script Date: 6/9/2017 2:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[set_group_access](
	[grp_id] [nvarchar](25) NULL,
	[mod_id] [nvarchar](25) NULL,
	[can_view] [bit] NULL DEFAULT ((0)),
	[can_add] [bit] NULL DEFAULT ((0)),
	[can_edit] [bit] NULL DEFAULT ((0)),
	[can_delete] [bit] NULL DEFAULT ((0))
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[set_module]    Script Date: 6/9/2017 2:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[set_module](
	[mod_id] [nvarchar](25) NOT NULL,
	[mod_name] [nvarchar](50) NULL,
	[mod_desc] [nvarchar](255) NULL,
	[created_date] [datetime] NULL CONSTRAINT [DF_set_module_created_date]  DEFAULT (getdate())
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[set_user]    Script Date: 6/9/2017 2:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[set_user](
	[user_id] [nvarchar](25) NOT NULL,
	[user_name] [nvarchar](25) NULL,
	[user_last_name] [nvarchar](50) NULL,
	[user_first_name] [nvarchar](50) NULL,
	[user_middle_name] [nvarchar](50) NULL,
	[can_PROD] [bit] NULL DEFAULT ((0)),
	[can_UAT] [bit] NULL DEFAULT ((0)),
	[can_PEER] [bit] NULL DEFAULT ((0)),
	[can_DEV] [bit] NULL DEFAULT ((0)),
	[created_date] [datetime] NULL CONSTRAINT [DF_set_user_created_date]  DEFAULT (getdate())
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[set_user_access]    Script Date: 6/9/2017 2:43:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[set_user_access](
	[user_id] [nvarchar](25) NULL,
	[grp_id] [nvarchar](25) NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[NG2_Cars] ON 

INSERT [dbo].[NG2_Cars] ([id], [brand], [model], [fuelType], [bodyStyle], [topSpeed], [power]) VALUES (4, N'Toyota', N'Vios', N'Diesel', N'car', 100, 150)
INSERT [dbo].[NG2_Cars] ([id], [brand], [model], [fuelType], [bodyStyle], [topSpeed], [power]) VALUES (5, N'Ford', N'Hunter', N'Gas', N'SUV', 120, 160)
SET IDENTITY_INSERT [dbo].[NG2_Cars] OFF
INSERT [dbo].[set_group] ([grp_id], [grp_name], [grp_desc], [created_date]) VALUES (N'GRP-201768-001', N'admin', N'', CAST(N'2017-06-08 13:51:34.900' AS DateTime))
INSERT [dbo].[set_group_access] ([grp_id], [mod_id], [can_view], [can_add], [can_edit], [can_delete]) VALUES (N'GRP-201768-001', N'MOD-201768-001', 1, 0, 0, 0)
INSERT [dbo].[set_module] ([mod_id], [mod_name], [mod_desc], [created_date]) VALUES (N'MOD-201768-001', N'CARSA', N'', CAST(N'2017-06-08 13:50:30.327' AS DateTime))
INSERT [dbo].[set_user] ([user_id], [user_name], [user_last_name], [user_first_name], [user_middle_name], [can_PROD], [can_UAT], [can_PEER], [can_DEV], [created_date]) VALUES (N'USER-201768-001', N'sarmife', N'Sarmiento', N'Federico', N'', 0, 0, 0, 0, CAST(N'2017-06-08 13:51:58.583' AS DateTime))
INSERT [dbo].[set_user_access] ([user_id], [grp_id]) VALUES (N'USER-201768-001', N'GRP-201768-001')
SET ANSI_PADDING ON

GO
/****** Object:  Index [aaaaaset_group_PK]    Script Date: 6/9/2017 2:43:26 PM ******/
ALTER TABLE [dbo].[set_group] ADD  CONSTRAINT [aaaaaset_group_PK] PRIMARY KEY NONCLUSTERED 
(
	[grp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [aaaaaset_module_PK]    Script Date: 6/9/2017 2:43:26 PM ******/
ALTER TABLE [dbo].[set_module] ADD  CONSTRAINT [aaaaaset_module_PK] PRIMARY KEY NONCLUSTERED 
(
	[mod_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [aaaaaset_user_PK]    Script Date: 6/9/2017 2:43:26 PM ******/
ALTER TABLE [dbo].[set_user] ADD  CONSTRAINT [aaaaaset_user_PK] PRIMARY KEY NONCLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
