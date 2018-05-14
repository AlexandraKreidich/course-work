/*
Post-Deployment Script Template
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.
 Use SQLCMD syntax to include a file in the post-deployment script.
 Example:      :r .\myfile.sql
 Use SQLCMD syntax to reference a variable in the post-deployment script.
 Example:      :setvar TableName MyTable
               SELECT * FROM [$(TableName)]
--------------------------------------------------------------------------------------
*/

BEGIN TRY

    IF NOT EXISTS (SELECT 1 FROM dbo.[User] WHERE Id = 1)

    BEGIN TRANSACTION

    PRINT 'Inserting seed data for User table'

    INSERT INTO dbo.[User](PasswordHash, Salt, FirstName, LastName, Email)
    VALUES
        (0x5B75CFC9814F736F0F5333C06EF4FC0E1E295B650CE42A3C5CDC4EE28820C70504D33A352E19AC7C2AD7E7450E6C36816275CBC3AC6B092D1A01E13C55041B22, 0x32DE15C9947A0293ABF91273985EA1631C437CD422138FE4B916C58CFC1690CFBD6B40811F544D0670020DBE6E9F2D6DBC0D, 'Alexandr', 'Dimidov', 'a.dimidov@gmail.com'),
        (0xB7CBCA824304188F77EAADD65507B22B5EB3346B9DA8BC062852BB83F3D736E4EEDE7C74FCE59C5A7461B47EAE9B77A1DCDF32C72FA371B3C1A0E37DCE6AA335, 0xCD1243CDA5FF8555A77F62AA42C7CE40910110E5268462B46C928967B6888DBE03389EA89245D2282017D88B2F3CFF860C10, 'Leonid', 'Makarov', 'l.makarov@gmail.com'),
        (0x3188FC2F019CCC0AA692BE1F518550AA39289C00A8D5FA065F0067109BD8309B7B01DA229F4DD08E05A2C04FAA734B0E2C99F4C966A11BE01EC353961D68ED38, 0xF2AB25571633B18F23A97762C95D3636EFBF390ED3CB9B5246FCCC27B8976BA64805C44C19861501962DCD792885D7D3C6BF, 'Alexandra', 'Kreidich', 'kreydichalexandra@gmail.com'),
        (0x16F1ED0DB49FB34725288A6E3AE8A9FCAF2EA6E681FB5B64AFF263F9E0DD481765FEBF3542FB08B9D189C9AE304EA6FAEA2F5D50B285365C7EBBE15D04E0C670, 0x01A3FF1C8127196B04573BA2AF7B35D032356F5249CBE37D57A05C08136C3A6A37C8BA228A8B3186E4349C80D8606A31AC97, 'Ivan', 'Ivanov', 'i.ivanov@gmail.com'),
        (0x2C6286DF7CDE4B15E8314C677610C3C14B2A165670EB64F6353C46CC8671651DF27B212ED73497CC3028EC0CC9C46D2C000E004210067782D5562FDF8C01CF2F, 0xDF659A4735710A37C4165811B8B17B6193D8724AB1AF15C0D77175EDA59458EAE4D073BEDFC566DC656A814D5777C50F869A, 'Vladislav', 'Kochenko', 'v.makarov@gmail.com')

    INSERT INTO dbo.Folder(UserId, [Name])
    VALUES
        (3, N'face'), /*1*/
        (3, N'smile'), /*2*/
        (3, N'lips'), /*3*/
        (3, N'verbs of motion'), /*4*/
        (3, N'family') /*5*/

    INSERT INTO dbo.Card(UserId, FolderId, Cue, Answer, LearnDate, LastDayRepeatedAt, ShouldRepeatAt)
    VALUES
        (3, 1, 'clean-shaven', N'гладко выбритое', convert(date, '20180513'), convert(date, '20180513'), convert(date, '20180514')),
        (3, 1, 'fleshy', N'мясистое', convert(date, '20180513'), convert(date, '20180513'), convert(date, '20180514')),
        (3, 1, 'freckled', N'веснушчатое', convert(date, '20180513'), convert(date, '20180513'), convert(date, '20180514')),
        (3, 1, 'gaunt', N'изможденное', convert(date, '20180513'), convert(date, '20180513'), convert(date, '20180514')),
        (3, 1, 'long', N'длинное', convert(date, '20180513'), convert(date, '20180513'), convert(date, '20180514')),
        (3, 1, 'oval', N'овальное', convert(date, '20180513'), convert(date, '20180513'), convert(date, '20180514')),
        (3, 1, 'pasty', N'болезненно-бледное', convert(date, '20180513'), convert(date, '20180513'), convert(date, '20180514')),
        (3, 1, 'pimpled', N'прыщеватое', convert(date, '20180513'), convert(date, '20180513'), convert(date, '20180514')),
        (3, 1, 'pock-marked', N'рябое', convert(date, '20180513'), convert(date, '20180513'), convert(date, '20180514')),
        (3, 1, 'puffy', N'одутловатое', convert(date, '20180513'), convert(date, '20180513'), convert(date, '20180514')),
        (3, 1, 'round', N'круглое', convert(date, '20180513'), convert(date, '20180513'), convert(date, '20180514')),
        (3, 1, 'square', N'квадратное', convert(date, '20180513'), convert(date, '20180513'), convert(date, '20180514')),
        (3, 1, 'sunburned / tanned / browned', N'загорелое', convert(date, '20180513'), convert(date, '20180513'), convert(date, '20180514')),
        (3, 1, 'swarthy', N'смуглое', convert(date, '20180513'), convert(date, '20180513'), convert(date, '20180514')),
        (3, 1, 'thin', N'худое', convert(date, '20180513'), convert(date, '20180513'), convert(date, '20180514')),
        (3, 1, 'wrinkled', N'морщинистое', convert(date, '20180513'), convert(date, '20180513'), convert(date, '20180514')),
        (3, 2, 'broad', N'широкая', convert(date, '20180513'), convert(date, '20180513'), convert(date, '20180514')),
        (3, 2, 'charming', N'прелестная, очаровательная', convert(date, '20180513'), convert(date, '20180513'), convert(date, '20180514')),
        (3, 2, 'cunning', N'хитрая', convert(date, '20180513'), convert(date, '20180513'), convert(date, '20180514')),
        (3, 2, 'engaging', N'обаятельная', convert(date, '20180513'), convert(date, '20180513'), convert(date, '20180514')),
        (3, 2, 'enigmatic', N'загадочная', convert(date, '20180513'), convert(date, '20180513'), convert(date, '20180514')),
        (3, 2, 'faint', N'едва заметная', convert(date, '20180513'), convert(date, '20180513'), convert(date, '20180514')),
        (3, 2, 'happy', N'счастливая', convert(date, '20180513'), convert(date, '20180513'), convert(date, '20180514')),
        (3, 2, 'ironical', N'ироническая', convert(date, '20180513'), convert(date, '20180513'), convert(date, '20180514')),
        (3, 2, 'pleasant', N'приятная', convert(date, '20180513'), convert(date, '20180513'), convert(date, '20180514')),
        (3, 2, 'pleased', N'довольная', convert(date, '20180513'), convert(date, '20180513'), convert(date, '20180514')),
        (3, 2, 'sad', N'печальная', convert(date, '20180513'), convert(date, '20180513'), convert(date, '20180514')),
        (3, 2, 'strained', N'деланная, искусственная', convert(date, '20180513'), convert(date, '20180513'), convert(date, '20180514')),
        (3, 2, 'sweet', N'ласковая, милая', convert(date, '20180513'), convert(date, '20180513'), convert(date, '20180514')),
        (3, 2, 'winning', N'привлекательная', convert(date, '20180513'), convert(date, '20180513'), convert(date, '20180514'))

    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    PRINT ERROR_MESSAGE();
END catch