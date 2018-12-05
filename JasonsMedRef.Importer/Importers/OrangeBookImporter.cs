using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CsvHelper;
using System.Net.Http;
using ICSharpCode.SharpZipLib.Zip;
using System.Threading.Tasks;
using JasonsMedRef.Importer.Maps;
using JasonsMedRef.Models;
using JasonsMedRef.Models.Enums;
using JasonsMedRef.Repository;
using System.Linq;

namespace JasonsMedRef.Importer.Importers
{
    public class OrangeBookImporter
    {
        public static async Task<int> Import(string baseDir, SiteConfig config)
        {
            string workDir = Path.Combine(baseDir, config.ShortName);
            Directory.CreateDirectory(workDir);

            //using (HttpClient httpClient = new HttpClient())
            //{
            //    HttpResponseMessage msg = await httpClient.GetAsync(new Uri(config.DownloadFiles[0]));
            //    using (StreamWriter sw = new StreamWriter(Path.Combine(workDir, "orange.zip")))
            //    {
            //        await (msg.Content.CopyToAsync(sw.BaseStream));
            //        sw.Flush()
            //    }
            //}

            //FastZip fz = new FastZip();
            //fz.ExtractZip(Path.Combine(workDir, "orange.zip"), workDir, null);

            using (StreamReader sr = new StreamReader(Path.Combine(workDir, "products.txt")))
            {
                var csv = new CsvReader(sr);
                csv.Configuration.RegisterClassMap<OrangeBook_ProductMap>();
                csv.Configuration.Delimiter = "~";
                var records = csv.GetRecords<OrangeBook_Product>();

                foreach (var rec in records)
                {
                    string[] dfRoute = rec.DfRoute.Split(';');
                    int? df = EnumCache.Instance.GetNullableValue(typeof(DosageForm), dfRoute[0]);
                    int? route = EnumCache.Instance.GetNullableValue(typeof(RouteOfAdministration), dfRoute[1]);

                    var drug = new Drug
                    {
                        Ingredient = rec.Ingredient,
                        TradeNames = new List<string> {rec.TradeName},
                        DosageForm = (DosageForm?) df,
                        DosageFormText = dfRoute[0],
                        RouteOfAdmin = (RouteOfAdministration?) route,
                        RouteOfAdminText = dfRoute[1],
                        DrugType = rec.Type,
                        Strengths = new List<string> {rec.Strength}
                    };
                       
                    var application = new Application
                    {
                        ApplicationType = rec.ApplicationType,
                        Applicant = rec.Applicant,
                        ApplicantFullName = rec.ApplicantFullName,
                        ApplicationNumber = rec.ApplicationNumber,
                        ApprovalDate = rec.ApprovalDate,
                        ProductNumber = rec.ProductNumber,
                        ReferenceListedDrug = rec.Rld,
                        ReferenceStandard = rec.Rs,
                        TeCode = rec.TeCode
                    };

                    ImporterCache.Instance.AddOrUpdate(drug, application);
                }
            }

            using (StreamReader sr = new StreamReader(Path.Combine(workDir, "exclusivity.txt")))
            {
                var csv = new CsvReader(sr);
                csv.Configuration.RegisterClassMap<OrangeBook_ExclusivityMap>();
                csv.Configuration.Delimiter = "~";
                var records = csv.GetRecords<OrangeBook_Exclusivity>();

                foreach (var rec in records)
                {
                    var exclusivity = new Exclusivity
                    {
                        ExclusivityCode = rec.ExclusivityCode,
                        ExpirationDate = rec.ExclusivityDate
                    };

                    ImporterCache.Instance.AddOrUpdate(exclusivity, rec.ApplicationNumber, rec.ProductNumber);
                }
            }

            using (StreamReader sr = new StreamReader(Path.Combine(workDir, "patent.txt")))
            {
                var csv = new CsvReader(sr);
                csv.Configuration.RegisterClassMap<OrangeBook_PatentMap>();
                csv.Configuration.Delimiter = "~";
                var records = csv.GetRecords<OrangeBook_Patent>();

                foreach (var rec in records)
                {
                    var patent = new Patent
                    {
                        PatentNumber = rec.PatentNumber,
                        ExpirationDate = rec.PatentExpireDate
                    };

                    ImporterCache.Instance.AddOrUpdate(patent, rec.ApplicationNumber, rec.ProductNumber);
                }
            }

            return 0;
        }
    }
}
