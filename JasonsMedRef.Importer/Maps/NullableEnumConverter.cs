using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Reflection;
using System.Linq;
using JasonsMedRef.Models.Enums;

namespace JasonsMedRef.Importer.Maps
{
    public class NullableEnumConverter : ITypeConverter
    {
        public NullableEnumConverter()
        {
        }

        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            if (value == null)
                return String.Empty;
            else
                return ((int) value).ToString();
        }

        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (String.IsNullOrWhiteSpace(text))
                return null;

            Type t = memberMapData.Member.DeclaringType.GetProperty(memberMapData.Member.Name).PropertyType;
            if (Nullable.GetUnderlyingType(t) != null)
                t = Nullable.GetUnderlyingType(t);
            
            int? enumValue  = EnumCache.Instance.GetNullableValue(t, text);

            if (enumValue == null)
                return null;
            else
                return Enum.ToObject(t, enumValue);
        }

        public object ConvertFromStringWayTooSlow(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (String.IsNullOrWhiteSpace(text))
                return null;

            Type type = memberMapData.Member.MemberType.GetType();

            if (!type.IsEnum && Nullable.GetUnderlyingType(type) == null)
            {
                throw new ArgumentException($"'{type.FullName}' is not a nullable enum.");
            }

            // assume that integer values are mapped to the enum values
            object obj;
            Enum.TryParse(type, text, true, out obj);
            if (obj != null)
                return obj;

            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(EnumImportValueAttribute)) as EnumImportValueAttribute;
                if (attribute != null)
                {
                    if (attribute.Names.Contains(text))
                        return Enum.ToObject(type, field.GetValue(null));
                }
                else
                {
                    if (field.Name == text)
                        return Enum.ToObject(type, field.GetValue(null));
                }
            }
            return null;
        }
    }
}
