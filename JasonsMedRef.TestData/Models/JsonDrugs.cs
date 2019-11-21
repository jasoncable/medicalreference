using System;
using System.Collections.Generic;

namespace Jaxosoft.TestData
{
    public class JsonDrugs
    {
        public DateTime GeneratedDate { get; set; } = DateTime.UtcNow;
        public List<JsonDrug> Drugs { get; set; }
    }
}
