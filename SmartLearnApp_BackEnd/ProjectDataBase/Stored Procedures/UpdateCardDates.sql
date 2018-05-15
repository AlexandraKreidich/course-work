CREATE PROCEDURE [dbo].[UpdateCardDates]
    @Id int,
    @LearnDate DateTime,
    @LastDayRepeatedAt DATE,
    @ShouldRepeatAt DATE
AS
    UPDATE Card
    SET
        LearnDate = @LearnDate,
        LastDayRepeatedAt = @LastDayRepeatedAt,
        ShouldRepeatAt = @ShouldRepeatAt
    WHERE
        Id = @Id;
RETURN 0;
