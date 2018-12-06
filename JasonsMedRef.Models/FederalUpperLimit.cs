using System;
using System.Collections.Generic;
using System.Text;

namespace JasonsMedRef.Models
{
    public class FederalUpperLimit
    {
        public static readonly string IndexName = "jmr_ful";

        public Guid Id { get; set; }
        public Guid DrugId { get; set; }
        public Guid PackageId { get; set; }
        public string Ndc { get; set; }
        public string UnitType { get; set; }
        public double? PackageSize { get; set; }
        public double? AvgMfgPrice { get; set; }
        public double? Ful { get; set; }
        public DateTime ReportingDate { get; set; }
    }
}
