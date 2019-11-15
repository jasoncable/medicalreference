using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace JasonsMedRef.Models.JsonModels
{
    public class NullableStringEnumConverter : StringEnumConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Type t = value.GetType();
            if (t.IsEnum && Nullable.GetUnderlyingType(t) != null && value == null)
                base.WriteJson(writer, null, serializer);
            else
                base.WriteJson(writer, value, serializer);
        }
    }
}
