CREATE TABLE [dbo].[Card]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [UserId] INT NOT NULL,
    [FolderId] INT NOT NULL, 
    [Cue] NVARCHAR(50) NOT NULL, 
    [Answer] NVARCHAR(50) NOT NULL, 
    [LearnDate] DATETIME NOT NULL, 
    [LastDayRepeatedAt] DATETIME NOT NULL, 
    [ShouldRepeatAt] DATETIME NOT NULL, 
    [CardStatusId] INT NOT NULL, 
    FOREIGN KEY (UserId) REFERENCES [dbo].[User](Id),
    FOREIGN KEY (FolderId) REFERENCES [dbo].[Folder](Id),
    FOREIGN KEY (CardStatusId) REFERENCES [dbo].[CardStatus](Id)
)
