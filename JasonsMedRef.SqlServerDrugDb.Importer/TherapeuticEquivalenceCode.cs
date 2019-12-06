using System;
using System.Collections.Generic;

namespace JasonsMedRef.SqlServerDrugDb
{
    public partial class TherapeuticEquivalenceCode
    {
        public TherapeuticEquivalenceCode()
        {
            Application = new HashSet<Application>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int EquivalenceScore { get; set; }

        public virtual ICollection<Application> Application { get; set; }
    }
}
