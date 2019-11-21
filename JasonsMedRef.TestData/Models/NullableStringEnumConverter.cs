using Newtonsoft.Json;
using System;

namespace Jaxosoft.TestData
{
    public class NullableIntEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsEnum && Nullable.GetUnderlyingType(objectType) != null;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            string stringValue;
            if (reader.TokenType == JsonToken.String)
            {
                stringValue = (string)reader.Value;
                if (Enum.TryParse(Nullable.GetUnderlyingType(objectType), stringValue, out object enumInstance))
                    return enumInstance;
                else
                    return null;
            }

            if (reader.TokenType == JsonToken.Integer)
            {
                return Enum.ToObject(Nullable.GetUnderlyingType(objectType), (int)(long)reader.Value);
            }
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
                writer.WriteNull();
            else
                writer.WriteValue((int)value);
        }
    }
}
