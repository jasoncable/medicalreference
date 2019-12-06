﻿using System;
using System.Collections.Generic;

namespace JasonsMedRef.SqlServerDrugDb
{
    public partial class Exclusivity
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public string Code { get; set; }
        public DateTime? Expiration { get; set; }

        public virtual Application Application { get; set; }
    }
}
