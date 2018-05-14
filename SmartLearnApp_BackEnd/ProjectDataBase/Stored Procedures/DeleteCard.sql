CREATE PROCEDURE [dbo].[DeleteCard]
    @Id int
AS
    DELETE FROM dbo.[Card]
    WHERE Id = @Id