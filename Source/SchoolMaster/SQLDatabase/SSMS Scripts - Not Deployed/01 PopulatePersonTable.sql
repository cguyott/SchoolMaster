USE [SchoolMaster]
GO

SET IDENTITY_INSERT [dbo].[Person] ON;

INSERT INTO [dbo].[Person] ([Id],[Prefix],[FirstName],[MiddleName],[LastName],[Suffix],[Login],[LastLoginDate],[PasswordHash],[PasswordSalt],[LastPasswordChangedDate],[CreatedDate])
     VALUES (1,'Mr.','FirstName01','MiddleName01','LastName01','Jr.','Person01Login',GETUTCDATE(),'PasswordHash01','PasswordSalt01',GETUTCDATE(),GETUTCDATE())
	      , (2,'Mrs.','FirstName02','MiddleName02','LastName02','III','Person02Login',GETUTCDATE(),'PasswordHash02','PasswordSalt02',GETUTCDATE(),GETUTCDATE())
		  , (3,NULL,'FirstName03','MiddleName03','LastName03',NULL,'Person03Login',GETUTCDATE(),'PasswordHash03','PasswordSalt03',GETUTCDATE(),GETUTCDATE())
		  , (4,NULL,'FirstName04','MiddleName04','LastName04',NULL,'Person04Login',GETUTCDATE(),'PasswordHash04','PasswordSalt04',GETUTCDATE(),GETUTCDATE())		  
		  , (5,NULL,'FirstName05','MiddleName05','LastName05',NULL,'Person05Login',GETUTCDATE(),'PasswordHash05','PasswordSalt05',GETUTCDATE(),GETUTCDATE())
		  , (6,NULL,'FirstName06','MiddleName06','LastName06',NULL,'Person06Login',GETUTCDATE(),'PasswordHash06','PasswordSalt06',GETUTCDATE(),GETUTCDATE())
		  , (7,NULL,'FirstName07','MiddleName07','LastName07','Sr.','Person07Login',GETUTCDATE(),'PasswordHash07','PasswordSalt07',GETUTCDATE(),GETUTCDATE())
		  , (8,NULL,'FirstName08','MiddleName08','LastName08',NULL,'Person08Login',GETUTCDATE(),'PasswordHash08','PasswordSalt08',GETUTCDATE(),GETUTCDATE())
		  , (9,NULL,'FirstName09','MiddleName09','LastName09',NULL,'Person09Login',GETUTCDATE(),'PasswordHash09','PasswordSalt09',GETUTCDATE(),GETUTCDATE())
		  , (10,'Ms.','FirstName10','MiddleName10','LastName10',NULL,'Person10Login',GETUTCDATE(),'PasswordHash10','PasswordSalt10',GETUTCDATE(),GETUTCDATE())
		  , (11,NULL,'FirstName11','MiddleName11','LastName11',NULL,'Person11Login',GETUTCDATE(),'PasswordHash11','PasswordSalt11',GETUTCDATE(),GETUTCDATE())
		  , (12,NULL,'FirstName12','MiddleName12','LastName12',NULL,'Person12Login',GETUTCDATE(),'PasswordHash12','PasswordSalt12',GETUTCDATE(),GETUTCDATE())
		  , (13,NULL,'FirstName13','MiddleName13','LastName13',NULL,'Person13Login',GETUTCDATE(),'PasswordHash13','PasswordSalt13',GETUTCDATE(),GETUTCDATE())
		  , (14,NULL,'FirstName14','MiddleName14','LastName14',NULL,'Person14Login',GETUTCDATE(),'PasswordHash14','PasswordSalt14',GETUTCDATE(),GETUTCDATE())
		  , (15,'Miss','FirstName15','MiddleName15','LastName15',NULL,'Person15Login',GETUTCDATE(),'PasswordHash15','PasswordSalt15',GETUTCDATE(),GETUTCDATE())
		  , (16,NULL,'FirstName16','MiddleName16','LastName16',NULL,'Person16Login',GETUTCDATE(),'PasswordHash16','PasswordSalt16',GETUTCDATE(),GETUTCDATE())

SET IDENTITY_INSERT [dbo].[Person] OFF;
GO