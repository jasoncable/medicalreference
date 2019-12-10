using System;
using System.Collections.Generic;

namespace JasonsMedRef.SqlServerDrugDb
{
    public partial class ApplicationType
    {
        public ApplicationType()
        {
            Application = new HashSet<Application>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Application> Application { get; set; }
    }
}
