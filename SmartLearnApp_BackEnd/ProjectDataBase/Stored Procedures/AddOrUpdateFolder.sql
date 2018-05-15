CREATE PROCEDURE [dbo].[AddOrUpdateFolder]
    @Id INT,
    @UserId INT,
    @Name NVARCHAR(20)
AS
    MERGE dbo.Folder AS target
    USING
        (SELECT @Id, @UserId, @Name)
    AS source
        (Id, UserId, [Name])
    ON (target.Id = source.Id)
    WHEN MATCHED THEN
        UPDATE SET
            [Name] = @Name
    WHEN NOT MATCHED THEN
        INSERT (UserId, [Name])
        VALUES
        (
            source.[UserId],
            source.[Name]
        );
    select SCOPE_IDENTITY()
