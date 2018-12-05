using System;
using System.Collections.Generic;
using System.Text;
using JasonsMedRef.Models.Enums;

namespace JasonsMedRef.Models
{
    public class PharmaClass
    {
        public static readonly string IndexName = "jmr_pharmaclass";

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ClassificationText { get; set; }
        public PharmaClassClassification? Classification { get; set; }
    }
}
