CREATE TABLE [dbo].[MarketingCategory]
(
    [Id] INT NOT NULL IDENTITY,
    [Name] VARCHAR(500) NOT NULL,
    [NameExtended] VARCHAR(MAX) NULL,
    CONSTRAINT [PK_MarketingCategory] PRIMARY KEY CLUSTERED (Id)
)
