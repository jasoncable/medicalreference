CREATE TABLE [dbo].[PharmaClassClass]
(
    [Id] INT NOT NULL IDENTITY,
    [NAME] VARCHAR(100) NOT NULL,
    [ExtendedName] VARCHAR(500) NULL,
    CONSTRAINT [PK_PharmaClassClass] PRIMARY KEY CLUSTERED (Id)
)
