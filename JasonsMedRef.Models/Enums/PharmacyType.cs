using System;
using System.Collections.Generic;
using System.Text;

namespace JasonsMedRef.Models.Enums
{
    public enum PharmacyType
    {
        [EnumImportValue(new string[] { "C/I"})]
        ChainAndIndependentPharmacies
    }
}
