CREATE FULLTEXT INDEX
    ON [dbo].TradeName
        ([Name])
    KEY INDEX PK_TradeName
    ON DrugCatalog
    WITH CHANGE_TRACKING AUTO
