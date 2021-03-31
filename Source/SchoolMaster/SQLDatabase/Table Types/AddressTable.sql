CREATE TYPE [dbo].[AddressTable] AS TABLE
(
    [Address1] NVARCHAR(95) NOT NULL, 
    [Address2] NVARCHAR(95) NULL, 
    [City] NVARCHAR(50) NOT NULL, 
    [State] NCHAR(2) NOT NULL, 
    [Zip] NVARCHAR(10) NOT NULL
)
