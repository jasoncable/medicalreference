using System;
using System.Collections.Generic;
using System.Text;
using JasonsMedRef.Models.Enums;

namespace JasonsMedRef.Models
{
    public class Nadac
    {
        public static readonly string IndexName = "jmr_nadac";

        public Guid Id { get; set; }
        public Guid DrugId { get; set; }
        public Guid PackageId { get; set; }
        public string Ndc { get; set; }
        public float? NadacPerUnit { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public string PricingUnit { get; set; }
        public PharmacyType? PharmaType { get; set; }
        public bool? Otc { get; set; }
        public RateSetting? ClassRateSetting { get; set; }
        public float? CorrespondingGenericNadacPerUnit { get; set; }
        public DateTime? CorrespondingGenericEffectiveDate { get; set; }
        public DateTime? AsOfDate { get; set; }
    }
}
