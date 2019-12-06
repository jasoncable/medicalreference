CREATE TABLE [dbo].[Application]
(
    [Id] INT NOT NULL IDENTITY,
    [ApplicationNumber] VARCHAR(20) NOT NULL,
    [ProductNumber] VARCHAR(10) NOT NULL,
    [DrugId] INT NOT NULL,
    [ApplicationTypeId] INT NOT NULL,
    [Strength] VARCHAR(MAX) NULL,
    [ApprovalDate] DATETIME NULL,
    [Applicant] VARCHAR(500) NOT NULL,
    [ApplicantFullName] VARCHAR(MAX) NULL,
    [TherapeuticEquivalenceCodeId] INT NOT NULL,
    [ReferenceListedDrug] BIT NOT NULL DEFAULT 0,
    [ReferenceStandard] BIT NOT NULL DEFAULT 0,
    CONSTRAINT [FK_Application_Drug] FOREIGN KEY (DrugId) REFERENCES Drug(Id),
    CONSTRAINT [FK_Application_ApplicationType] FOREIGN KEY (ApplicationTypeId) REFERENCES [ApplicationType]([Id]),
    CONSTRAINT [FK_Application_TECode] FOREIGN KEY ([TherapeuticEquivalenceCodeId]) REFERENCES [TherapeuticEquivalenceCode]([Id]),
    CONSTRAINT [PK_Application] PRIMARY KEY CLUSTERED (Id)
)
