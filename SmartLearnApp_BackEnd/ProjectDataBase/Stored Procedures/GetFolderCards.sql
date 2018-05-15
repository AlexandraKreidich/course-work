CREATE PROCEDURE [dbo].[GetFolderCards]
    @FolderId int
AS
    SELECT
        Card.Id,
        Card.UserId,
        Card.FolderId,
        Card.Cue,
        Card.Answer,
        Card.LearnDate,
        Card.LastDayRepeatedAt,
        Card.ShouldRepeatAt
    FROM
        Card
            JOIN Folder ON Folder.Id = Card.FolderId
    WHERE Card.FolderId = @FolderId
RETURN 0
