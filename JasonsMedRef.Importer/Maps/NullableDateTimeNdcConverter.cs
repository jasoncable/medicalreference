using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace JasonsMedRef.Importer.Maps
{
    public class NullableDateTimeNdcConverter : ITypeConverter
    {
        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            if (value == null)
                return String.Empty;

            Type type = memberMapData.Member.MemberType.GetType();
            if (type == typeof(DateTime) || type == typeof(DateTime?))
                return ((DateTime)value).ToString("s");
            else
                return String.Empty;
        }

        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (String.IsNullOrWhiteSpace(text))
                return (DateTime?)null;

            return new DateTime(Convert.ToInt32(text.Substring(0,4)), Convert.ToInt32(text.Substring(4,2)), Convert.ToInt32(text.Substring(6,2)));
        }
    }
}
