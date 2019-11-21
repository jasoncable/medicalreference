using Newtonsoft.Json;
using System;

namespace Jaxosoft.TestData
{
    public class JsonPharmaClass
    {
        public string Name { get; set; }
        [JsonConverter(typeof(NullableIntEnumConverter))]
        public PharmaClassClassification? Classification { get; set; }
    }
}
