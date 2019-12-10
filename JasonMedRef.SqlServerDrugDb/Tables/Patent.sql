CREATE TABLE [dbo].[Patent]
(
    [Id] INT NOT NULL IDENTITY,
    [ApplicationId] INT NOT NULL,
    [Number] VARCHAR(MAX) NOT NULL,
    [Expiration] DATETIME NULL,
    CONSTRAINT [FK_Patent_Application] FOREIGN KEY (ApplicationId) REFERENCES [Application](Id),
    CONSTRAINT [PK_Patent] PRIMARY KEY CLUSTERED (Id)
)
