using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
//using System.Text.Json;
//using System.Text.Json.Serialization;
using JasonsMedRef.Models.JsonModels;
using JasonsMedRef.Importer.Importers;
using Newtonsoft.Json;

namespace JasonsMedRef.Importer.Exporters
{
    public class JsonExporter
    {
        public static async Task<int> Export(string outputPath)
        {
            //var options = new JsonSerializerOptions
            //{
            //    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            //    WriteIndented = true
            //};

            JsonDrugs obj = new JsonDrugs();

            obj.Drugs =
                (from d in ImporterCache.Instance.Drugs.AsParallel()
                     //join a2d in ImporterCache.Instance.AppToDrug on d.Value.Id equals a2d.Value
                     //join a2a in ImporterCache.Instance.AppToApp on a2d.Key equals a2a.Key
                     //join app in ImporterCache.Instance.Apps on a2a.Value equals app.Id
                     //join e in ImporterCache.Instance.Exclusivities on app.Id equals e.ApplicationId
                     //join pat in ImporterCache.Instance.Patents on app.Id equals pat.ApplicationId
                     //join p in ImporterCache.Instance.Packages on app.ApplicationNumber equals p.ApplicationNumber
                 where d.Value.Ingredient.StartsWith("a", StringComparison.CurrentCultureIgnoreCase)
                 select new JsonDrug
                 {
                     Ingredient = d.Value.Ingredient,
                     DosageForm = d.Value.DosageForm,
                     DrugType = d.Value.DrugType,
                     Route = d.Value.RouteOfAdmin,
                     StartMarketingDate = d.Value.StartMarketingDate,
                     EndMarketingDate = d.Value.EndMarketingDate,
                     Schedule = d.Value.Schedule,
                     TradeNames = d.Value.TradeNames,
                     Applications = (from app in ImporterCache.Instance.Apps
                                     join a2a in ImporterCache.Instance.AppToApp on app.Id equals a2a.Value
                                     join a2d in ImporterCache.Instance.AppToDrug on a2a.Key equals a2d.Key
                                     where a2d.Value == d.Value.Id
                                     select new JsonApplication
                                     {
                                         Applicant = app.Applicant,
                                         ApplicantFullName = app.ApplicantFullName,
                                         ApplicationNumber = app.ApplicationNumber,
                                         ApplicationType = app.ApplicationType,
                                         ApprovalDate = app.ApprovalDate,
                                         ProductNumber = app.ProductNumber,
                                         ReferenceListedDrug = app.ReferenceListedDrug,
                                         ReferenceStandard = app.ReferenceStandard,
                                         TeCode = app.TeCode,
                                         Exclusivities = (from e in ImporterCache.Instance.Exclusivities
                                                          where e.DrugId == d.Value.Id // && e.ApplicationId == app.Id
                                                          select new JsonExclusivity
                                                          {
                                                              ExclusivityCode = e.ExclusivityCode,
                                                              ExpirationDate = e.ExpirationDate
                                                          }).ToList(),
                                         Patents = (from p in ImporterCache.Instance.Patents
                                                    where p.DrugId == d.Value.Id // && p.ApplicationId == app.Id
                                                    select new JsonPatent
                                                    {
                                                        PatentNumber = p.PatentNumber,
                                                        ExpirationDate = p.ExpirationDate
                                                    }
                                                    ).ToList(),
                                         Packages = (from pkg in ImporterCache.Instance.Packages
                                                     where pkg.DrugId == d.Value.Id // && pkg.ApplicationNumber == app.ApplicationNumber
                                                     select new JsonPackage
                                                     {
                                                         Description = pkg.Description,
                                                         EndMarketingDate = pkg.EndMarketingDate,
                                                         LabelerName = pkg.LabelerName,
                                                         Ndc = pkg.LabelerName,
                                                         StartMarketingDate = pkg.StartMarketingDate
                                                     }).ToList()
                                     }).ToList(),
                     PharmaClasses = (from pc in ImporterCache.Instance.PharmaClasses
                                      where d.Value.PharmaClasses.Contains( pc.Value.Id )
                                      select new JsonPharmaClass
                                      {
                                          Classification = pc.Value.Classification,
                                          Name = pc.Value.Name
                                      }).ToList(),
                     Strengths = d.Value.Strengths
                 }).ToList();

            //byte[] buffer = new byte[4096];
            //using FileStream fs = File.Create(outputPath);
            //await JsonSerializer.SerializeAsync(fs, obj, options);
            //await fs.FlushAsync();
            //fs.Close();

            using (StreamWriter sw = File.CreateText(outputPath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                serializer.Serialize(sw, obj);
            }

            return 0;
        }
    }
}
