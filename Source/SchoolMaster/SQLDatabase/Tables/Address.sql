CREATE TABLE [dbo].[Address]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[PersonId] INT NOT NULL, 
    [Address1] NVARCHAR(95) NOT NULL, 
    [Address2] NVARCHAR(95) NULL, 
    [City] NVARCHAR(50) NOT NULL, 
    [State] NCHAR(2) NOT NULL, 
    [Zip] NVARCHAR(10) NOT NULL, 
    CONSTRAINT [PK_Address] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Address_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Person]([Id])
)
