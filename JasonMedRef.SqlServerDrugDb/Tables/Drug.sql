CREATE TABLE [dbo].[Drug]
(
    [Id] INT NOT NULL IDENTITY,
    [Ingredient] VARCHAR(MAX) NOT NULL,
    [DosageFormId] INT NOT NULL,
    [RouteOfAdminId] INT NOT NULL,
    [DrugTypeId] INT NOT NULL,
    [DrugScheduleId] INT NULL,
    [StartMarketingDate] DATETIME NULL,
    [EndMarketingDate] DATETIME NULL,
    [MarketingCategoryId] INT NOT NULL,
    CONSTRAINT [FK_Drug_MarketingCategory] FOREIGN KEY (MarketingCategoryId) REFERENCES MarketingCategory(Id),
    CONSTRAINT [FK_Drug_DosageForm] FOREIGN KEY (DosageFormId) REFERENCES DosageForm(Id),
    CONSTRAINT [FK_Drug_RouteOfAdministration] FOREIGN KEY (RouteOfAdminId) REFERENCES RouteOfAdministration(Id),
    CONSTRAINT [FK_Drug_DrugType] FOREIGN KEY (DrugTypeId) REFERENCES DrugType(Id),
    CONSTRAINT [FK_Drug_DrugSchedule] FOREIGN KEY (DrugScheduleId) REFERENCES DrugSchedule(Id),
    CONSTRAINT [PK_Drug] PRIMARY KEY CLUSTERED (Id)

)

GO

