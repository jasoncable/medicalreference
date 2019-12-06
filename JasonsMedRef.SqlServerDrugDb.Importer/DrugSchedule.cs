using System;
using System.Collections.Generic;

namespace JasonsMedRef.SqlServerDrugDb
{
    public partial class DrugSchedule
    {
        public DrugSchedule()
        {
            Drug = new HashSet<Drug>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int NameAsNumber { get; set; }

        public virtual ICollection<Drug> Drug { get; set; }
    }
}
