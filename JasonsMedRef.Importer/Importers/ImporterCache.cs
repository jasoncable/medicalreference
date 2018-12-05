using System;
using System.Collections.Generic;
using System.Text;
using JasonsMedRef.Models;
using JasonsMedRef.Models.Enums;
using System.Linq;
using JasonsMedRef.Importer.Maps;
using PharmaClass = JasonsMedRef.Models.PharmaClass;

namespace JasonsMedRef.Importer.Importers
{
    public class ImporterCache
    {
        private static readonly Lazy<ImporterCache> lazy =
            new Lazy<ImporterCache>(() => new ImporterCache());

        public static ImporterCache Instance
        {
            get { return lazy.Value; }
        }

        private ImporterCache()
        {
            Initialize();
        }

        private void Initialize()
        {
        }

        public Dictionary<string, PharmaClass> PharmaClasses { get; set; } =
            new Dictionary<string, PharmaClass>();

        public Dictionary<ImporterCacheKeyDrug, Drug> Drugs { get; set; } =
            new Dictionary<ImporterCacheKeyDrug, Drug>();

        public Dictionary<ImporterCacheKeyApplication, Guid> AppToDrug { get; set; } =
            new Dictionary<ImporterCacheKeyApplication, Guid>();

        public Dictionary<ImporterCacheKeyApplication, Guid> AppToApp { get; set; } =
            new Dictionary<ImporterCacheKeyApplication, Guid>();

        public List<Application> Apps { get; set; } =
            new List<Application>();

        public List<Patent> Patents { get; set; } =
            new List<Patent>();

        public Dictionary<string, Guid> NdcProductIdToDrug { get; set; } =
            new Dictionary<string, Guid>();

        public List<Exclusivity> Exclusivities { get; set; } =
            new List<Exclusivity>();

        public List<Package> Packages { get; set; } =
            new List<Package>();

        public Dictionary<string, Guid> NdcToDrug { get; set; } =
            new Dictionary<string, Guid>();

        public Dictionary<string, Guid> NdcToPackage { get; set; } =
            new Dictionary<string, Guid>();

        public List<Nadac> Nadacs { get; set; } =
            new List<Nadac>();

        public List<FederalUpperLimit> Fuls { get; set; } =
            new List<FederalUpperLimit>();

        public Queue<StateDrugUtilization> SDUs { get; set; } =
            new Queue<StateDrugUtilization>();

        public Dictionary<string, Ndc_ProductForPackageInfo> ProductForPackage { get; set; } =
            new Dictionary<string, Ndc_ProductForPackageInfo>();

        public void CacheProductForPackageInfo(string key, string labeler, string appNo)
        {
            if (!ProductForPackage.ContainsKey(key))
            {
                ProductForPackage.Add(key,
                    new Ndc_ProductForPackageInfo { LabelerName = labeler, ApplicationNumber = appNo });
            }
        }

        public void AddOrUpdate(StateDrugUtilization sdu, string ndc)
        {
            Guid ndcId, drugId;
            if (NdcToDrug.TryGetValue(ndc, out drugId) && NdcToPackage.TryGetValue(ndc, out ndcId))
            {
                sdu.PackageId = ndcId;
                sdu.DrugId = drugId;
                sdu.Id = Guid.NewGuid();
                SDUs.Enqueue(sdu);
            }
        }

        public void AddOrUpdate(Nadac n, string ndc)
        {
            Guid ndcId, drugId;
            if (NdcToDrug.TryGetValue(ndc, out drugId) && NdcToPackage.TryGetValue(ndc, out ndcId))
            {
                n.PackageId = ndcId;
                n.DrugId = drugId;
                n.Id = Guid.NewGuid();
                Nadacs.Add(n);
            }
        }

        public void AddOrUpdate(FederalUpperLimit ful, string ndc)
        {
            Guid ndcId, drugId;
            if (NdcToDrug.TryGetValue(ndc, out drugId) && NdcToPackage.TryGetValue(ndc, out ndcId))
            {
                ful.Id = Guid.NewGuid();
                ful.PackageId = ndcId;
                ful.DrugId = drugId;
                Fuls.Add(ful);
            }
        }

        public void AddOrUpdate(PharmaClass pc)
        {
            if (!PharmaClasses.ContainsKey(pc.Name))
            {
                pc.Id = Guid.NewGuid();
                PharmaClasses.Add(pc.Name, pc);
            }
        }

        public void AddOrUpdate(Package p, string ndcProductId)
        {
            Guid g;
            if (NdcProductIdToDrug.TryGetValue(ndcProductId, out g))
            {
                p.Id = Guid.NewGuid();
                p.DrugId = g;

                Ndc_ProductForPackageInfo ppi;
                if (ProductForPackage.TryGetValue(ndcProductId, out ppi))
                {
                    p.LabelerName = ppi.LabelerName;
                    p.ApplicationNumber = ppi.ApplicationNumber;
                }

                Packages.Add(p);
                string ndc = StringFunctions.ConvertToNdc11(p.Ndc);
                if (!NdcToDrug.ContainsKey(ndc) && !NdcToPackage.ContainsKey(ndc))
                {
                    NdcToDrug.Add(ndc, g);
                    NdcToPackage.Add(ndc, p.Id);
                }
            }
        }

