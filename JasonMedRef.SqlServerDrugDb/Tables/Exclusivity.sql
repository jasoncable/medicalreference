CREATE TABLE [dbo].[Exclusivity]
(
    [Id] INT NOT NULL IDENTITY,
    [ApplicationId] INT NOT NULL,
    [Code] VARCHAR(MAX) NOT NULL,
    [Expiration] DATETIME NULL,
    CONSTRAINT [FK_Exclusivity_Application] FOREIGN KEY ([ApplicationId]) REFERENCES [Application](Id),
    CONSTRAINT [PK_Exclusivity] PRIMARY KEY CLUSTERED (Id)
)
