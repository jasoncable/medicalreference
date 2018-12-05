using System;
using System.Collections.Generic;
using System.Text;

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
}
