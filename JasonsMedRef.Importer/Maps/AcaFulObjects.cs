using System;
using System.Collections.Generic;
using System.Text;
using JasonsMedRef.Models.Enums;

namespace JasonsMedRef.Importer.Maps
{
    public class AcaFulObject
    {
        public int ProductGroup { get; set; }
        public string Ingredient { get; set; }
        public string Strength { get; set; }
        public DosageForm? Dosage { get; set; }
        public RouteOfAdministration? Route { get; set; }
        public string MdrUnitType { get; set; }
        public double? WeightedAverageAmps { get; set; }
        public double? AcaFedUpperLimit { get; set; }
        public double? PackageSize { get; set; }
        public string Ndc { get; set; }
        public bool? ARated { get; set; }
        public bool? MultiplerOfAvgOfAmp { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
    }
}
