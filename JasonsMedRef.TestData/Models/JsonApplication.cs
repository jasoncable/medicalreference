using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Jaxosoft.TestData
{
    public class JsonApplication
    {
        [JsonConverter(typeof(NullableIntEnumConverter))]
        public ApplicationType? ApplicationType { get; set; }
        public string ApplicationNumber { get; set; }
        public string ProductNumber { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string Applicant { get; set; }
        public string ApplicantFullName { get; set; }
        public string TeCode { get; set; }
        [JsonConverter(typeof(NullableIntEnumConverter))]
        public TherapeuticEquivalence? TeDecoded { get; set; }
        public bool? ReferenceListedDrug { get; set; }
        public bool? ReferenceStandard { get; set; }
        public string Strength { get; set; }

        public List<JsonExclusivity> Exclusivities { get; set; } = new List<JsonExclusivity>();
        public List<JsonPatent> Patents { get; set; } = new List<JsonPatent>();
        public List<JsonPackage> Packages { get; set; } = new List<JsonPackage>();
    }
}
