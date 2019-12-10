CREATE TABLE [dbo].[Package]
(
    [Id] INT NOT NULL IDENTITY,
    [DrugId] INT NOT NULL,
    [Ndc] VARCHAR(100) NOT NULL,
    [NdcDashed] VARCHAR(200) NULL,
    [LabelerName] VARCHAR(MAX) NOT NULL,
    [Description] VARCHAR(MAX) NOT NULL,
    [StartMarketingDate] DATETIME NULL,
    [EndMarketingDate] DATETIME NULL,
    CONSTRAINT [FK_Package_Drug] FOREIGN KEY (DrugId) REFERENCES Drug(Id),
    CONSTRAINT [PK_Package] PRIMARY KEY CLUSTERED (Id)
)
