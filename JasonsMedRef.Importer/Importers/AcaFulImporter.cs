using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using JasonsMedRef.Importer.Maps;
using JasonsMedRef.Models;
using JasonsMedRef.Repository;

namespace JasonsMedRef.Importer.Importers
{
    public class AcaFulImporter
    {
        public static async Task<int> Import(string baseDir, SiteConfig config)
        {
            string workDir = Path.Combine(baseDir, config.ShortName);
            Directory.CreateDirectory(workDir);

            //using (HttpClient httpClient = new HttpClient())
            //{
            //    HttpResponseMessage msg = await httpClient.GetAsync(new Uri(config.DownloadFiles[0]));
            //    using (StreamWriter sw = new StreamWriter(Path.Combine(workDir, "acaful.csv")))
            //    {
            //        await (msg.Content.CopyToAsync(sw.BaseStream));
            //        sw.Flush();
            //    }
            //}

            using (StreamReader sr = new StreamReader(Path.Combine(workDir, "acaful.csv")))
            {
                var csv = new CsvReader(sr);
                csv.Configuration.RegisterClassMap<AcaFulMap>();
                csv.Configuration.Delimiter = ",";
                var records = csv.GetRecords<AcaFulObject>();

                foreach (var rec in records)
                {
                    FederalUpperLimit ful = new FederalUpperLimit
                    {
                        AvgMfgPrice = rec.WeightedAverageAmps,
                        Ful = rec.AcaFedUpperLimit,
                        PackageSize = rec.PackageSize,
                        ReportingDate = new DateTime(rec.Year, rec.Month, 1),
                        UnitType = rec.MdrUnitType
                    };

                    ImporterCache.Instance.AddOrUpdate(ful, rec.Ndc);
                }
            }

            return 0;
        }
    }
}
