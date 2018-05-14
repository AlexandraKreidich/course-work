CREATE TABLE [dbo].[Card]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [UserId] INT NOT NULL,
    [FolderId] INT NOT NULL,
    [Cue] NVARCHAR(50) NOT NULL,
    [Answer] NVARCHAR(50) NOT NULL,
    [LearnDate] DATE NOT NULL,
    [LastDayRepeatedAt] DATE NOT NULL,
    [ShouldRepeatAt] DATE NOT NULL,
    FOREIGN KEY (FolderId) REFERENCES [dbo].[Folder](Id) ON DELETE CASCADE,
    FOREIGN KEY (UserId) REFERENCES [dbo].[User](Id)
)
