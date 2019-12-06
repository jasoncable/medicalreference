CREATE FULLTEXT INDEX
    ON [dbo].Drug
        (Ingredient)
    KEY INDEX PK_Drug
    ON DrugCatalog
    WITH CHANGE_TRACKING AUTO
