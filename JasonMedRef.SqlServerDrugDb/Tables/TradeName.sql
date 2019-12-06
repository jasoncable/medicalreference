﻿CREATE TABLE [dbo].[TradeName]
(
    [Id] INT NOT NULL IDENTITY,
    [DrugId] INT NOT NULL,
    [Name] VARCHAR(MAX) NOT NULL,
    CONSTRAINT [FK_TradeName_Drug] FOREIGN KEY (DrugId) REFERENCES Drug(Id),
    CONSTRAINT [PK_TradeName] PRIMARY KEY CLUSTERED (Id)
)
