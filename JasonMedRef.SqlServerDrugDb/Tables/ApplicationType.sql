CREATE TABLE [dbo].[ApplicationType]
(
    [Id] INT NOT NULL IDENTITY,
    [Name] VARCHAR(100) NOT NULL,
    CONSTRAINT [PK_ApplicationType] PRIMARY KEY CLUSTERED (Id)
)
