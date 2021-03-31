CREATE TABLE [dbo].[Guardian]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[PersonId] INT NOT NULL, 
    CONSTRAINT [PK_Guardian] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Guardian_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Person]([Id]),
    CONSTRAINT [UNQ_Guardian_PersonId] UNIQUE(PersonId)
)
