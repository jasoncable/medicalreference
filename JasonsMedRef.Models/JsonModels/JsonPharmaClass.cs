using JasonsMedRef.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace JasonsMedRef.Models.JsonModels
{
    public class JsonPharmaClass
    {
        public string Name { get; set; }
        public PharmaClassClassification? Classification { get; set; }
    }
}
