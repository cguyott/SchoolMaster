USE [SchoolMaster]
GO

SET IDENTITY_INSERT [dbo].[Instructor] ON;

INSERT INTO [dbo].[Instructor] ([Id],[PersonId],[Department],[Position])
     VALUES (1,5,'Department01','Position01')
	      , (2,6,'Department02','Position01')
		  , (3,7,'Department01','Position02')
		  , (4,8,'Department04','Position01')
		  
SET IDENTITY_INSERT [dbo].[Instructor] OFF;
GO