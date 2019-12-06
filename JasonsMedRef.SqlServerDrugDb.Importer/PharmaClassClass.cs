using System;
using System.Collections.Generic;

namespace JasonsMedRef.SqlServerDrugDb
{
    public partial class PharmaClassClass
    {
        public PharmaClassClass()
        {
            PharmaClass = new HashSet<PharmaClass>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ExtendedName { get; set; }

        public virtual ICollection<PharmaClass> PharmaClass { get; set; }
    }
}
