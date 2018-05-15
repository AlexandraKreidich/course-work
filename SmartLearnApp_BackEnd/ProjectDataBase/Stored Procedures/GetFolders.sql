CREATE PROCEDURE [dbo].[GetFolders]
    @UserId int
AS
    SELECT
        Folder.Id,
        UserId,
        [Name]
    FROM
        Folder
            JOIN [User] ON [User].Id = Folder.UserId
    WHERE [User].Id = @UserId
RETURN 0
