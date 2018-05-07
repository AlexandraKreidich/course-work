CREATE TABLE [dbo].[Folder]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [UserId] INT NOT NULL,
    [Name] NVARCHAR(20) NOT NULL, 
    FOREIGN KEY (UserId) REFERENCES [dbo].[User](Id)
)