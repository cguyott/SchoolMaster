﻿CREATE PROCEDURE [dbo].[DeleteInstructor]
(
	@InstructorId INT,
	@Results INT OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @PersonId INT;
	DECLARE @RoleCount INT;

	SET @Results = -1;

	SELECT @PersonId = [PersonId] FROM [dbo].[Instructor]
	WHERE [Id] = @InstructorId;

	IF (@PersonId IS NOT NULL)
	BEGIN
		BEGIN TRY
			SELECT @RoleCount = COUNT(*) FROM [dbo].[PersonRoleMap] WHERE [PersonId] = @PersonId;

			BEGIN TRANSACTION
				IF (@RoleCount = 1)
				BEGIN
					DELETE FROM [dbo].[Address] WHERE [PersonId] = @PersonId;
					DELETE FROM [dbo].[Phone] WHERE [PersonId] = @PersonId;
					DELETE FROM [dbo].[Email] WHERE [PersonId] = @PersonId;
					DELETE FROM [dbo].[PersonRoleMap] WHERE [PersonId] = @PersonId AND [RoleId] = 1;
					DELETE FROM [dbo].[Instructor] WHERE [PersonId] = @PersonId;
					DELETE FROM [dbo].[Person] WHERE [Id] = @PersonId;
				END
				ELSE
				BEGIN
					DELETE FROM [dbo].[PersonRoleMap] WHERE [PersonId] = @PersonId AND [RoleId] = 1;
					DELETE FROM [dbo].[Instructor] WHERE [PersonId] = @PersonId;
				END
			COMMIT TRANSACTION
			SET @Results = 0;
		END TRY
		BEGIN CATCH
			IF (@@TRANCOUNT > 0)
			BEGIN
				ROLLBACK TRANSACTION
				THROW;
			END
		END CATCH;
	END
	ELSE
	BEGIN
		SET @Results = 1;
	END
END