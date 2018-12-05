using System;
using System.Collections.Generic;
using System.Text;
using JasonsMedRef.Models.Enums;

namespace JasonsMedRef.Importer.Maps
{
    public class PharmaClass
    {
        public string UniqueIdentifier { get; set; }
        public string Name { get; set; }
        public PharmaClassClassification? Classification { get; set; }
        public string ClassificationText { get; set; }

    }
}
