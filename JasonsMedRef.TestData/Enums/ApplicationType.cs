using System;

namespace Jaxosoft.TestData
{
    public enum ApplicationType
    {
        [EnumImportValue(new string[]{"N"})]
        New = 1,
        [EnumImportValue(new string[] {"A"})]
        Abbreviated = 1,
        Biologic = 3
    }
}
