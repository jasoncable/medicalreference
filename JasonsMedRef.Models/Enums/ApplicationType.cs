using System;
using System.Collections.Generic;
using System.Text;

namespace JasonsMedRef.Models.Enums
{
    public enum ApplicationType
    {
        [EnumImportValue(new string[]{"N"})]
        New = 1,
        [EnumImportValue(new string[] {"A"})]
        Abbreviated = 1,
        [EnumImportValue(new string[] { "BIO" })] // fake
        Biologic = 3
    }
}
