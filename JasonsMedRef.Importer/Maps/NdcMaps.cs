using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper.Configuration;

namespace JasonsMedRef.Importer.Maps
{
    public class Ndc_PackageMap : ClassMap<Ndc_Package>
    {
        public Ndc_PackageMap()
        {
            Map(m => m.ProductId).Name("PRODUCTID");
            Map(m => m.ProductNdc).Name("PRODUCTNDC");
            Map(m => m.NdcPackageCode).Name("NDCPACKAGECODE");
            Map(m => m.PackageDescription).Name("PACKAGEDESCRIPTION");
            Map(m => m.StartMarketingDate).Name("STARTMARKETINGDATE").TypeConverter<NullableDateTimeNdcConverter>();
            Map(m => m.EndMarketingDate).Name("ENDMARKETINGDATE").TypeConverter<NullableDateTimeNdcConverter>();
        }
    }

    public class Ndc_ProductMap : ClassMap<Ndc_Product>
    {
        public Ndc_ProductMap()
        {
            Map(m => m.ProductId).Name("PRODUCTID");
            Map(m => m.ProductNdc).Name("PRODUCTNDC");
            Map(m => m.ProductTypeName).Name("PRODUCTTYPENAME").TypeConverter<NullableEnumConverter>();
            Map(m => m.ProductTypeNameText).Name("PRODUCTTYPENAME");
            Map(m => m.ProprietaryName).Name("PROPRIETARYNAME");
            Map(m => m.ProprietaryNameSuffix).Name("PROPRIETARYNAMESUFFIX");
            Map(m => m.NonProprietaryName).Name("NONPROPRIETARYNAME");
            Map(m => m.DosageFormName).Name("DOSAGEFORMNAME").TypeConverter<NullableEnumConverter>();
            Map(m => m.DosageFormNameText).Name("DOSAGEFORMNAME");
            Map(m => m.RouteName).Name("ROUTENAME").TypeConverter<NullableEnumConverter>();
            Map(m => m.RouteNameText).Name("ROUTENAME");
            Map(m => m.StartMarketingDate).Name("STARTMARKETINGDATE").TypeConverter<NullableDateTimeConverter>();
            Map(m => m.EndMarketingDate).Name("ENDMARKETINGDATE").TypeConverter<NullableDateTimeConverter>();
            Map(m => m.MarketingCategoryName).Name("MARKETINGCATEGORYNAME").TypeConverter<NullableEnumConverter>();
            Map(m => m.MarketingCategoryNameText).Name("MARKETINGCATEGORYNAME");
            Map(m => m.ApplicationNumber).Name("APPLICATIONNUMBER");
            Map(m => m.LabelerName).Name("LABELERNAME");
            Map(m => m.SubstanceName).Name("SUBSTANCENAME");
            Map(m => m.ActiveNumeratorStrength).Name("ACTIVE_NUMERATOR_STRENGTH");
            Map(m => m.ActiveIngredientUnit).Name("ACTIVE_INGRED_UNIT");
            Map(m => m.PharmaClasses).Name("PHARM_CLASSES");
            Map(m => m.DeaSchedule).Name("DEASCHEDULE").TypeConverter<NullableEnumConverter>();
            Map(m => m.DeaScheduleText).Name("DEASCHEDULE");
            Map(m => m.ExcludeFlag).Name("NDC_EXCLUDE_FLAG").TypeConverter<BooleanTypeConverter>();
            Map(m => m.ListingRecordCertifiedThrough).Name("LISTING_RECORD_CERTIFIED_THROUGH").TypeConverter<NullableDateTimeConverter>();
        }
    }
}
