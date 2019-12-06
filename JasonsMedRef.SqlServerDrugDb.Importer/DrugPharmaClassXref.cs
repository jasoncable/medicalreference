using System;
using System.Collections.Generic;

namespace JasonsMedRef.SqlServerDrugDb
{
    public partial class DrugPharmaClassXref
    {
        public int Id { get; set; }
        public int DrugId { get; set; }
        public int PharmaClassId { get; set; }

        public virtual Drug Drug { get; set; }
        public virtual PharmaClass PharmaClass { get; set; }
    }
}
