CREATE TABLE [dbo].[TherapeuticEquivalenceCode]
(
    [Id] INT NOT NULL IDENTITY,
    [Code] VARCHAR(10) NOT NULL,
    [Name] VARCHAR(100) NOT NULL,
    [EquivalenceScore] INT NOT NULL,
    CONSTRAINT [PK_TherapeuticEquivalenceCode] PRIMARY KEY CLUSTERED (Id)
)
