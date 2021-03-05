CREATE PROCEDURE [dbo].[DeleteAdministrator]
(
	@AdminId INT,
	@Results INT OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @PersonId INT;
	DECLARE @RoleCount INT;

	SET @Results = -1;

	SELECT @PersonId = [PersonId] FROM [dbo].[Administrator]
	WHERE [Id] = @AdminId;

	IF (@PersonId IS NOT NULL)
	BEGIN
		BEGIN TRY
			SELECT @RoleCount = COUNT(*) FROM [dbo].[PersonRoleMap] WHERE [PersonId] = @PersonId;

			BEGIN TRANSACTION PROCESSDELETE;
				IF (@RoleCount = 1)
				BEGIN
					DELETE FROM [dbo].[Address] WHERE [PersonId] = @PersonId;
					DELETE FROM [dbo].[Phone] WHERE [PersonId] = @PersonId;
					DELETE FROM [dbo].[Email] WHERE [PersonId] = @PersonId;
					DELETE FROM [dbo].[PersonRoleMap] WHERE [PersonId] = @PersonId AND [RoleId] = 1;
					DELETE FROM [dbo].[Administrator] WHERE [PersonId] = @PersonId;
					DELETE FROM [dbo].[Person] WHERE [Id] = @PersonId;
				END
				ELSE
				BEGIN
					DELETE FROM [dbo].[PersonRoleMap] WHERE [PersonId] = @PersonId AND [RoleId] = 1;
					DELETE FROM [dbo].[Administrator] WHERE [PersonId] = @PersonId;
				END
			COMMIT TRANSACTION PROCESSDELETE;
			SET @Results = 0;
		END TRY
		BEGIN CATCH
			IF (@@TRANCOUNT > 0)
			BEGIN
				ROLLBACK TRANSACTION PROCESSDELETE;
				THROW;
			END
		END CATCH;
	END
	ELSE
	BEGIN
		SET @Results = 1;
	END
END