using JasonsMedRef.Importer.Importers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using JasonsMedRef.Models;

namespace JasonsMedRef.Importer.Exporters
{
    public static class FormularyExporter
    {
        public static async Task<int> Export()
        {
            using StreamWriter sw = new StreamWriter(@"c:\temp\formulary.csv");

            foreach (Package p in ImporterCache.Instance.Packages.Where(x => x.LabelerName.Contains("teva", StringComparison.CurrentCultureIgnoreCase))) {
                if (ImporterCache.Instance.DrugsByDrugId.TryGetValue(p.DrugId, out Drug myDrug))
                {
                    await sw.WriteLineAsync($"{p.Ndc},\"{p.ApplicationNumber?.Replace("\"", String.Empty)}\",\"{p.Description?.Replace("\"", String.Empty)}\",\"{p.LabelerName?.Replace("\"", String.Empty)}\",\"{myDrug.Ingredient}\"");
                }
            }

            return 0;
        }

    }
}
