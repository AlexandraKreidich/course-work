CREATE PROCEDURE [dbo].[AddOrUpdateCard]
    @Id int,
    @UserId int,
    @FolderId int,
    @Cue nvarchar(50),
    @Answer nvarchar(50),
    @LearnDate date,
    @LastDayRepeatedAt date,
    @ShouldRepeatAt date
AS
    MERGE dbo.Card AS target
    USING
        (SELECT @Id, @UserId, @FolderId, @Cue, @Answer, @LearnDate, @LastDayRepeatedAt, @ShouldRepeatAt)
    AS source
        (Id, UserId, FolderId, Cue, Answer, LearnDate, LastDayRepeatedAt, ShouldRepeatAt)
    ON (target.Id = source.Id)
    WHEN MATCHED THEN
        UPDATE SET
            Cue = source.Cue,
            Answer = source.Answer
    WHEN NOT MATCHED THEN
        INSERT (UserId, FolderId, Cue, Answer, LearnDate, LastDayRepeatedAt, ShouldRepeatAt)
        VALUES
        (
            source.UserId,
            source.FolderId,
            source.Cue,
            source.Answer,
            source.LearnDate,
            source.LastDayRepeatedAt,
            source.ShouldRepeatAt
        );
    select SCOPE_IDENTITY()