CREATE PROCEDURE [dbo].[UpdateAdministrator]
(
    @AdministratorId INT,
    @Prefix NVARCHAR(6), 
    @FirstName NVARCHAR(50), 
    @MiddleName NVARCHAR(50), 
    @LastName NVARCHAR(50), 
    @Suffix NVARCHAR(6), 
    @Login NVARCHAR(64),  
    @Email NVARCHAR(256),
    @Department NVARCHAR(128), 
    @Position NVARCHAR(128),
    @Addresses [dbo].[AddressTable] READONLY,
    @PhoneNumbers [dbo].[PhoneTable] READONLY,
    @Results INT OUTPUT
)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE @Count INT = -1;
    DECLARE @PersonId INT = -1;

    DECLARE @Address1 NVARCHAR(95);
    DECLARE @Address2 NVARCHAR(95);
    DECLARE @City NVARCHAR(50);
    DECLARE @State NCHAR(2);
    DECLARE @Zip NVARCHAR(10);

    DECLARE @AreaCode NCHAR(3);
    DECLARE @ExchangeCode NCHAR(3);
    DECLARE @SubscriberNumber NCHAR(4);
    DECLARE @ContactOrder INT;

    SET @Results = -1; -- Indicates an unknown or unexpected failure.

    BEGIN TRY
        SELECT @PersonId = [PersonId] FROM [dbo].[Administrator] WHERE [Id] = @AdministratorId

        IF (@PersonId > 0)
        BEGIN
            BEGIN TRANSACTION
                UPDATE [dbo].[Administrator] SET [Department] = @Department, [Position] = @Position WHERE [Id] = @AdministratorId;

                UPDATE [dbo].[Person]
                SET
                    [Prefix] = @Prefix,
                    [FirstName] = @FirstName,
                    [MiddleName] = @MiddleName,
                    [LastName] = @LastName,
                    [Suffix] = @Suffix,
                    [Login] = @Login
                WHERE [Id] =@PersonId;

                DELETE FROM [dbo].[Email] WHERE [PersonId] = @PersonId;

                INSERT INTO [dbo].[Email]
                (
                    [PersonId],
                    [Email]
                )
                VALUES
                (
                    @PersonId,
                    @Email
                );

                DELETE FROM [dbo].[Address] WHERE [PersonId] = @PersonId;

                DECLARE addressCursor CURSOR FOR SELECT [Address1], [Address2], [City], [State], [Zip] FROM @Addresses
                OPEN addressCursor
                FETCH NEXT FROM addressCursor INTO @Address1, @Address2, @City, @State, @Zip
                WHILE @@FETCH_STATUS = 0
                BEGIN
                    INSERT INTO [dbo].[Address]
                    (
                        [PersonId],
                        [Address1],
                        [Address2],
                        [City],
                        [State],
                        [Zip]
                    )
                    VALUES
                    (
                        @PersonId,
                        @Address1,
                        @Address2,
                        @City,
                        @State,
                        @Zip
                    );

                    FETCH NEXT FROM addressCursor INTO @Address1, @Address2, @City, @State, @Zip
                END
                
                DELETE FROM [dbo].[Phone] WHERE [PersonId] = @PersonId;

                DECLARE phoneCursor CURSOR FOR SELECT [AreaCode], [ExchangeCode], [SubscriberNumber], [ContactOrder] FROM @PhoneNumbers
                OPEN phoneCursor
                FETCH NEXT FROM phoneCursor INTO @AreaCode, @ExchangeCode, @SubscriberNumber, @ContactOrder
                WHILE @@FETCH_STATUS = 0
                BEGIN
                    INSERT INTO [dbo].[Phone]
                    (
                        [PersonId], 
                        [AreaCode], 
                        [ExchangeCode], 
                        [SubscriberNumber], 
                        [ContactOrder]
                    )
                    VALUES
                    (
                        @PersonId,
                        @AreaCode,
                        @ExchangeCode,
                        @SubscriberNumber,
                        @ContactOrder
                    );

                    FETCH NEXT FROM phoneCursor INTO @AreaCode, @ExchangeCode, @SubscriberNumber, @ContactOrder
                END

            COMMIT TRANSACTION
            SET @Results = 0;
        END
        ELSE
        BEGIN
            SET @Results = 1;  -- Indicates that this administrator does not exist.
        END
    END TRY
    BEGIN CATCH
        IF (@@TRANCOUNT > 0)
        BEGIN
            ROLLBACK TRANSACTION
        END;
        THROW;
    END CATCH
END