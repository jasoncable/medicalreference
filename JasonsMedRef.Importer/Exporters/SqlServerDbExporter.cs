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
using System.Xml;
using System.Xml.Linq;
using JasonsMedRef.SqlServerDrugDb;
using Microsoft.EntityFrameworkCore;

namespace JasonsMedRef.Importer.Exporters
{
    public static class SqlServerDbExporter
    {
        public async static Task<int> Export()
        {
            // assume empty database!
            /*
                delete from package
                delete from tradename
                delete from patent
                delete from exclusivity
                delete from drugpharmaclassxref
                delete from strength
                delete from [application]
                delete from drug
                delete from applicationtype
                delete from dosageform
                delete from drugschedule
                delete from marketingcategory
                delete from pharmaclass
                delete from pharmaclassclass
                delete from routeofadministration
                delete from therapeuticequivalencecode
                delete from drugtype
            */
            using DrugDbContext context = new DrugDbContext();

            await AddPharmaClassClasses(context);
            var pharmaClassClassCache = context.PharmaClassClass.AsNoTracking().ToDictionary(x => x.Name, y => y.Id);
            await AddPharmaClasses(context, pharmaClassClassCache);
            var pharmaClassCache = context.PharmaClass.AsNoTracking().ToDictionary(x => x.Name, y => y.Id);
            await AddMarketingCategories(context);
            var marketingCategoryCache = context.MarketingCategory.AsNoTracking().ToDictionary(x => x.Name, y => y.Id);
            await AddDosageForms(context);
            var dosageFormsCache = context.DosageForm.AsNoTracking().ToDictionary(x => x.Name, y => y.Id);
            await AddDrugSchedules(context);
            var drugScheduleCache = context.DrugSchedule.AsNoTracking().ToDictionary(x => x.Name, y => y.Id);
            await AddApplicationTypes(context);
            var applicationTypeCache = context.ApplicationType.AsNoTracking().ToDictionary(x => x.Name, y => y.Id);
            await AddRouteOfAdmins(context);
            var routeOfAdminCache = context.RouteOfAdministration.AsNoTracking().ToDictionary(x => x.Name, y => y.Id);
            await AddDrugTypes(context);
            var drugTypeCache = context.DrugType.AsNoTracking().ToDictionary(x => x.Name, y => y.Id);
            await AddTECodes(context);
            var teCodeCache = context.TherapeuticEquivalenceCode.AsNoTracking().ToDictionary(x => x.Code, y => y.Id);

            await context.SaveChangesAsync(); // just in case

            int saveEvery = 100;
            int i = 1;

            foreach(Models.Drug d in Importers.ImporterCache.Instance.Drugs.Values)
            {
                if(i % saveEvery == 0)
                {
                    try
                    {
                        await context.SaveChangesAsync();
                        context.ChangeTracker.AcceptAllChanges();
                    }
                    catch (Exception exc)
                    {
                        Program.Logger.Error(exc);
                    }
                }

                Drug drug = new Drug
                {
                    Ingredient = d.Ingredient,
                    EndMarketingDate = d.EndMarketingDate,
                    StartMarketingDate = d.StartMarketingDate,
                    RouteOfAdminId = GetValueFromCacheObject(routeOfAdminCache,
                        d.RouteOfAdmin.HasValue ? d.RouteOfAdmin.Value.ToString() : null,
                        Models.Enums.RouteOfAdministration.Oral.ToString()),
                    DrugTypeId = GetValueFromCacheObject(drugTypeCache,
                        d.DrugType.HasValue ? d.DrugType.Value.ToString() : null,
                        Models.Enums.DrugType.Prescription.ToString()),
                    DosageFormId = GetValueFromCacheObject(dosageFormsCache,
                        d.DosageForm.HasValue ? d.DosageForm.Value.ToString() : null,
                        Models.Enums.DosageForm.Tablet.ToString())
                };

                if (d.Schedule != null)
                    drug.DrugScheduleId = GetValueFromCacheObjectNullable(drugScheduleCache,
                        d.Schedule.HasValue ? d.Schedule.Value.ToString() : null);
                if (d.MarketingCategory != null)
                    drug.MarketingCategoryId = GetValueFromCacheObject(marketingCategoryCache,
                        d.MarketingCategory.HasValue ? d.MarketingCategory.Value.ToString() : null,
                        Models.Enums.MarketingCategory.ApprovedProduct.ToString());

                drug.Application = (from app in Importers.ImporterCache.Instance.Apps
                                    join a2a in Importers.ImporterCache.Instance.AppToApp on app.Id equals a2a.Value
                                    join a2d in Importers.ImporterCache.Instance.AppToDrug on a2a.Key equals a2d.Key
                                    where a2d.Value == d.Id
                                    select new Application
                                    {
                                        Applicant = app.Applicant,
                                        ApplicantFullName = app.ApplicantFullName,
                                        ApplicationNumber = app.ApplicationNumber,
                                        ApplicationTypeId = GetValueFromCacheObject(applicationTypeCache,
                                            app.ApplicationType.HasValue ? app.ApplicationType.Value.ToString() : null,
                                            Models.Enums.ApplicationType.New.ToString()),
                                        ApprovalDate = app.ApprovalDate,
                                        ProductNumber = app.ProductNumber,
                                        ReferenceListedDrug = app.ReferenceListedDrug ?? false,
                                        ReferenceStandard = app.ReferenceStandard ?? false,
                                        TherapeuticEquivalenceCodeId = GetValueFromCacheObject(teCodeCache, app.TeCode, "AB"),
                                        Exclusivity = (from e in Importers.ImporterCache.Instance.Exclusivities
                                                       where e.DrugId == d.Id
                                                       select new Exclusivity
                                                       {
                                                           Code = e.ExclusivityCode,
                                                           Expiration = e.ExpirationDate
                                                       }).ToList(),
                                        Patent = (from p in Importers.ImporterCache.Instance.Patents
                                                  where p.DrugId == d.Id
                                                  select new Patent
                                                  {
                                                      Number = p.PatentNumber,
                                                      Expiration = p.ExpirationDate
                                                  }
                                                  ).ToList(),
                                        Strength = app.Strength
                                    }).ToList();

                drug.Strength = d.Strengths.Select(x => new Strength { Name = x } ).ToList();
                drug.TradeName = d.TradeNames.Select(x => new TradeName { Name = x }).ToList();

                drug.DrugPharmaClassXref = (from pc in Importers.ImporterCache.Instance.PharmaClasses
                                            where d.PharmaClasses.Contains(pc.Value.Id) && pc.Value != null
                                            select new DrugPharmaClassXref
                                            {
                                                PharmaClassId = pharmaClassCache[pc.Value.Name]
                                            }).ToList();

                drug.Package = (from pkg in Importers.ImporterCache.Instance.Packages
                                where pkg.DrugId == d.Id
                                select new Package
                                {
                                    Description = pkg.Description,
                                    EndMarketingDate = pkg.EndMarketingDate,
                                    LabelerName = pkg.LabelerName,
                                    Ndc = pkg.Ndc,
                                    StartMarketingDate = pkg.StartMarketingDate
                                }).ToList();

                context.Drug.Add(drug);
                i++;
            }

            try
            {
                await context.SaveChangesAsync();
            }
            catch(Exception exc)
            {
                Program.Logger.Error(exc);
            }

            return 0;
        }

