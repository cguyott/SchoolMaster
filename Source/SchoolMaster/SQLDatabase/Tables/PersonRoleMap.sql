CREATE TABLE [dbo].[PersonRoleMap]
(
	[PersonId] INT NOT NULL, 
    [RoleId] INT NOT NULL,
	CONSTRAINT [PK_PersonRoleMap] PRIMARY KEY ([PersonId],[RoleId]),
	CONSTRAINT [FK_Person_Id] FOREIGN KEY ([PersonId]) REFERENCES [Person]([Id]),
	CONSTRAINT [FK_Role_Id] FOREIGN KEY ([RoleId]) REFERENCES [Role]([Id]),
)
