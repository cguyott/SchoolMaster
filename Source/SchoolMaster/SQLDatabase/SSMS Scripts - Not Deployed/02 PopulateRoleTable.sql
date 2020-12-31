USE [SchoolMaster]
GO

SET IDENTITY_INSERT [dbo].[Role] ON;

INSERT INTO [dbo].[Role] ([Id],[Description])
     VALUES (1,'Administrator')
	      , (2,'Instructor')
		  , (3,'Student')
		  , (4,'Guardian')		 
		  
SET IDENTITY_INSERT [dbo].[Role] OFF;
GO