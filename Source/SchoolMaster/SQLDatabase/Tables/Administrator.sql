CREATE TABLE [dbo].[Administrator]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[PersonId] INT NOT NULL, 
    [Department] NVARCHAR(128) NOT NULL, 
    [Position] NVARCHAR(128) NOT NULL, 
    CONSTRAINT [PK_Administrator] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Administrator_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Person]([Id]),
    CONSTRAINT [UNQ_Aministrator_PersonId] UNIQUE(PersonId)
)
