using System;
using System.Collections.Generic;
using System.Text;

namespace JasonsMedRef.Models.Enums
{
    public enum UtilizationType
    {
        [EnumImportValue(new string[] {"FFSU"})]
        FeeForService,
        [EnumImportValue(new string[] { "MCOU" })]
        ManagedCareOrganization
    }
}
