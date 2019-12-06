CREATE TABLE [dbo].[DrugSchedule]
(
    [Id] INT NOT NULL IDENTITY,
    [Name] VARCHAR(4) NOT NULL,
    [NameAsNumber] INT NOT NULL,
    CONSTRAINT [PK_DrugSchedule] PRIMARY KEY CLUSTERED (Id)
)
