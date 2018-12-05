using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CsvHelper;
using JasonsMedRef.Importer.Maps;
using JasonsMedRef.Models.Enums;
using JasonsMedRef.Repository;
using System.Linq;
using ESPharmaClass = JasonsMedRef.Models.PharmaClass;

namespace JasonsMedRef.Importer.Importers
{
    public class PharmaClassImporter
    {
        private static readonly Regex _rRemoveBrackets = new Regex(@"\[[^\]]+] ");

        public static async Task<int> Import(string baseDir, SiteConfig config)
        {
            string workDir = Path.Combine(baseDir, config.ShortName);
            Directory.CreateDirectory(workDir);

            //using (HttpClient httpClient = new HttpClient())
            //{
            //    HttpResponseMessage msg = await httpClient.GetAsync(new Uri(config.DownloadFiles[0]));
            //    using (StreamWriter sw = new StreamWriter(Path.Combine(workDir, "classes.txt")))
            //    {
            //        await (msg.Content.CopyToAsync(sw.BaseStream));
            //        sw.Flush();
            //    }
            //}

            List<ESPharmaClass> classes = new List<ESPharmaClass>();

            using (StreamReader sr = new StreamReader(Path.Combine(workDir, "classes.txt")))
            {
                var csv = new CsvReader(sr);
                csv.Configuration.RegisterClassMap<PharmaClassMap>();
                csv.Configuration.Delimiter = "\t";
                csv.Configuration.IgnoreQuotes = true;
                csv.Configuration.MissingFieldFound = null;
                var records = csv.GetRecords<PharmaClass>();

                foreach (var rec in records)
                {
                    ESPharmaClass esRec = new ESPharmaClass
                    {
                        ClassificationText = rec.ClassificationText,
                        Classification = rec.Classification,
                        Name = _rRemoveBrackets.Replace( rec.Name, "" )
                    };

                    if (!classes.Any(x => x.Classification == rec.Classification && esRec.Name == x.Name))
                        classes.Add(esRec);
                }
            }

            foreach (var rec in classes)
                ImporterCache.Instance.AddOrUpdate(rec);

            return 0;
        }
    }
}
