using JasonsMedRef.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace JasonsMedRef.Models
{
    public class Package
    {
        public static readonly string IndexName = "jmr_package";

        public Guid Id { get; set; }
        public Guid DrugId { get; set; }
        public string LabelerName { get; set; }
        public string ApplicationNumber { get; set; }
        public string Ndc { get; set; }
        public string Description { get; set; }
        public MarketingCategory? MarketingCategory { get; set; }
        public string MarketingCategoryText { get; set; }
        public DateTime? StartMarketingDate { get; set; }
        public DateTime? EndMarketingDate { get; set; }
    }
}
