using System;

namespace Jaxosoft.TestData
{
    public enum DrugType
    {
        [EnumImportValue(new string[]{"DISCN"})]
        Discontinued,
        [EnumImportValue(new string[]{"RX", "HUMAN PRESCRIPTION DRUG" })]
        Prescription,
        [EnumImportValue(new string[] {"OTC", "HUMAN OTC DRUG" })]
        OverTheCounter,
        [EnumImportValue(new string[] { "CELLULAR THERAPY" })]
        CellularTherapy,
        [EnumImportValue(new string[] { "NON-STANDARDIZED ALLERGENIC" })]
        NonStandardizedAllergenic,
        [EnumImportValue(new string[] { "PLASMA DERIVATIVE" })]
        PlasmaDerivative,
        [EnumImportValue(new string[] { "STANDARDIZED ALLERGENIC" })]
        StandardizedAllergenic,
        [EnumImportValue(new string[] { "VACCINE" })]
        Vaccine
    }
}
