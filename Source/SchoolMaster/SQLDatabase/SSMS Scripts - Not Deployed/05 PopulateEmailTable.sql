USE [SchoolMaster]
GO

SET IDENTITY_INSERT [dbo].[Email] ON;

INSERT INTO [dbo].[Email] ([Id],[PersonId],[Email])
     VALUES (1,1,'email01@website.com')
	      , (2,2,'email02A@website.com')
		  , (3,2,'email02B@website.com')
		  , (4,3,'email03@website.com')
		  , (5,5,'email05@website.com')
		  , (6,6,'email06A@website.com')
		  , (7,6,'email06B@website.com')
		  , (8,7,'email07@website.com')
		  , (9,9,'email09@website.com')
		  , (10,10,'email10A@website.com')
		  , (11,10,'email10B@website.com')
		  , (12,11,'email11@website.com')
		  , (13,13,'email13@website.com')
		  , (14,14,'email14A@website.com')
		  , (15,14,'email14B@website.com')
		  , (16,15,'email15@website.com')
		  
SET IDENTITY_INSERT [dbo].[Email] OFF;
GO