using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JasonsMedRef.Models.Enums
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
