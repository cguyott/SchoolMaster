CREATE TABLE [dbo].[Instructor]
(
	[Id] INT NOT NULL IDENTITY(1,1), 
    [PersonId] INT NOT NULL, 
    [Department] NVARCHAR(128) NOT NULL, 
    [Position] NVARCHAR(128) NOT NULL,
    CONSTRAINT [PK_Instructor] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Instructor_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Person]([Id])
)
