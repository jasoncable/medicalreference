using JasonsMedRef.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JasonsMedRef.Models.JsonModels
{
    public class JsonPharmaClass
    {
        public string Name { get; set; }
        [JsonConverter(typeof(NullableIntEnumConverter))]
        public PharmaClassClassification? Classification { get; set; }
    }
}