        private static int GetValueFromCacheObject(Dictionary<string, int> cache, string val, string defaultVal)
        {
            if (String.IsNullOrWhiteSpace(val) && cache.TryGetValue(defaultVal, out int resultId1))
                return resultId1;
            if (cache.TryGetValue(val, out int result))
                return result;
            else if (cache.TryGetValue(defaultVal, out int resultId))
                return resultId;
            else
                return 0;
        }

        private static int? GetValueFromCacheObjectNullable(Dictionary<string, int> cache, string val)
        {
            if (val == null)
                return null;
            if (cache.TryGetValue(val, out int result))
                return result;
            else
                return null;
        }

        private static async Task AddTECodes(DrugDbContext context)
        {
            Type t = typeof(Models.Enums.TherapeuticEquivalence);
            foreach (var field in t.GetFields())
            {
                if (field.Name == "value__")
                    continue;

                var attribute = Attribute.GetCustomAttribute(field,
                       typeof(Models.Enums.EnumImportValueAttribute)) as Models.Enums.EnumImportValueAttribute;
                if (attribute != null)
                {
                    foreach (var teCode in attribute.Names)
                    {
                        context.TherapeuticEquivalenceCode.Add(new SqlServerDrugDb.TherapeuticEquivalenceCode
                        {
                            Code = teCode,
                            Name = field.Name,
                            EquivalenceScore = (int)Enum.Parse(t, field.Name)
                        });
                    }
                }
            }
            await context.SaveChangesAsync();
        }

        private static async Task AddDrugTypes(DrugDbContext context)
        {
            Type t = typeof(Models.Enums.DrugType);
            foreach (var field in t.GetFields())
            {
                if (field.Name == "value__")
                    continue;

                var attribute = Attribute.GetCustomAttribute(field,
                       typeof(Models.Enums.EnumImportValueAttribute)) as Models.Enums.EnumImportValueAttribute;
                if (attribute != null)
                {
                    context.DrugType.Add(new SqlServerDrugDb.DrugType
                    {
                        Name = field.Name,
                        NameExtended = String.Join(", ", attribute.Names)
                    });
                }
            }
            await context.SaveChangesAsync();
        }

