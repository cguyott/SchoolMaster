CREATE TABLE [dbo].[Student]
(
	[Id] INT NOT NULL IDENTITY(1,1), 
    [PersonId] INT NOT NULL, 
    [GradeLevel] INT NOT NULL,
    CONSTRAINT [PK_Student] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Student_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Person]([Id])
)
