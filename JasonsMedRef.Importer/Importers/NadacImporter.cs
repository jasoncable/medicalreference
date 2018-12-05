using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using ICSharpCode.SharpZipLib.Zip;
using JasonsMedRef.Importer.Maps;
using JasonsMedRef.Models;
using JasonsMedRef.Repository;

namespace JasonsMedRef.Importer.Importers
{
    public class NadacImporter
    {
        public static async Task<int> Import(string baseDir, SiteConfig config)
        {
            string workDir = Path.Combine(baseDir, config.ShortName);
            Directory.CreateDirectory(workDir);

            //using (HttpClient httpClient = new HttpClient())
            //{
            //    HttpResponseMessage msg = await httpClient.GetAsync(new Uri(config.DownloadFiles[0]));
            //    using (StreamWriter sw = new StreamWriter(Path.Combine(workDir, "nadac.csv")))
            //    {
            //        await (msg.Content.CopyToAsync(sw.BaseStream));
            //        sw.Flush();
            //    }
            //}

            using (StreamReader sr = new StreamReader(Path.Combine(workDir, "nadac.csv")))
            {
                var csv = new CsvReader(sr);
                csv.Configuration.RegisterClassMap<NadacItemMap>();
                csv.Configuration.Delimiter = ",";
                var records = csv.GetRecords<NadacItem>();

                foreach (var rec in records)
                {
                    Nadac nadac = new Nadac
                    {
                        AsOfDate = rec.AsOfDate,
                        ClassRateSetting = rec.ClassRateSetting,
                        CorrespondingGenericEffectiveDate = rec.CorrespondingGenericEffectiveDate,
                        CorrespondingGenericNadacPerUnit = rec.CorrespondingGenericNadacPerUnit,
                        EffectiveDate = rec.EffectiveDate,
                        NadacPerUnit = rec.NadacPerUnit,
                        Otc = rec.Otc,
                        PharmaType = rec.PharmaType,
                        PricingUnit = rec.PricingUnit
                    };

                    string ndc = StringFunctions.ConvertToNdc11(rec.Ndc);
                    nadac.Ndc = ndc;

                    ImporterCache.Instance.AddOrUpdate(nadac, ndc);
                }
            }

            return 0;
        }
    }
}
