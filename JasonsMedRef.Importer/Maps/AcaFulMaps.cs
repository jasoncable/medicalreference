using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper.Configuration;
using JasonsMedRef.Models.Enums;

namespace JasonsMedRef.Importer.Maps
{
    public class AcaFulMap : ClassMap<AcaFulObject>
    {
        public AcaFulMap()
        {
            Map(m => m.ProductGroup).Name("Product Group");
            Map(m => m.Ingredient).Name("Ingredient");
            Map(m => m.Strength).Name("Strength");
            Map(m => m.Dosage).Name("Dosage").TypeConverter<NullableEnumConverter>();
            Map(m => m.Route).Name("Route").TypeConverter<NullableEnumConverter>();
            Map(m => m.MdrUnitType).Name("MDR Unit Type");
            Map(m => m.WeightedAverageAmps).Name("Weighted Average AMPs");
            Map(m => m.AcaFedUpperLimit).Name("ACA FUL");
            Map(m => m.PackageSize).Name("Package Size");
            Map(m => m.Ndc).Name("NDC");
            Map(m => m.ARated).Name("A-Rated").TypeConverter<BooleanTypeConverter>();
            Map(m => m.MultiplerOfAvgOfAmp).Name("Multiplier Greater Than 175 Percent of Weighted Avg of AMPs").TypeConverter<BooleanTypeConverter>();
            Map(m => m.Year).Name("Year");
            Map(m => m.Month).Name("Month");
        }
    }
}
