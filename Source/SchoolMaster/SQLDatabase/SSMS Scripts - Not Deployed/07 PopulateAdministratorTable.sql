USE [SchoolMaster]
GO

SET IDENTITY_INSERT [dbo].[Administrator] ON;

INSERT INTO [dbo].[Administrator] ([Id],[PersonId],[Department],[Position])
     VALUES (1,1,'Department01','Position01')
	      , (2,2,'Department02','Position01')
		  , (3,3,'Department03','Position01')
		  , (4,4,'Department01','Position02')
		  
SET IDENTITY_INSERT [dbo].[Administrator] OFF;
GO