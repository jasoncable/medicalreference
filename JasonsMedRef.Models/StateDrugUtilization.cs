using System;
using System.Collections.Generic;
using System.Text;
using JasonsMedRef.Models.Enums;
using Nest;

namespace JasonsMedRef.Models
{
    public class StateDrugUtilization
    {
        public static readonly string IndexName = "jmr_statedrugutilization";

        public Guid Id { get; set; }
        public UtilizationType? UtilizationType { get; set; }
        public State? State { get; set; }
        public Guid DrugId { get; set; }
        public Guid PackageId { get; set; }
        public DateTime ReportDate { get; set; }
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
