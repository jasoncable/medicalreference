CREATE TABLE [dbo].[RouteOfAdministration]
(
    [Id] INT NOT NULL IDENTITY,
    [Name] VARCHAR(100) NOT NULL,
    [NameExtended] VARCHAR(500) NULL,
    CONSTRAINT [PK_RouteOfAdministration] PRIMARY KEY CLUSTERED (Id)
)
