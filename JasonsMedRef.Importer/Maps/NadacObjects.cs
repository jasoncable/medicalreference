using System;
using System.Collections.Generic;
using System.Text;
using JasonsMedRef.Models.Enums;

namespace JasonsMedRef.Importer.Maps
{
    public class NadacItem
    {
        public string NdcDescription { get; set; }
        public string Ndc { get; set; }
        public float? NadacPerUnit { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public string PricingUnit { get; set; }
        public PharmacyType? PharmaType { get; set; }
        public bool? Otc { get; set; }
        public string ExplantionCode { get; set; }
        public RateSetting? ClassRateSetting { get; set; }
        public float? CorrespondingGenericNadacPerUnit { get; set; }
        public DateTime? CorrespondingGenericEffectiveDate { get; set; }
        public DateTime? AsOfDate { get; set; }
    }
}
