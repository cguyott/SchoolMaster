SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF (SELECT COUNT([Id]) FROM [dbo].[Role]) = 0
BEGIN
    SET IDENTITY_INSERT [dbo].[Role] ON;

    BEGIN TRY
        BEGIN TRANSACTION

        INSERT INTO [dbo].[Role] ([Id],[Description])
             VALUES (1,'Administrator')
	              , (2,'Instructor')
		          , (3,'Student')
		          , (4,'Guardian')

        COMMIT TRANSACTION

        PRINT 'Finished initializing the Role table.'
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION

        PRINT 'Failed to initialize the Role table.'
    END CATCH

    SET IDENTITY_INSERT [dbo].[Role] OFF;
END