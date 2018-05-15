CREATE PROCEDURE [dbo].[DeleteFolder]
    @Id INT
AS
    DELETE
    FROM dbo.Folder
    WHERE Folder.Id = @Id
