CREATE TABLE [dbo].[MarketingCategory]
(
    [Id] INT NOT NULL IDENTITY,
    [Name] VARCHAR(100) NOT NULL,
    [NameExtended] VARCHAR(500) NULL,
    CONSTRAINT [PK_MarketingCategory] PRIMARY KEY CLUSTERED (Id)
)
