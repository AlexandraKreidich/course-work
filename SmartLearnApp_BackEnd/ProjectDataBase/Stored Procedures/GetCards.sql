CREATE PROCEDURE [dbo].[GetCards]
    @UserId int
AS
    DECLARE @NowDate date;
    SET @NowDate = CONVERT (date, GETDATE());
    SELECT *
    FROM dbo.[Card]
    WHERE (UserId = @UserId) AND (ShouldRepeatAt = @NowDate) 