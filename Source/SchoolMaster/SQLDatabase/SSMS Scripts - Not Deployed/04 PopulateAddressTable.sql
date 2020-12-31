USE [SchoolMaster]
GO

SET IDENTITY_INSERT [dbo].[Address] ON;

INSERT INTO [dbo].[Address] ([Id],[PersonId],[Address1],[Address2],[City],[State],[Zip])
     VALUES (1,1,'Address101','Address201','City01','MA','11111')
	      , (2,2,'Address102A','Address202A','City02','MA','22222')
		  , (3,2,'Address102B','Address202B','City02','MA','22222')
		  , (4,4,'Address104',NULL,'City04','MA','44444')
		  , (5,5,'Address105A','Address205A','City05','MA','55555')
		  , (6,5,'Address105B','Address205B','City05','MA','55555')
		  , (7,6,'Address106','Address206','City06','MA','66666')
		  , (8,8,'Address108',NULL,'City08','MA','88888')
		  , (9,9,'Address109A','Address209A','City09','MA','99999')
		  , (10,9,'Address109B','Address209B','City09','MA','99999')
		  , (11,10,'Address110','Address210','City10','MA','10101')
		  , (12,12,'Address112',NULL,'City12','MA','12121')
		  , (13,13,'Address113A','Address213A','City13','MA','13131')
		  , (14,13,'Address113B','Address213B','City13','MA','13131')
		  , (15,14,'Address114','Address214','City14','MA','14141')
		  , (16,16,'Address116',NULL,'City16','MA','16161')
		  
SET IDENTITY_INSERT [dbo].[Address] OFF;
GO