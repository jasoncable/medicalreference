using System;
using System.Collections.Generic;
using System.Text;

namespace JasonsMedRef.Models
{
    public class Patent
    {
        public static readonly string IndexName = "jmr_patent";

        public Guid Id { get; set; }
        public Guid DrugId { get; set; }
        public Guid ApplicationId { get; set; }
        public string PatentNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
