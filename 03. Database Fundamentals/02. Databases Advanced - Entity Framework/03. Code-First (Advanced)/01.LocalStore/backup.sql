USE [_01.LocalStore.ProductsContext]
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Name], [Distributor], [Discription], [Price]) VALUES (1, N'Peanut Butter', N'PB Inc.', N'ot shtastlivi fastaci', CAST(5.40 AS Decimal(18, 2)))
INSERT [dbo].[Products] ([Id], [Name], [Distributor], [Discription], [Price]) VALUES (2, N'Lyutenica', N'Lyut Inc.', N'Ot shtastlivi domati', CAST(3.40 AS Decimal(18, 2)))
INSERT [dbo].[Products] ([Id], [Name], [Distributor], [Discription], [Price]) VALUES (3, N'Salt', N'Salt Inc.', N'ot shtastlivo more', CAST(3.10 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Products] OFF