        private static async Task AddRouteOfAdmins(DrugDbContext context)
        {
            Type t = typeof(Models.Enums.RouteOfAdministration);
            foreach (var field in t.GetFields())
            {
                if (field.Name == "value__")
                    continue;

                var attribute = Attribute.GetCustomAttribute(field,
                       typeof(Models.Enums.EnumImportValueAttribute)) as Models.Enums.EnumImportValueAttribute;
                if (attribute != null)
                {
                    context.RouteOfAdministration.Add(new SqlServerDrugDb.RouteOfAdministration
                    {
                        Name = field.Name,
                        NameExtended = String.Join(", ", attribute.Names)
                    });
                }
            }
            await context.SaveChangesAsync();
        }

        private static async Task AddApplicationTypes(DrugDbContext context)
        {
            Type t = typeof(Models.Enums.ApplicationType);
            foreach (var field in t.GetFields())
            {
                if (field.Name == "value__")
                    continue;

                var attribute = Attribute.GetCustomAttribute(field,
                       typeof(Models.Enums.EnumImportValueAttribute)) as Models.Enums.EnumImportValueAttribute;
                if (attribute != null)
                {
                    context.ApplicationType.Add(new SqlServerDrugDb.ApplicationType
                    {
                        Name = field.Name
                    });
                }
            }
            await context.SaveChangesAsync();
        }

        private static async Task AddDrugSchedules(DrugDbContext context)
        {
            Type t = typeof(Models.Enums.DrugSchedule);
            foreach (var field in t.GetFields())
            {
                if (field.Name == "value__")
                    continue;

                context.DrugSchedule.Add(new SqlServerDrugDb.DrugSchedule
                {
                    Name = field.Name,
                    NameAsNumber = (int)Enum.Parse(t, field.Name)
                });
            }
            await context.SaveChangesAsync();
        }

        private static async Task AddDosageForms(DrugDbContext context)
        {
            Type t = typeof(Models.Enums.DosageForm);
            foreach (var field in t.GetFields())
            {
                if (field.Name == "value__")
                    continue;

                var attribute = Attribute.GetCustomAttribute(field,
                       typeof(Models.Enums.EnumImportValueAttribute)) as Models.Enums.EnumImportValueAttribute;
                if (attribute != null)
                {
                    context.DosageForm.Add(new SqlServerDrugDb.DosageForm
                    {
                        Name = field.Name,
                        NameExtended = String.Join(", ", attribute.Names)
                    });
                }
            }
            await context.SaveChangesAsync();
        }

        private static async Task AddPharmaClasses(DrugDbContext context, Dictionary<string, int> pharmaClassCache)
        {
            foreach(var pharmaClass in Importers.ImporterCache.Instance.PharmaClasses)
            {
                if (pharmaClass.Value.Classification != null &&
                    pharmaClassCache.TryGetValue(pharmaClass.Value.Classification.ToString(), out int pharmaClassClassId))
                {
                    context.PharmaClass.Add(new PharmaClass
                    {
                        Name = pharmaClass.Value.Name,
                        PharmaClassClassId = GetValueFromCacheObjectNullable(pharmaClassCache, pharmaClass.Value?.Classification?.ToString())
                    });
                }
            }
            await context.SaveChangesAsync();
        }

        private static async Task AddPharmaClassClasses(DrugDbContext context)
        {
            Type t = typeof(Models.Enums.PharmaClassClassification);
            foreach (var field in t.GetFields())
            {
                if (field.Name == "value__")
                    continue;

                var attribute = Attribute.GetCustomAttribute(field,
                       typeof(Models.Enums.EnumImportValueAttribute)) as Models.Enums.EnumImportValueAttribute;
                if (attribute != null)
                {
                    context.PharmaClassClass.Add(new SqlServerDrugDb.PharmaClassClass
                    {
                        Name = field.Name,
                        ExtendedName = String.Join(", ", attribute.Names)
                    });
                }
            }
            await context.SaveChangesAsync();
        }

        private static async Task AddMarketingCategories(DrugDbContext context)
        {
            Type t = typeof(Models.Enums.MarketingCategory);
            foreach (var field in t.GetFields())
            {
                if (field.Name == "value__")
                    continue;

                var attribute = Attribute.GetCustomAttribute(field,
                       typeof(Models.Enums.EnumImportValueAttribute)) as Models.Enums.EnumImportValueAttribute;
                if (attribute != null)
                {
                    context.MarketingCategory.Add(new SqlServerDrugDb.MarketingCategory
                    {
                        Name = field.Name,
                        NameExtended = String.Join(", ", attribute.Names)
                    });
                }
            }
            await context.SaveChangesAsync();
        }
    }
}
