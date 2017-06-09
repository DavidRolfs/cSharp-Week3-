USE [hair_salon]
GO
/****** Object:  Table [dbo].[clients]    Script Date: 6/9/2017 4:15:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[stylist_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[stylists]    Script Date: 6/9/2017 4:15:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stylists](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[clients] ON 

INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (12, N'Anyone', 16)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (13, N'Jonnniiieeeee', 17)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (15, N'Junbug', 16)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (14, N'JUUUUKRRY', 18)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (11, N'tyrana Iris', 16)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (21, N'Cameron', 17)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (17, N'kat', 14)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (18, N'donald', 14)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (19, N'princes', 14)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (20, N'Yippie', 17)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (22, N'Berta', 18)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (23, N'AL', 18)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (24, N'Bart Simpson', 16)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (25, N'Kamron', 14)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (26, N'Larvatar', 17)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (27, N'Judy', 16)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (28, N'Simpsons artist', 18)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (29, N'ABCD', 19)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (30, N'Kristinuh', 19)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (31, N'prince paul', 19)
SET IDENTITY_INSERT [dbo].[clients] OFF
SET IDENTITY_INSERT [dbo].[stylists] ON 

INSERT [dbo].[stylists] ([id], [name]) VALUES (14, N'Sammy')
INSERT [dbo].[stylists] ([id], [name]) VALUES (19, N'Shyla')
INSERT [dbo].[stylists] ([id], [name]) VALUES (16, N'Beth')
INSERT [dbo].[stylists] ([id], [name]) VALUES (17, N'WHooo')
INSERT [dbo].[stylists] ([id], [name]) VALUES (18, N'Janeie')
SET IDENTITY_INSERT [dbo].[stylists] OFF
