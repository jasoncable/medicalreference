using System;

namespace Jaxosoft.TestData
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
