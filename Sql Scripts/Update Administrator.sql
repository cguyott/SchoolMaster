USE [SchoolMaster]
GO

DECLARE @AdministratorId int
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
DECLARE @Results int

-- TODO: Set parameter values here.
SET @AdministratorId = 7;
SET @Prefix = NULL;
SET @FirstName = 'FirstName50';
SET @MiddleName = 'MiddleName50';
SET @LastName = 'LastName50';
SET @Suffix = NULL;
SET @Login = 'Person50Login';
SET @Email = 'address50@email.com';
SET @Department = 'Chemistry50';
SET @Position = 'Chemist50';

INSERT @Addresses ([Address1], [Address2], [City], [State], [Zip])
 VALUES ('SomeAddress1-1-50', 'SomeAddress2-1-50', 'SomeCity50', '50', '01075-5050');
INSERT @Addresses ([Address1], [Address2], [City], [State], [Zip])
 VALUES ('SomeAddress1-2-50', 'SomeAddress2-2-50', 'SomeCity250', 'M2', '01075');

INSERT @PhoneNumbers ([AreaCode], [ExchangeCode], [SubscriberNumber], [ContactOrder])
 VALUES ('501', '501', '5011', 1);
INSERT @PhoneNumbers ([AreaCode], [ExchangeCode], [SubscriberNumber], [ContactOrder])
 VALUES ('502', '502', '5022', 2);

EXECUTE [dbo].[UpdateAdministrator] 
   @AdministratorId
  ,@Prefix
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
  ,@Results OUTPUT

  SELECT @Results AS Results;