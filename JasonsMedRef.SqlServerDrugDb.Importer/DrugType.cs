using System;
using System.Collections.Generic;

namespace JasonsMedRef.SqlServerDrugDb
{
    public partial class DrugType
    {
        public DrugType()
        {
            Drug = new HashSet<Drug>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string NameExtended { get; set; }

        public virtual ICollection<Drug> Drug { get; set; }
    }
}
