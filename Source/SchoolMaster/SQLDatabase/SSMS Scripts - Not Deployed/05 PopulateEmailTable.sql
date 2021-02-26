USE [SchoolMaster]
GO

SET IDENTITY_INSERT [dbo].[Email] ON;

INSERT INTO [dbo].[Email] ([Id],[PersonId],[Email])
     VALUES (1,1,'email01@website.com')
	      , (2,2,'email02@website.com')
		  , (3,3,'email03@website.com')
		  , (4,5,'email05@website.com')
		  , (5,6,'email06@website.com')
		  , (6,7,'email07@website.com')
		  , (7,9,'email09@website.com')
		  , (8,10,'email10A@website.com')
		  , (9,11,'email11@website.com')
		  , (10,13,'email13@website.com')
		  , (11,14,'email14A@website.com')
		  , (12,15,'email15@website.com')
		  
SET IDENTITY_INSERT [dbo].[Email] OFF;
GO