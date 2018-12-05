using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Collections;
using System.Linq;

namespace JasonsMedRef.Importer.Maps
{
    public class BooleanTypeConverter : ITypeConverter
    {
        private static readonly string[] _trueValues = new string[] {"y", "yes", "true", "t"};
        private static readonly string[] _falseValues = new string[] { "n", "no", "false", "f" };

        public BooleanTypeConverter()
        {
        }

        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            Type type = memberMapData.Member.MemberType.GetType();
            if (value == null)
                return String.Empty;
            else if (type == typeof(bool))
                return value.ToString();
            else
                return String.Empty;
        }

        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            Type type = memberMapData.Member.MemberType.GetType();

            if (String.IsNullOrWhiteSpace(text))
            {
                if (Nullable.GetUnderlyingType(type) != null)
                    return (bool?) null;
                else
                    return false;
            }

            string compareText = text.Trim().ToLowerInvariant();

            if (_trueValues.Contains(text))
                return true;
            if (_falseValues.Contains(text))
                return false;

            if (Nullable.GetUnderlyingType(type) != null)
                return (bool?)null;

            return false;
        }
    }
}
