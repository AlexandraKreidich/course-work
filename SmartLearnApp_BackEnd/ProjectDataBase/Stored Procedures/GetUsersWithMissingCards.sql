CREATE PROCEDURE [dbo].[GetUsersWithMissingCards]
AS
    DECLARE @DateNow date;
    SET @DateNow = CONVERT (date, GETDATE());
    SELECT DISTINCT
        [User].Id,
        [User].FirstName,
        [User].LastName,
        [User].Email,
        [User].Salt,
        [User].PasswordHash
    FROM dbo.[User]
        JOIN [Card] ON [Card].UserId = [User].Id
    WHERE [Card].ShouldRepeatAt < @DateNow