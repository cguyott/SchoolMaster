CREATE TABLE [dbo].[Email]
(
	[Id] INT NOT NULL IDENTITY(1,1), 
    [PersonId] INT NOT NULL, 
    [Email] NVARCHAR(256) NOT NULL,
    CONSTRAINT [PK_Email] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Email_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Person]([Id])
)
