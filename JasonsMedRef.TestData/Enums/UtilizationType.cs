using System;

namespace Jaxosoft.TestData
{
    public enum UtilizationType
    {
        [EnumImportValue(new string[] {"FFSU"})]
        FeeForService,
        [EnumImportValue(new string[] { "MCOU" })]
        ManagedCareOrganization
    }
}
