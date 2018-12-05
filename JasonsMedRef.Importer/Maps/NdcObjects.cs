using System;
using System.Collections.Generic;
using System.Text;
using JasonsMedRef.Models.Enums;

namespace JasonsMedRef.Importer.Maps
{
    public class Ndc_Package
    {
        public string ProductId { get; set; }
        public string ProductNdc { get; set; }
        public string NdcPackageCode { get; set; }
        public string PackageDescription { get; set; }
        public DateTime? StartMarketingDate { get; set; }
        public DateTime? EndMarketingDate { get; set; }
    }

    public class Ndc_Product
    {
        public string ProductId { get; set; }
        public string ProductNdc { get; set; }
        public DrugType? ProductTypeName { get; set; }
        public string ProductTypeNameText { get; set; }
        public string ProprietaryName { get; set; }
        public string ProprietaryNameSuffix { get; set; }
        public string NonProprietaryName { get; set; }
        public DosageForm? DosageFormName { get; set; }
        public string DosageFormNameText { get; set; }
        public RouteOfAdministration? RouteName { get; set; }
        public string RouteNameText { get; set; }
        public DateTime? StartMarketingDate { get; set; }
        public DateTime? EndMarketingDate { get; set; }
        public MarketingCategory? MarketingCategoryName { get; set; }
        public string MarketingCategoryNameText { get; set; }
        public string ApplicationNumber { get; set; }
        public string LabelerName { get; set; }
        public string SubstanceName { get; set; }
        public string ActiveNumeratorStrength { get; set; }
        public string ActiveIngredientUnit { get; set; }
        public string PharmaClasses { get; set; }
        public DrugSchedule? DeaSchedule { get; set; }
        public string DeaScheduleText { get; set; }
        public bool? ExcludeFlag { get; set; }
        public DateTime? ListingRecordCertifiedThrough { get; set; }
    }

    public class Ndc_ProductForPackageInfo
    {
        public string LabelerName { get; set; }
        public string ApplicationNumber { get; set; }
    }
}
