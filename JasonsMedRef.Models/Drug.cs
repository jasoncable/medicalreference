using System;
using System.Collections.Generic;
using System.Text;
using JasonsMedRef.Models.Enums;

namespace JasonsMedRef.Models
{
    public class Drug
    {
        public static readonly string IndexName = "jmr_drug";

        public Guid Id { get; set; }
        public string Ingredient { get; set; }
        public DosageForm? DosageForm { get; set; }
        public string DosageFormText { get; set; }
        public RouteOfAdministration? RouteOfAdmin { get; set; }
        public string RouteOfAdminText { get; set; }
        public DrugType? DrugType { get; set; }
        public DrugSchedule? Schedule { get; set; }
        public DateTime? StartMarketingDate { get; set; }
        public DateTime? EndMarketingDate { get; set; }
        public MarketingCategory? MarketingCategory { get; set; }

        public List<string> Strengths { get; set; } = new List<string>();
        public List<string> TradeNames { get; set; } = new List<string>();
        public List<Guid> PharmaClasses { get; set; } = new List<Guid>();
        public List<string> PharmaClassesText { get; set; } = new List<string>();
    }
}
