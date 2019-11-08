using System;
using System.Collections.Generic;
using System.Text;

namespace JasonsMedRef.Models.JsonModels
{
    public class JsonPackage
    {
        public string LabelerName { get; set; }
        public string Ndc { get; set; }
        public string Description { get; set; }
        public DateTime? StartMarketingDate { get; set; }
        public DateTime? EndMarketingDate { get; set; }
    }
}
