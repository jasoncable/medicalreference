using System;
using System.Collections.Generic;

namespace JasonsMedRef.SqlServerDrugDb
{
    public partial class TradeName
    {
        public int Id { get; set; }
        public int DrugId { get; set; }
        public string Name { get; set; }

        public virtual Drug Drug { get; set; }
    }
}
