﻿CREATE TABLE [dbo].[DosageForm]
(
    [Id] INT NOT NULL IDENTITY,
    [Name] VARCHAR(100) NOT NULL,
    [NameExtended] VARCHAR(500) NULL,
    CONSTRAINT [PK_DosageForm] PRIMARY KEY CLUSTERED (Id)
)
