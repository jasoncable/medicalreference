using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper.Configuration;

namespace JasonsMedRef.Importer.Maps
{
    public class OrangeBook_ProductMap : ClassMap<OrangeBook_Product>
    {
        public OrangeBook_ProductMap()
        {
            Map(m => m.Ingredient).Name("Ingredient");
            Map(m => m.DfRoute).Name("DF;Route");  // dosage form;route of administration
            Map(m => m.TradeName).Name("Trade_Name");
            Map(m => m.Applicant).Name("Applicant");
            Map(m => m.Strength).Name("Strength");
            Map(m => m.ApplicationType).Name("Appl_Type").TypeConverter<NullableEnumConverter>();
            Map(m => m.ApplicationTypeText).Name("Appl_Type");
            Map(m => m.ApplicationNumber).Name("Appl_No");
            Map(m => m.ProductNumber).Name("Product_No");
            Map(m => m.TeCode).Name("TE_Code");
            Map(m => m.TeDecoded).Name("TE_Code").TypeConverter<NullableEnumConverter>();
            Map(m => m.ApprovalDate).Name("Approval_Date").TypeConverter<NullableDateTimeConverter>();
            Map(m => m.Rld).Name("RLD").TypeConverter<BooleanTypeConverter>();
            Map(m => m.Rs).Name("RS").TypeConverter<BooleanTypeConverter>();
            Map(m => m.Type).Name("Type").TypeConverter<NullableEnumConverter>();
            Map(m => m.TypeText).Name("Type");
            Map(m => m.ApplicantFullName).Name("Applicant_Full_Name");
        }
    }

    public class OrangeBook_PatentMap : ClassMap<OrangeBook_Patent>
    {
        public OrangeBook_PatentMap()
        {
            Map(m => m.ApplicationType).Name("Appl_Type").TypeConverter<NullableEnumConverter>();
            Map(m => m.ApplicationTypeText).Name("Appl_Type");
            Map(m => m.ApplicationNumber).Name("Appl_No");
            Map(m => m.ProductNumber).Name("Product_No");
            Map(m => m.PatentNumber).Name("Patent_No");
            Map(m => m.PatentExpireDate).Name("Patent_Expire_Date_Text");
            Map(m => m.DrugSubstanceFlag).Name("Drug_Substance_Flag").TypeConverter<BooleanTypeConverter>();
            Map(m => m.DrugProductFlag).Name("Drug_Product_Flag").TypeConverter<BooleanTypeConverter>();
            Map(m => m.PatentUseCode).Name("Patent_Use_Code");
            Map(m => m.DelistFlag).Name("Delist_Flag").TypeConverter<BooleanTypeConverter>();
            Map(m => m.SubmissionDate).Name("Submission_Date");
        }
    }

    public class OrangeBook_ExclusivityMap : ClassMap<OrangeBook_Exclusivity>
    {
        public OrangeBook_ExclusivityMap()
        {
            Map(m => m.ApplicationType).Name("Appl_Type").TypeConverter<NullableEnumConverter>();
            Map(m => m.ApplicationTypeText).Name("Appl_Type");
            Map(m => m.ApplicationNumber).Name("Appl_No");
            Map(m => m.ProductNumber).Name("Product_No");
            Map(m => m.ExclusivityCode).Name("Exclusivity_Code");
            Map(m => m.ExclusivityDate).Name("Exclusivity_Date");
        }
    }
}