        public void AddOrUpdate(Drug d, Application app, string ndcKey)
        {
            Guid g = AddOrUpdate(d, app);
            if (ndcKey != null && !NdcProductIdToDrug.ContainsKey(ndcKey))
            {
                NdcProductIdToDrug.Add(ndcKey, g);
            }
        }

        public Guid AddOrUpdate(Drug d, Application app)
        {
            var drugKey = new ImporterCacheKeyDrug
            {
                Ingredient = d.Ingredient,
                DosageForm = d.DosageForm,
                DrugType = d.DrugType,
                Route = d.RouteOfAdmin
            };

            Drug dMemory;
            Guid drugId;
            if (Drugs.TryGetValue(drugKey, out dMemory))
            {
                dMemory.PharmaClassesText =
                    dMemory.PharmaClassesText.Concat(d.PharmaClassesText).Distinct().ToList();
                dMemory.PharmaClasses = dMemory.PharmaClasses.Concat(
                    PharmaClasses.Where(x => d.PharmaClassesText.Any(y => y == x.Key)).Select(x => x.Value.Id).ToList()
                ).Distinct().ToList();
                dMemory.Strengths = dMemory.Strengths.Concat(d.Strengths).Distinct().ToList();
                dMemory.TradeNames = dMemory.TradeNames.Concat(d.TradeNames).Distinct().ToList();

                if (dMemory.Schedule == null)
                    dMemory.Schedule = d.Schedule;

                if (dMemory.StartMarketingDate != null && d.StartMarketingDate.HasValue &&
                    d.StartMarketingDate < dMemory.StartMarketingDate)
                    dMemory.StartMarketingDate = d.StartMarketingDate;
                else
                    dMemory.StartMarketingDate = d.StartMarketingDate;

                drugId = dMemory.Id;
            }
            else
            {
                d.Id = Guid.NewGuid();
                drugId = d.Id;
                d.PharmaClasses = PharmaClasses.Where(x => d.PharmaClassesText.Any(y => y == x.Key)).Select(x => x.Value.Id).ToList();
                Drugs.Add(drugKey, d);
            }

            if (app != null)
            {
                app.DrugId = drugId;

                ImporterCacheKeyApplication appKey = new ImporterCacheKeyApplication
                {
                    AppNo = app.ApplicationNumber,
                    ProductNo = app.ProductNumber
                };

                if (!AppToDrug.ContainsKey(appKey))
                {
                    app.Id = Guid.NewGuid();
                    AppToDrug.Add(appKey, drugId);
                    AppToApp.Add(appKey, app.Id);
                    Apps.Add(app);
                }
            }

            return drugId;
        }

        public void AddOrUpdate(Exclusivity exc, string appNo, string productNo)
        {
            ImporterCacheKeyApplication key = new ImporterCacheKeyApplication
            {
                AppNo = appNo,
                ProductNo = productNo
            };

            Guid appId, drugId;

            if (AppToApp.TryGetValue(key, out appId) && AppToDrug.TryGetValue(key, out drugId))
            {
                exc.Id = Guid.NewGuid();
                exc.ApplicationId = appId;
                exc.DrugId = drugId;
                Exclusivities.Add(exc);
            }
        }

        public void AddOrUpdate(Patent p, string appNo, string productNo)
        {
            ImporterCacheKeyApplication key = new ImporterCacheKeyApplication
            {
                AppNo = appNo,
                ProductNo = productNo
            };

            Guid appId, drugId;

            if (AppToApp.TryGetValue(key, out appId) && AppToDrug.TryGetValue(key, out drugId))
            {
                p.Id = Guid.NewGuid();
                p.ApplicationId = appId;
                p.DrugId = drugId;
                Patents.Add(p);
            }
        }
    }

    public class ImporterCacheKeyApplication : IEquatable<ImporterCacheKeyApplication>
    {
        public string AppNo { get; set; }
        public string ProductNo { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as ImporterCacheKeyApplication);
        }

        public bool Equals(ImporterCacheKeyApplication other)
        {
            return other != null &&
                   AppNo == other.AppNo &&
                   ProductNo == other.ProductNo;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AppNo, ProductNo);
        }
    }

    public class ImporterCacheKeyDrug : IEquatable<ImporterCacheKeyDrug>
    {
        public string Ingredient { get; set; }
        public RouteOfAdministration? Route { get; set; }
        public DosageForm? DosageForm { get; set; }
        public DrugType? DrugType { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as ImporterCacheKeyDrug);
        }

        public bool Equals(ImporterCacheKeyDrug other)
        {
            return other != null &&
                   Ingredient.ToLowerInvariant() == other.Ingredient.ToLowerInvariant() &&
                   EqualityComparer<RouteOfAdministration?>.Default.Equals(Route, other.Route) &&
                   EqualityComparer<DosageForm?>.Default.Equals(DosageForm, other.DosageForm) &&
                   EqualityComparer<DrugType?>.Default.Equals(DrugType, other.DrugType);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Ingredient.ToLower(), Route, DosageForm, DrugType);
        }
    }
}
