using System;
using System.Collections.Generic;

namespace JasonsMedRef.SqlServerDrugDb
{
    public partial class Application
    {
        public Application()
        {
            Exclusivity = new HashSet<Exclusivity>();
            Patent = new HashSet<Patent>();
        }

        public int Id { get; set; }
        public string ApplicationNumber { get; set; }
        public string ProductNumber { get; set; }
        public int DrugId { get; set; }
        public int ApplicationTypeId { get; set; }
        public string Strength { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string Applicant { get; set; }
        public string ApplicantFullName { get; set; }
        public int TherapeuticEquivalenceCodeId { get; set; }
        public bool ReferenceListedDrug { get; set; }
        public bool ReferenceStandard { get; set; }

        public virtual ApplicationType ApplicationType { get; set; }
        public virtual Drug Drug { get; set; }
        public virtual TherapeuticEquivalenceCode TherapeuticEquivalenceCode { get; set; }
        public virtual ICollection<Exclusivity> Exclusivity { get; set; }
        public virtual ICollection<Patent> Patent { get; set; }
    }
}
