CREATE TABLE [dbo].[Phone]
(
	[Id] INT NOT NULL IDENTITY(1,1), 
    [PersonId] INT NOT NULL, 
    [AreaCode] NCHAR(3) NOT NULL, 
    [ExchangeCode] NCHAR(3) NOT NULL, 
    [SubscriberNumber] NCHAR(4) NOT NULL, 
    [ContactOrder] INT NOT NULL,
    CONSTRAINT [PK_Phone] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Phone_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Person]([Id])
)
