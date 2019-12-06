using System;
using System.Collections.Generic;
using System.Text;
using JasonsMedRef.Models.Enums;

namespace JasonsMedRef.Models
{
    public class Application
    {
        public static readonly string IndexName = "jmr_application";

        public Guid Id { get; set; }
        public Guid DrugId { get; set; }
        public ApplicationType? ApplicationType { get; set; }
        public string ApplicationNumber { get; set; }
        public string ProductNumber { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string Applicant { get; set; }
        public string ApplicantFullName { get; set; }
        public string TeCode { get; set; }
        public TherapeuticEquivalence? TeDecoded { get; set; }
        public bool? ReferenceListedDrug { get; set; }
        public bool? ReferenceStandard { get; set; }
        public string Strength { get; set; }
    }
}
