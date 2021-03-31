USE [SchoolMaster]
GO

DECLARE @Prefix nvarchar(6)
DECLARE @FirstName nvarchar(50)
DECLARE @MiddleName nvarchar(50)
DECLARE @LastName nvarchar(50)
DECLARE @Suffix nvarchar(6)
DECLARE @Login nvarchar(64)
DECLARE @Email nvarchar(256)
DECLARE @Department nvarchar(128)
DECLARE @Position nvarchar(128)
DECLARE @Addresses [dbo].[AddressTable]
DECLARE @PhoneNumbers [dbo].[PhoneTable]
DECLARE @AdministratorId int
DECLARE @Results int

-- TODO: Set parameter values here.
SET @Prefix = 'Ms.';
SET @FirstName = 'Mary';
SET @MiddleName = 'Kate';
SET @LastName = 'Smith';
SET @Suffix = 'Jr.';
SET @Login = 'MSmith';
SET @Email = 'MSmith@email.com';
SET @Department = 'Chemistry';
SET @Position = 'Chemist';

INSERT @Addresses ([Address1], [Address2], [City], [State], [Zip])
 VALUES ('SomeAddress1', 'SomeAddress2', 'SomeCity', 'MA', '01075-1234');
INSERT @Addresses ([Address1], [Address2], [City], [State], [Zip])
 VALUES ('SomeAddress1-2', 'SomeAddress2-2', 'SomeCity2', 'M2', '01075');

INSERT @PhoneNumbers ([AreaCode], [ExchangeCode], [SubscriberNumber], [ContactOrder])
 VALUES ('111', '111', '1111', 1);
INSERT @PhoneNumbers ([AreaCode], [ExchangeCode], [SubscriberNumber], [ContactOrder])
 VALUES ('222', '222', '2222', 2);

EXECUTE [dbo].[CreateAdministrator] 
   @Prefix
  ,@FirstName
  ,@MiddleName
  ,@LastName
  ,@Suffix
  ,@Login
  ,@Email
  ,@Department
  ,@Position
  ,@Addresses
  ,@PhoneNumbers
  ,@AdministratorId OUTPUT
  ,@Results OUTPUT

SELECT @AdministratorId AS AdminId, @Results AS Results;