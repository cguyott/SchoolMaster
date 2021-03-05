CREATE PROCEDURE [dbo].[GetAdministratorByLogin]
(
	@AdminLogin NVARCHAR(64)
)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @AdminId INT;

	SELECT @AdminId = a.[Id] FROM [dbo].[Administrator] a
	INNER JOIN [dbo].[Person] p ON p.[Login] = @AdminLogin AND a.[PersonId] = p.[Id]

	EXECUTE [dbo].[GetAdministrator] @AdminId
END