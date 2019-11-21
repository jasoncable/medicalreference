using System;

namespace Jaxosoft.TestData
{
    /// <summary>
    /// SOURCE: https://www.fda.gov/drugs/development-approval-process-drugs/orange-book-preface#tecode (11/13/2019)
    /// TE Codes per the Orange Book
    /// Lower numbers indicate "better" equivalence or those equivalencies having sufficient
    /// documentation to warrant a "good" rating.  Generally speaking, most drugs should fall in the "A" range.
    /// "AA" drugs will generally be reference listed drugs unless the original manufacturer
    /// no longer produces the drug, then another version may be given an AA, which assumes
    /// that the new manufacturer is using the extact same method of production and ingredients in the
    /// same ratios.
    /// </summary>
    public enum TherapeuticEquivalence
    {
        NotSpecified = 0,

        [EnumImportValue(new string[] { "AA" })]
        EquivalentInOriginalForm = 1,
        [EnumImportValue(new string[] { "AN" })]
        EquivalentAsAerosol = 2,
        [EnumImportValue(new string[] { "AO" })]
        EquivalentAsInjectableOil = 3,
        [EnumImportValue(new string[] { "AP" })]
        EquivalentAsInjectableAqueous = 4,
        [EnumImportValue(new string[] { "AT" })]
        EquivalentAsTopical = 5,

        [EnumImportValue(new string[] { "AB", "AB1", "AB2", "AB3", "AB4", "AB5" })]
        MeetsEquivalence = 10,

        [EnumImportValue(new string[] { "B" })]
        NotEquivalent = 20,
        [EnumImportValue(new string[] { "BC" })]
        NotEquivalentAsExtendedRelease = 21,
        [EnumImportValue(new string[] { "BD" })]
        NotEquivalentWithDocumentation = 22,
        [EnumImportValue(new string[] { "BE" })]
        NotEquivalentAsDelayedRelease = 23,
        [EnumImportValue(new string[] { "BN" })]
        NotEquivalentAsAerosol = 24,
        [EnumImportValue(new string[] { "BR" })]
        NotEquivalentAsSuppository = 25,
        [EnumImportValue(new string[] { "BT" })]
        NotEquivalentAsTopical = 26,

        [EnumImportValue(new string[] { "BS" })]
        DrugStandardDeficiencies = 30,

        [EnumImportValue(new string[] { "BP" })]
        PotentialProblemsAbsentData = 40,

        [EnumImportValue(new string[] { "BX" })]
        InsufficientEvidenceExists = 50,

        [EnumImportValue(new string[] { "B*" })]
        UnderReviewOrInvestigation = 60
    }
}
