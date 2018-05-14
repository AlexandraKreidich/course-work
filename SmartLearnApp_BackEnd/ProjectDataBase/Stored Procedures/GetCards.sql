CREATE PROCEDURE [dbo].[GetCards]
    @UserId int
AS
    SELECT *
    FROM dbo.[Card]
    WHERE UserId = @UserId