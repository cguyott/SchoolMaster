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

-- Uncomment these lines to load test data when the database is published.
-- 
:r "..\SSMS Scripts - Not Deployed\01 PopulatePersonTable.sql"
:r "..\SSMS Scripts - Not Deployed\02 PopulateRoleTable.sql"
:r "..\SSMS Scripts - Not Deployed\03 PopulatePersonRoleMapTable.sql"
:r "..\SSMS Scripts - Not Deployed\04 PopulateAddressTable.sql"
:r "..\SSMS Scripts - Not Deployed\05 PopulateEmailTable.sql"
:r "..\SSMS Scripts - Not Deployed\06 PopulatePhoneTable.sql"
:r "..\SSMS Scripts - Not Deployed\07 PopulateAdministratorTable.sql"
:r "..\SSMS Scripts - Not Deployed\08 PopulateInstructorTable.sql"
:r "..\SSMS Scripts - Not Deployed\09 PopulateStudentTable.sql"
:r "..\SSMS Scripts - Not Deployed\10 PopulateGuardianTable.sql"
:r "..\SSMS Scripts - Not Deployed\11 PopulateStudentGuardianTable.sql"
