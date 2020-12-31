CREATE TABLE [dbo].[StudentGuardianMap]
(
	[StudentId] INT NOT NULL, 
    [GuardianId] INT NOT NULL,
	[ContactOrder] INT NOT NULL, 
    CONSTRAINT [PK_StudentGuardianMap] PRIMARY KEY ([StudentId],[GuardianId]),
	CONSTRAINT [FK_Student_Id] FOREIGN KEY ([StudentId]) REFERENCES [Student]([Id]),
	CONSTRAINT [FK_Guardian_Id] FOREIGN KEY ([GuardianId]) REFERENCES [Guardian]([Id]),
)
