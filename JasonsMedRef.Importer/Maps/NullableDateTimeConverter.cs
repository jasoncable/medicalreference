using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace JasonsMedRef.Importer.Maps
{
    public class NullableDateTimeConverter : ITypeConverter
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

            if (text == "Approved Prior to Jan 1, 1982")
                return (DateTime?)null;

            DateTime dt;
            DateTime.TryParse(text, out dt);

            if (dt == DateTime.MinValue)
                return null;
            else
                return dt;

        }
    }
}
