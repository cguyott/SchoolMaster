CREATE PROCEDURE [dbo].[GetAdministrator]
(
	@AdminId INT
)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @PersonId INT;

	SELECT @PersonId = p.[Id]
	FROM [dbo].[Administrator] a
	INNER JOIN [dbo].[Person] p ON a.[PersonId] = p.[Id]
	WHERE a.[Id] = @AdminId;

	SELECT p.[AreaCode]
		  ,p.[ExchangeCode]
		  ,p.[SubscriberNumber]
		  ,p.[ContactOrder]
	FROM [dbo].[Phone] p
	WHERE p.[PersonId] = @PersonId
	ORDER BY p.[ContactOrder] ASC;

	SELECT a.[Address1]
		  ,a.[Address2]
		  ,a.[City]
		  ,a.[State]
		  ,a.[Zip]
	FROM [dbo].[Address] a
	WHERE a.[PersonId] = @PersonId;

	SELECT a.[Id]
		  ,a.[Department]
		  ,a.[Position]
		  ,p.[Prefix]
		  ,p.[FirstName]
		  ,p.[MiddleName]
		  ,p.[LastName]
		  ,p.[Suffix]
		  ,p.[Login]
		  ,p.[LastLoginDate]
		  ,p.[LastPasswordChangedDate]
		  ,p.[CreatedDate]
		  ,e.[Email]
	FROM [dbo].[Administrator] a
	INNER JOIN [dbo].[Person] p ON a.[PersonId] = p.[Id]
	LEFT JOIN [dbo].[Email] e ON a.[PersonId] = e.[PersonId]
	WHERE a.[Id] = @AdminId;
END