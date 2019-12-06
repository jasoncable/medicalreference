using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CsvHelper;
using ICSharpCode.SharpZipLib.Zip;
using JasonsMedRef.Importer.Maps;
using JasonsMedRef.Models;
using JasonsMedRef.Models.Enums;
using JasonsMedRef.Repository;
using System.Linq;

namespace JasonsMedRef.Importer.Importers
{
    public class NdcImporter
    {
        private static readonly Regex _rRemoveBrackets = new Regex(@" \[[^\]]+]");
        private static readonly Regex _rRemoveSlashOne = new Regex(@"/1$");

        public static async Task<int> Import(string baseDir, SiteConfig config)
        {
            string workDir = Path.Combine(baseDir, config.ShortName);
            Directory.CreateDirectory(workDir);

            //using (HttpClient httpClient = new HttpClient())
            //{
            //    HttpResponseMessage msg = await httpClient.GetAsync(new Uri(config.DownloadFiles[0]));
            //    using (StreamWriter sw = new StreamWriter(Path.Combine(workDir, "ndc.zip")))
            //    {
            //        await (msg.Content.CopyToAsync(sw.BaseStream));
            //        sw.Flush();
            //    }
            //}

            //FastZip fz = new FastZip();
            //fz.ExtractZip(Path.Combine(workDir, "ndc.zip"), workDir, null);

            using (StreamReader sr = new StreamReader(Path.Combine(workDir, "product.txt")))
            {
                var csv = new CsvReader(sr);
                csv.Configuration.RegisterClassMap<Ndc_ProductMap>();
                csv.Configuration.Delimiter = "\t";
                csv.Configuration.IgnoreQuotes = true;
                var records = csv.GetRecords<Ndc_Product>();

                foreach (var rec in records)
                {
                    List<string> pharmaClasses = new List<string>();
                    List<string> pharmaClassesText = new List<string>();
                    if (!String.IsNullOrWhiteSpace(rec.PharmaClasses))
                    {
                        string[] sa = rec.PharmaClasses.Split(',');
                        foreach (string s in sa)
                        {
                            string pClass = _rRemoveBrackets.Replace(s.Trim(), "");
                            pharmaClasses.Add(pClass);
                            pharmaClassesText.Add(pClass);
                        }
                    }

                    var drug = new Drug
                    {
                        DosageForm = rec.DosageFormName,
                        DosageFormText = rec.DosageFormNameText,
                        DrugType = rec.ProductTypeName,
                        TradeNames = new List<string> {rec.ProprietaryName, rec.SubstanceName},
                        Ingredient = rec.NonProprietaryName,
                        RouteOfAdmin = rec.RouteName,
                        RouteOfAdminText = rec.RouteNameText,
                        Schedule = rec.DeaSchedule,
                        Strengths = new List<string> {$"{rec.ActiveNumeratorStrength} {_rRemoveSlashOne.Replace(rec.ActiveIngredientUnit,String.Empty)}"},
                        StartMarketingDate = rec.StartMarketingDate,
                        EndMarketingDate = rec.EndMarketingDate,
                        PharmaClassesText = pharmaClassesText,
                        MarketingCategory = rec.MarketingCategoryName
                    };

                    if (!String.IsNullOrWhiteSpace(rec.ProprietaryNameSuffix))
                        drug.TradeNames.Add($"{rec.ProductTypeName} {rec.ProprietaryNameSuffix}");

                    ImporterCache.Instance.CacheProductForPackageInfo(rec.ProductId, rec.LabelerName,
                        rec.ApplicationNumber);
                    ImporterCache.Instance.AddOrUpdate(drug, null, rec.ProductId);
                }
            }

            using (StreamReader sr = new StreamReader(Path.Combine(workDir, "package.txt")))
            {
                var csv = new CsvReader(sr);
                csv.Configuration.RegisterClassMap<Ndc_PackageMap>();
                csv.Configuration.Delimiter = "\t";
                csv.Configuration.IgnoreQuotes = true;
                var records = csv.GetRecords<Ndc_Package>();

                foreach (var rec in records)
                {
                    Package p = new Package
                    {
                        Description = rec.PackageDescription,
                        Ndc = StringFunctions.ConvertToNdc11(rec.NdcPackageCode),
                        StartMarketingDate = rec.StartMarketingDate,
                        EndMarketingDate = rec.EndMarketingDate
                    };

                    ImporterCache.Instance.AddOrUpdate(p, rec.ProductId);
                }
            }

            return 0;
        }
    }
}
