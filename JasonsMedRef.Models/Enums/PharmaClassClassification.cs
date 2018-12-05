using System;
using System.Collections.Generic;
using System.Text;

namespace JasonsMedRef.Models.Enums
{
    public enum PharmaClassClassification
    {
        [EnumImportValue( new string[] { "[Chemical/Ingredient]" })]
        ChemicalIngredient,
        [EnumImportValue(new string[] { "[Disease/Finding]" })]
        DiseaseFinding,
        [EnumImportValue(new string[] { "[DOSE FORM]" })]
        DoseForm,
        [EnumImportValue(new string[] { "[EPC]" })]
        EPC,
        [EnumImportValue(new string[] { "[MoA]" })]
        MoA,
        [EnumImportValue(new string[] { "[PE]" })]
        PE,
        [EnumImportValue(new string[] { "[PK]" })]
        PK,
        [EnumImportValue(new string[] { "[Preparations]" })]
        Preparations,
        [EnumImportValue(new string[] { "[TC]" })]
        TC,
        [EnumImportValue(new string[] { "[VA Product]" })]
        VAproduct
    }
}
