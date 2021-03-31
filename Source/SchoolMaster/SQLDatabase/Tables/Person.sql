CREATE TABLE [dbo].[Person]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[Prefix] NVARCHAR(6) NULL, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [MiddleName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Suffix] NVARCHAR(6) NULL, 
    [Login] NVARCHAR(64) NOT NULL, 
    [LastLoginDate] DATETIME2 NULL, 
    [PasswordHash] NVARCHAR(30) NULL, 
    [PasswordSalt] NVARCHAR(30) NULL, 
    [LastPasswordChangedDate] DATETIME2 NULL, 
    [CreatedDate] DATETIME2 NOT NULL, 
    CONSTRAINT [PK_Person] PRIMARY KEY ([Id]),
    CONSTRAINT [UNQ_Login] UNIQUE NONCLUSTERED ([Login] ASC)
);
GO

CREATE UNIQUE INDEX UQ_Login ON [dbo].[Person] ([Login]);
GO