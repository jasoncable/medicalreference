using System;
using System.Collections.Generic;

namespace JasonsMedRef.SqlServerDrugDb
{
    public partial class Package
    {
        public int Id { get; set; }
        public int DrugId { get; set; }
        public string Ndc { get; set; }
        public string NdcDashed { get; set; }
        public string LabelerName { get; set; }
        public string Description { get; set; }
        public DateTime? StartMarketingDate { get; set; }
        public DateTime? EndMarketingDate { get; set; }

        public virtual Drug Drug { get; set; }
    }
}
