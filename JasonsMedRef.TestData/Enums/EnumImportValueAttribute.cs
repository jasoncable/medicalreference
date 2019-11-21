using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Jaxosoft.TestData
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class EnumImportValueAttribute : Attribute
    {
        public string[] Names { get; private set; }

        private EnumImportValueAttribute()
        {
        }

        public EnumImportValueAttribute(string[] importNames)
        {
            Names = importNames;
        }
    }

    public static class EnumImportValueReader
    {
        private static readonly List<string> _emptyStringList = new List<string>();

        public static List<string> GetTextValues(this Enum val)
        {
            Type t = typeof(EnumImportValueAttribute);
            FieldInfo fi = t.GetField(val.ToString());
            if (fi == null)
                return _emptyStringList;

            var attrData = fi.GetCustomAttribute<EnumImportValueAttribute>();
            if (attrData == null)
                return _emptyStringList;

            return attrData.Names.ToList();
        }

        public static string GetTextValue(this Enum val)
        {
            List<String> result = val.GetTextValues();
            if (result.Count == 0)
                return null;
            else
                return String.Join(", ", result);
        }
    }
}
