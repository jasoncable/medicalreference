using System;
using System.Collections.Generic;

namespace JasonsMedRef.SqlServerDrugDb
{
    public partial class PharmaClass
    {
        public PharmaClass()
        {
            DrugPharmaClassXref = new HashSet<DrugPharmaClassXref>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? PharmaClassClassId { get; set; }

        public virtual PharmaClassClass PharmaClassClass { get; set; }
        public virtual ICollection<DrugPharmaClassXref> DrugPharmaClassXref { get; set; }
    }
}
