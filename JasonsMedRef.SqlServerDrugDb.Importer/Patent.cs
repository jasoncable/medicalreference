using System;
using System.Collections.Generic;

namespace JasonsMedRef.SqlServerDrugDb
{
    public partial class Patent
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public string Number { get; set; }
        public DateTime? Expiration { get; set; }

        public virtual Application Application { get; set; }
    }
}
