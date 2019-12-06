CREATE TABLE [dbo].[DrugPharmaClassXref]
(
    [Id] INT NOT NULL IDENTITY,
    [DrugId] INT NOT NULL,
    [PharmaClassId] INT NOT NULL,
    CONSTRAINT [FK_DrugPharmaClassXref_Drug] FOREIGN KEY (DrugId) REFERENCES Drug(Id),
    CONSTRAINT [FK_DrugPharmaClassXref_PharmaClass] FOREIGN KEY (PharmaClassId) REFERENCES PharmaClass(Id),
    CONSTRAINT [PK_DrugPharmaClassXref] PRIMARY KEY CLUSTERED (Id)
)
