DECLARE @AdministratorId INT = 7;

SELECT * FROM Administrator WHERE Id = @AdministratorId;

SELECT p.* FROM Person p
INNER JOIN Administrator a ON a.PersonId = p.Id
WHERE a.Id = @AdministratorId;

SELECT addr.* FROM Address addr
INNER JOIN Administrator a ON a.PersonId = addr.PersonId
WHERE a.Id = @AdministratorId;

SELECT p.* FROM Phone p
INNER JOIN Administrator a ON a.PersonId = p.PersonId
WHERE a.Id = @AdministratorId;

SELECT p.* FROM PersonRoleMap p
INNER JOIN Administrator a ON a.PersonId = p.PersonId
WHERE a.Id = @AdministratorId;

SELECT e.* FROM Email e
INNER JOIN Administrator a ON a.PersonId = e.PersonId
WHERE a.Id = @AdministratorId;