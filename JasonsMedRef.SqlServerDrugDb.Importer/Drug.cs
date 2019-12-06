using System;
using System.Collections.Generic;

namespace JasonsMedRef.SqlServerDrugDb
{
    public partial class Drug
    {
        public Drug()
        {
            Application = new HashSet<Application>();
            DrugPharmaClassXref = new HashSet<DrugPharmaClassXref>();
            Package = new HashSet<Package>();
            Strength = new HashSet<Strength>();
            TradeName = new HashSet<TradeName>();
        }

        public int Id { get; set; }
        public string Ingredient { get; set; }
        public int DosageFormId { get; set; }
        public int RouteOfAdminId { get; set; }
        public int DrugTypeId { get; set; }
        public int? DrugScheduleId { get; set; }
        public DateTime? StartMarketingDate { get; set; }
        public DateTime? EndMarketingDate { get; set; }
        public int MarketingCategoryId { get; set; }

        public virtual DosageForm DosageForm { get; set; }
        public virtual DrugSchedule DrugSchedule { get; set; }
        public virtual DrugType DrugType { get; set; }
        public virtual MarketingCategory MarketingCategory { get; set; }
        public virtual RouteOfAdministration RouteOfAdmin { get; set; }
        public virtual ICollection<Application> Application { get; set; }
        public virtual ICollection<DrugPharmaClassXref> DrugPharmaClassXref { get; set; }
        public virtual ICollection<Package> Package { get; set; }
        public virtual ICollection<Strength> Strength { get; set; }
        public virtual ICollection<TradeName> TradeName { get; set; }
    }
}
