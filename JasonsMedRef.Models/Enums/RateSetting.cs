using System;
using System.Collections.Generic;
using System.Text;

namespace JasonsMedRef.Models.Enums
{
    public enum RateSetting
    {
        [EnumImportValue(new string[] { "G" })]
        Generic,
        [EnumImportValue(new string[] { "B" })]
        Brand,
        [EnumImportValue(new string[] { "B-ANDA" })]
        BrandFromAbbreviated
    }
}
