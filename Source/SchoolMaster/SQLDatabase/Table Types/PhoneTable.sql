CREATE TYPE [dbo].[PhoneTable] AS TABLE
(
    [AreaCode] NCHAR(3) NOT NULL, 
    [ExchangeCode] NCHAR(3) NOT NULL, 
    [SubscriberNumber] NCHAR(4) NOT NULL, 
    [ContactOrder] INT NOT NULL
)
