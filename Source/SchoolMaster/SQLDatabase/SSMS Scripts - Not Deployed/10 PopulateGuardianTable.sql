USE [SchoolMaster]
GO

SET IDENTITY_INSERT [dbo].[Guardian] ON;

INSERT INTO [dbo].[Guardian] ([Id],[PersonId])
     VALUES (1,3)
	      , (2,8)
		  , (3,13)
		  , (4,14)
		  , (5,15)
		  , (6,16)
		  
SET IDENTITY_INSERT [dbo].[Guardian] OFF;
GO