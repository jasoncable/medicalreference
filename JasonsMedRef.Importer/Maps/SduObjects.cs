using System;
using System.Collections.Generic;
using System.Text;
using JasonsMedRef.Models.Enums;

namespace JasonsMedRef.Importer.Maps
{
    public class SduObject
    {
        public UtilizationType? UtilizationType { get; set; }
        public State? State { get; set; }
        public string NdcPart1 { get; set; }
        public string NdcPart2 { get; set; }
        public string NdcPart3 { get; set; }
        public string Year { get; set; }
        public string Quarter { get; set; }
        public string ProductName { get; set; }
        public bool? SuppressionUsed { get; set; }
        public float? UnitsReimbursed { get; set; }
        public float? NumberOfScripts { get; set; }
        public float? TotalAmountReimbursed { get; set; }
        public float? MedicaidAmountReimbursed { get; set; }
        public float? NonMedicaidAmountReimbursed { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
    }
}
