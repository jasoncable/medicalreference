using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using JasonsMedRef.Importer.Maps;
using JasonsMedRef.Models;
using Nest;

namespace JasonsMedRef.Importer.Importers
{
    public static class StateDrugUtilizationImporter
    {
        public static async Task<int> Import(string baseDir, SiteConfig config)
        {
            string workDir = Path.Combine(baseDir, config.ShortName);
            Directory.CreateDirectory(workDir);

            //using (HttpClient httpClient = new HttpClient())
            //{
            //    HttpResponseMessage msg = await httpClient.GetAsync(new Uri(config.DownloadFiles[0]));
            //    using (StreamWriter sw = new StreamWriter(Path.Combine(workDir, "sdu.csv")))
            //    {
            //        await (msg.Content.CopyToAsync(sw.BaseStream));
            //        sw.Flush();
            //    }
            //}

            using (StreamReader sr = new StreamReader(Path.Combine(workDir, "sdu.csv")))
            {
                var csv = new CsvReader(sr);
                csv.Configuration.RegisterClassMap<SduMap>();
                csv.Configuration.Delimiter = ",";
                var records = csv.GetRecords<SduObject>();

                foreach (var rec in records)
                {
                    StateDrugUtilization sdu = new StateDrugUtilization
                    {
                        UtilizationType = rec.UtilizationType,
                        State = rec.State,
                        ReportDate = YearQtrToEndDate(Convert.ToInt32(rec.Year), Convert.ToInt32(rec.Quarter)),
                        SuppressionUsed = rec.SuppressionUsed,
                        UnitsReimbursed = rec.UnitsReimbursed,
                        NumberOfScripts = rec.NumberOfScripts,
                        TotalAmountReimbursed = rec.TotalAmountReimbursed,
                        MedicaidAmountReimbursed = rec.MedicaidAmountReimbursed,
                        NonMedicaidAmountReimbursed = rec.NonMedicaidAmountReimbursed,
                        Latitude = rec.Latitude,
                        Longitude = rec.Longitude
                    };

                    string ndc = $"{rec.NdcPart1.PadLeft(5, '0')}-{rec.NdcPart2.PadLeft(4, '0')}-{rec.NdcPart3.PadLeft(2, '0')}";

                    ImporterCache.Instance.AddOrUpdate(sdu, ndc);
                }
            }

            return 0;
        }

        private static DateTime YearQtrToEndDate(int year, int quarter)
        {
            switch (quarter)
            {
                case 1:
                    return new DateTime(year, 3, 31);
                case 2:
                    return new DateTime(year, 6, 30);
                case 3:
                    return new DateTime(year, 9, 30);
                case 4:
                    return new DateTime(year, 12, 31);
                default:
                    return new DateTime();
            }

        }
    }
}
