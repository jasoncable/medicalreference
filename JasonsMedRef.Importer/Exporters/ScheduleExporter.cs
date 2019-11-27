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
    public static class ScheduleExporter
    {
        public static async Task<int> Export()
        {
            using StreamWriter sw = new StreamWriter(@"c:\temp\scheduled_drugs.csv");

            foreach (var rec in ImporterCache.Instance.Drugs.AsParallel().Where(x => x.Value.Schedule.HasValue && x.Value.DrugType == Models.Enums.DrugType.Prescription).OrderBy(x => x.Value.Schedule).ThenBy(x => x.Value.Ingredient))
            {
                var drug = rec.Value;
                await sw.WriteLineAsync($"{drug.Schedule},\"{drug.Ingredient.Replace("\"", "'")}\",\"{drug.RouteOfAdminText}\",\"{drug.DosageFormText}\",\"{String.Join(", ",drug.TradeNames)}\",\"{String.Join(", ", drug.PharmaClassesText)}\"");
            }

            return 0;
        }
    }
}
