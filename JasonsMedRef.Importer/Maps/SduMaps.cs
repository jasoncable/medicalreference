using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper.Configuration;

namespace JasonsMedRef.Importer.Maps
{
    public class SduMap : ClassMap<SduObject>
    {
        public SduMap()
        {
            Map(m => m.UtilizationType).Name("Utilization Type").TypeConverter<NullableEnumConverter>();
            Map(m => m.State).Name("State").TypeConverter<NullableEnumConverter>();
            Map(m => m.NdcPart1).Name("Labeler Code");
            Map(m => m.NdcPart2).Name("Product Code");
            Map(m => m.NdcPart3).Name("Package Size");
            Map(m => m.Year).Name("Year");
            Map(m => m.Quarter).Name("Quarter");
            Map(m => m.ProductName).Name("Product Name");
            Map(m => m.SuppressionUsed).Name("Suppression Used");
            Map(m => m.UnitsReimbursed).Name("Units Reimbursed");
            Map(m => m.NumberOfScripts).Name("Number of Prescriptions");
            Map(m => m.TotalAmountReimbursed).Name("Total Amount Reimbursed");
            Map(m => m.MedicaidAmountReimbursed).Name("Medicaid Amount Reimbursed");
            Map(m => m.NonMedicaidAmountReimbursed).Name("Non Medicaid Amount Reimbursed");
            Map(m => m.Latitude).Name("Latitude");
            Map(m => m.Longitude).Name("Longitude");
        }
    }
}
