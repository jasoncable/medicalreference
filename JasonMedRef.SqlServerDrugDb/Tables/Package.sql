CREATE TABLE [dbo].[Package]
(
    [Id] INT NOT NULL IDENTITY,
    [DrugId] INT NOT NULL,
    [Ndc] CHAR(11) NOT NULL,
    [NdcDashed] VARCHAR(15) NULL,
    [LabelerName] VARCHAR(500) NOT NULL,
    [Description] VARCHAR(MAX) NOT NULL,
    [StartMarketingDate] DATETIME NULL,
    [EndMarketingDate] DATETIME NULL,
    CONSTRAINT [FK_Package_Drug] FOREIGN KEY (DrugId) REFERENCES Drug(Id),
    CONSTRAINT [PK_Package] PRIMARY KEY CLUSTERED (Id)
)
