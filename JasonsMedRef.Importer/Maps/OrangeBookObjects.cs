using System;
using System.Collections.Generic;
using System.Text;
using JasonsMedRef.Models.Enums;

namespace JasonsMedRef.Importer.Maps
{
    public class OrangeBook_Exclusivity
    {
        public ApplicationType? ApplicationType { get; set; }
        public string ApplicationTypeText { get; set; }
        public string ApplicationNumber { get; set; }
        public string ProductNumber { get; set; }
        public string ExclusivityCode { get; set; }
        public DateTime ExclusivityDate { get; set; }
    }

    public class OrangeBook_Patent
    {
        public ApplicationType? ApplicationType { get; set; }
        public string ApplicationTypeText { get; set; }
        public string ApplicationNumber { get; set; }
        public string ProductNumber { get; set; }
        public string PatentNumber { get; set; }
        public DateTime PatentExpireDate { get; set; }
        public bool DrugSubstanceFlag { get; set; }
        public bool DrugProductFlag { get; set; }
        public string PatentUseCode { get; set; }
        public bool DelistFlag { get; set; }
        public DateTime? SubmissionDate { get; set; }
    }

    public class OrangeBook_Product
    {
        public string Ingredient { get; set; }
        public string DfRoute { get; set; }
        public string TradeName { get; set; }
        public string Applicant { get; set; }
        public string Strength { get; set; }
        public ApplicationType? ApplicationType { get; set; }
        public string ApplicationTypeText { get; set; }
        public string ApplicationNumber { get; set; }
        public string ProductNumber { get; set; }
        public string TeCode { get; set; }
        public TherapeuticEquivalence? TeDecoded { get; set; }
        public DateTime? ApprovalDate { get; set; } // Approved Prior to Jan 1, 1982
        public bool Rld { get; set; }
        public bool Rs { get; set; }
        public DrugType? Type { get; set; }
        public string TypeText { get; set; }
        public string ApplicantFullName { get; set; }
    }
}
