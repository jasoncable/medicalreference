using System;
using System.Collections.Generic;
using System.Text;

namespace JasonsMedRef.Models
{
    public class Exclusivity
    {
        public static readonly string IndexName = "jmr_exclusivity";

        public Guid Id { get; set; }
        public Guid DrugId { get; set; }
        public Guid ApplicationId { get; set; }
        public string ExclusivityCode { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
