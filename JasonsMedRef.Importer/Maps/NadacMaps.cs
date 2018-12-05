using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper.Configuration;

namespace JasonsMedRef.Importer.Maps
{
    public class NadacItemMap : ClassMap<NadacItem>
    {
        public NadacItemMap()
        {
            Map(m => m.NdcDescription).Name("NDC Description");
            Map(m => m.Ndc).Name("NDC");
            Map(m => m.NadacPerUnit).Name("NADAC_Per_Unit");
            Map(m => m.EffectiveDate).Name("Effective_Date").TypeConverter<NullableDateTimeConverter>();
            Map(m => m.PricingUnit).Name("Pricing_Unit");
            Map(m => m.PharmaType).Name("Pharmacy_Type_Indicator").TypeConverter<NullableEnumConverter>();
            Map(m => m.Otc).Name("OTC").TypeConverter<BooleanTypeConverter>();
            Map(m => m.ExplantionCode).Name("Explanation_Code");
            Map(m => m.ClassRateSetting).Name("Classification_for_Rate_Setting").TypeConverter<NullableEnumConverter>();
            Map(m => m.CorrespondingGenericNadacPerUnit).Name("Corresponding_Generic_Drug_NADAC_Per_Unit");
            Map(m => m.CorrespondingGenericEffectiveDate).Name("Corresponding_Generic_Drug_Effective_Date").TypeConverter<NullableDateTimeConverter>();
            Map(m => m.AsOfDate).Name("As of Date").TypeConverter<NullableDateTimeConverter>();
        }
    }
}
