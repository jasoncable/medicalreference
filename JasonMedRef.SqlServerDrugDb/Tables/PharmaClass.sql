CREATE TABLE [dbo].[PharmaClass]
(
    [Id] INT NOT NULL IDENTITY,
    [Name] VARCHAR(MAX) NOT NULL,
    [PharmaClassClassId] INT NULL, 
    CONSTRAINT [FK_PharmaClass_PharmaClassClass] FOREIGN KEY (PharmaClassClassId) REFERENCES PharmaClassClass(Id),
    CONSTRAINT [PK_PharmaClass] PRIMARY KEY CLUSTERED (Id)
)
