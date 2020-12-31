USE [SchoolMaster]
GO

SET IDENTITY_INSERT [dbo].[Student] ON;

INSERT INTO [dbo].[Student] ([Id],[PersonId],[GradeLevel])
     VALUES (1,9,8)
	      , (2,10,9)
		  , (3,11,10)
		  , (4,12,11)
		  
SET IDENTITY_INSERT [dbo].[Student] OFF;
GO