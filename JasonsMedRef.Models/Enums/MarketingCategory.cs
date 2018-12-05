using System;
using System.Collections.Generic;
using System.Text;

namespace JasonsMedRef.Models.Enums
{
    public enum MarketingCategory
    {
        [EnumImportValue(new string[] { "ANADA" })]
        ANADA,
        [EnumImportValue(new string[] { "ANDA" })]
        ANDA,
        [EnumImportValue(new string[] { "Approved Drug Product Manufactured Under Contract" })]
        ApprovedDrugProductManufacturedUnderContract,
        [EnumImportValue(new string[] { "BLA" })]
        BLA,
        [EnumImportValue(new string[] { "Bulk ingredient" })]
        BulkIngredient,
        [EnumImportValue(new string[] { "Bulk Ingredient For Animal Drug Compounding" })]
        BulkIngredientForAnimalDrugCompounding,
        [EnumImportValue(new string[] { "Bulk Ingredient For Human Prescription Compounding" })]
        BulkIngredientForHumanPrescriptionCompounding,
        [EnumImportValue(new string[] { "Conditional NADA" })]
        ConditionalNADA,
        [EnumImportValue(new string[] { "Cosmetic" })]
        Cosmetic,
        [EnumImportValue(new string[] { "Dietary Supplement" })]
        DietarySupplement,
        [EnumImportValue(new string[] { "Drug for Further Processing" })]
        DrugForFurtherProcessing,
        [EnumImportValue(new string[] { "Exempt device" })]
        ExemptDevice,
        [EnumImportValue(new string[] { "Export only" })]
        ExportOnly,
        [EnumImportValue(new string[] { "Humanitarian Device Exemption" })]
        HumanitarianDeviceExemption,
        [EnumImportValue(new string[] { "IND" })]
        IND,
        [EnumImportValue(new string[] { "Medical Food" })]
        MedicalFood,
        [EnumImportValue(new string[] { "Legally Marketed Unapproved New Animal Drugs for Minor Species" })]
        LegallyMarketedUnapprovedNewAnimalDrugsForMinorSpecies,
        [EnumImportValue(new string[] { "NADA" })]
        NADA,
        [EnumImportValue(new string[] { "NDA" })]
        NDA,
        [EnumImportValue(new string[] { "NDA authorized generic" })]
        NDAAuthorizedGeneric,
        [EnumImportValue(new string[] { "OTC Monograph Drug Product Manufactured Under Contract" })]
        OTCMonographDrugProductManufacturedUnderContract,
        [EnumImportValue(new string[] { "OTC monograph final" })]
        OTCMonographFinal,
        [EnumImportValue(new string[] { "OTC monograph not final" })]
        OTCMonographNotFinal,
        [EnumImportValue(new string[] { "Premarket Application" })]
        PremarketApplication,
        [EnumImportValue(new string[] { "Premarket Notification" })]
        PremarketNotification,
        [EnumImportValue(new string[] { "Unapproved drug for use in drug shortage" })]
        UnapprovedDrugForUseInDrugShortage,
        [EnumImportValue(new string[] { "Unapproved drug other" })]
        UnapprovedDrugOther,
        [EnumImportValue(new string[] { "Unapproved Drug Product Manufactured Under Contract" })]
        UnapprovedDrugProductManfacturedUnderContract,
        [EnumImportValue(new string[] { "Unapproved homeopathic" })]
        UnapprovedHomeopathic,
        [EnumImportValue(new string[] { "Unapproved medical gas" })]
        UnapprovedMedicalGas
    }
}
