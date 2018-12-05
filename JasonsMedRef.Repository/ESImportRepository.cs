using System;
using System.Collections.Generic;
using System.Text;
using JasonsMedRef.Models;
using Nest;
using System.Linq;
using System.Threading.Tasks;
using JasonsMedRef.Models.Enums;

namespace JasonsMedRef.Repository
{
    public class ESImportRepository
    {
        private static readonly Lazy<ESImportRepository> lazy =
            new Lazy<ESImportRepository>(() => new ESImportRepository());

        static Uri _nodeLocation;
        static ConnectionSettings _settings;
        static IndexNameResolver _resolver;
        private ElasticClient _client;

        public static ESImportRepository Instance
        {
            get { return lazy.Value; }
        }

        private ESImportRepository()
        {
        }

        #region Initialization
        public void Initialize(string serverUri)
        {
            _nodeLocation = new Uri(serverUri);
            _settings = new ConnectionSettings(_nodeLocation)
                .DefaultMappingFor<Drug>(m => m.IndexName(Drug.IndexName)
                    .IdProperty("Id"))
                .DefaultMappingFor<Application>(m => m.IndexName(Application.IndexName)
                    .IdProperty("Id"))
                .DefaultMappingFor<Exclusivity>(m => m.IndexName(Exclusivity.IndexName)
                    .IdProperty("Id"))
                .DefaultMappingFor<FederalUpperLimit>(m => m.IndexName(FederalUpperLimit.IndexName)
                    .IdProperty("Id"))
                .DefaultMappingFor<Nadac>(m => m.IndexName(Nadac.IndexName)
                    .IdProperty("Id"))
                .DefaultMappingFor<Package>(m => m.IndexName(Package.IndexName)
                    .IdProperty("Id"))
                .DefaultMappingFor<Patent>(m => m.IndexName(Patent.IndexName)
                    .IdProperty("Id"))
                .DefaultMappingFor<PharmaClass>(m => m.IndexName(PharmaClass.IndexName)
                    .IdProperty("Id"))
                .DefaultMappingFor<StateDrugUtilization>(m => m.IndexName(StateDrugUtilization.IndexName)
                    .IdProperty("Id"));

            _resolver = new IndexNameResolver(_settings);
            _client = new ElasticClient(_settings);

            Indices.ManyIndices indexesToDelete = Indices.Index(
                Drug.IndexName,
                Application.IndexName,
                Exclusivity.IndexName,
                FederalUpperLimit.IndexName,
                Nadac.IndexName,
                Package.IndexName,
                Patent.IndexName,
                PharmaClass.IndexName,
                StateDrugUtilization.IndexName
                );

            _client.DeleteIndex(indexesToDelete);

            _client.CreateIndex(Drug.IndexName,
                x => x.Settings(s => s.NumberOfShards(3))
                    .Mappings(m => m
                        .Map<Drug>(mt => mt.AutoMap())));
            _client.CreateIndex(Application.IndexName,
                x => x.Settings(s => s.NumberOfShards(3))
                .Mappings(m => m
                        .Map<Application>(mt => mt.AutoMap()))
                    );
            _client.CreateIndex(Exclusivity.IndexName,
                x => x.Settings(s => s.NumberOfShards(3))
                .Mappings(m => m
                        .Map<Exclusivity>(mt => mt.AutoMap()))
                    );
            _client.CreateIndex(FederalUpperLimit.IndexName,
                x => x.Settings(s => s.NumberOfShards(3))
                .Mappings(m => m
                        .Map<FederalUpperLimit>(mt => mt.AutoMap()))
                    );
            _client.CreateIndex(Nadac.IndexName,
                x => x.Settings(s => s.NumberOfShards(3))
                .Mappings(m => m
                        .Map<Nadac>(mt => mt.AutoMap()))
                    );
            _client.CreateIndex(Package.IndexName,
                x => x.Settings(s => s.NumberOfShards(3))
                .Mappings(m => m
                        .Map<Package>(mt => mt.AutoMap()))
                    );
            _client.CreateIndex(Patent.IndexName,
                x => x.Settings(s => s.NumberOfShards(3))
                .Mappings(m => m
                        .Map<Patent>(mt => mt.AutoMap()))
                    );
            _client.CreateIndex(PharmaClass.IndexName,
                x => x.Settings(s => s.NumberOfShards(3))
                .Mappings(m => m
                        .Map<PharmaClass>(mt => mt.AutoMap()))
                );
            _client.CreateIndex(StateDrugUtilization.IndexName,
                x => x.Settings(s => s.NumberOfShards(3))
                    .Mappings(m => m
                        .Map<StateDrugUtilization>(mt => mt.AutoMap()))
            );

        }
        #endregion

        #region OLD

        //public async Task<Guid> Add(Drug drug)
        //{
        //    var added = await _client.IndexDocumentAsync<Drug>(drug);
        //    return new Guid(added.Id);
        //}

        //public async Task<Guid> Add(Application app)
        //{
        //    var added = await _client.IndexDocumentAsync<Application>(app);
        //    return new Guid(added.Id);
        //}

        //public async Task<Guid> Add(PharmaClass pClass)
        //{
        //    var added = await _client.IndexDocumentAsync<PharmaClass>(pClass);
        //    return new Guid(added.Id);
        //}

        //public async Task<Guid> AddOrUpdate(PharmaClass record)
        //{
        //    //_client.Get<PharmaClass>(new GetRequest<PharmaClass>(PharmaClass.IndexName, PharmaClass.IndexName, GUID));
        //    var response = _client.Search<PharmaClass>(sr => sr
        //        .Query(q => q
        //            .Term(t => t
        //                .Field(f => f.Name.Suffix("keyword"))
        //                .Value(record.Name)
        //                .Strict()
        //            )
        //        ));

        //    if (response.Documents.Count > 0)
        //    {
        //        return response.Documents.First().Id;
        //    }
        //    else
        //    {
        //        record.Id = Guid.NewGuid();
        //        var pClass = await _client.IndexDocumentAsync<PharmaClass>(record);
        //        return new Guid(pClass.Id);
        //    }
        //}

        //public async Task<Guid> AddOrUpdate(Drug record)
        //{
        //    var response = _client.Search<Drug>(sr => sr
        //        .Query(q => q
        //            .Term( t => t.Ingredient.Suffix("keyword"), record.Ingredient) &&  q
        //            .Term( t => t.DosageForm, record.DosageForm) && q
        //            .Term( t => t.RouteOfAdmin, record.RouteOfAdmin) && q
        //            .Term( t => t.DrugType, record.DrugType)

        //        )
        //    );

        //    if (response.Documents.Count > 0)
        //    {
        //        var dbRec = response.Documents.First();

        //        //if (record.DrugType == DrugType.Discontinued)
        //        //{
        //        //    await _client.DeleteAsync<Drug>(dbRec);
        //        //    await _client.DeleteByQueryAsync<Application>(s => s
        //        //        .Query(q => q
        //        //            .Term(t => t.DrugId, dbRec.Id))
        //        //    );
        //        //    await _client.DeleteByQueryAsync<Exclusivity>(s => s
        //        //        .Query(q => q
        //        //            .Term(t => t.DrugId, dbRec.Id))
        //        //    );
        //        //    await _client.DeleteByQueryAsync<Patent>(s => s
        //        //        .Query(q => q
        //        //            .Term(t => t.DrugId, dbRec.Id))
        //        //    );
        //        //    await _client.DeleteByQueryAsync<FederalUpperLimit>(s => s
        //        //        .Query(q => q
        //        //            .Term(t => t.DrugId, dbRec.Id))
        //        //    );
        //        //    await _client.DeleteByQueryAsync<Nadac>(s => s
        //        //        .Query(q => q
        //        //            .Term(t => t.DrugId, dbRec.Id))
        //        //    );
        //        //}
        //        //else
        //        //{
        //            if (record.StartMarketingDate.HasValue)
        //            {
        //                if (dbRec.StartMarketingDate == null)
        //                    dbRec.StartMarketingDate = record.StartMarketingDate;
        //                else if (record.StartMarketingDate < dbRec.StartMarketingDate)
        //                {
        //                    dbRec.StartMarketingDate = record.StartMarketingDate;
        //                }
        //            }

        //            dbRec.PharmaClassesText =
        //                dbRec.PharmaClassesText.Concat(record.PharmaClassesText).Distinct().ToList();
        //            dbRec.TradeNames = dbRec.TradeNames.Concat(record.TradeNames).Distinct().ToList();
        //            dbRec.Strengths = dbRec.Strengths.Concat(record.Strengths).Distinct().ToList();

        //            if (record.PharmaClassesText.Count > 0)
        //            {
        //                var foundPharmaClasses = await _client.SearchAsync<PharmaClass>(s => s
        //                    .Query(q => q
        //                        .Terms(ts => ts
        //                            .Field(f => f.Name.Suffix("keyword"))
        //                            .Terms<string>(dbRec.PharmaClassesText)
        //                        )
        //                    )
        //                );

        //                dbRec.PharmaClasses = dbRec.PharmaClasses.Concat(foundPharmaClasses.Documents.Select(x => x.Id)).Distinct().ToList();
        //            }

        //            await _client.IndexDocumentAsync<Drug>(dbRec);
        //        //}

        //        return dbRec.Id;
        //    }
        //    else
        //    {
        //        //if (record.DrugType == DrugType.Discontinued)
        //        //    return Guid.Empty;

        //        record.Id = Guid.NewGuid();

        //        if (record.PharmaClassesText.Count > 0)
        //        {
        //            var foundPharmaClasses = await _client.SearchAsync<PharmaClass>(s => s
        //                .Query(q => q
        //                    .Terms(ts => ts
        //                        .Field(f => f.Name.Suffix("keyword"))
        //                        .Terms<string>(record.PharmaClassesText)
        //                    )
        //                )
        //            );

        //            record.PharmaClasses = foundPharmaClasses.Documents.Select(x => x.Id).ToList();
        //        }

        //        var drug = await _client.IndexDocumentAsync<Drug>(record);
        //        return new Guid(drug.Id);
        //    }
        //}

        //public async Task<Guid> AddOrUpdate(Application app)
        //{
        //    var response = _client.Search<Application>(sr => sr
        //        .Query(q => q
        //            .Term(t => t.DrugId, app.DrugId) && q
        //            .Term(t => t.ApplicationNumber.Suffix("keyword"), app.ApplicationNumber)
        //        )
        //    );

        //    if (response.Documents.Count > 0)
        //    {
        //        var doc = response.Documents.First();
        //        return doc.Id;
        //    }
        //    else
        //    {
        //        app.Id = Guid.NewGuid();
        //        var newDoc = await _client.IndexDocumentAsync<Application>(app);
        //        return new Guid(newDoc.Id);
        //    }

        //}

        //public async Task<int> DeleteAllExclusivity()
        //{
        //    await _client.DeleteByQueryAsync<Exclusivity>(r => r
        //        .Query(q => q.QueryString(qs => qs.Query("*"))));
        //    return 0;
        //}

        //public async Task<int> DeleteAllPatent()
        //{
        //    await _client.DeleteByQueryAsync<Patent>(r => r
        //        .Query(q => q.QueryString(qs => qs.Query("*"))));
        //    return 0;
        //}

        //public async Task<int> DeleteAllNadac()
        //{
        //    await _client.DeleteByQueryAsync<Nadac>(r => r
        //        .Query(q => q.QueryString(qs => qs.Query("*"))));
        //    return 0;
        //}

        //public async Task<int> DeleteAllFederalUpperLimit()
        //{
        //    await _client.DeleteByQueryAsync<FederalUpperLimit>(r => r
        //        .Query(q => q.QueryString(qs => qs.Query("*"))));
        //    return 0;
        //}

        //public async Task<Guid> AddOrUpdate(Exclusivity exclusivity)
        //{
        //    exclusivity.Id = Guid.NewGuid();
        //    var newDoc = await _client.IndexDocumentAsync<Exclusivity>(exclusivity);
        //    return new Guid(newDoc.Id);
        //}

        //public async Task<Guid> AddOrUpdate(Patent patent)
        //{
        //    patent.Id = Guid.NewGuid();
        //    var newDoc = await _client.IndexDocumentAsync<Patent>(patent);
        //    return new Guid(newDoc.Id);
        //}

        //public async Task<Guid> AddOrUpdate(Package p)
        //{
        //    var response = _client.Search<Package>(sr => sr
        //        .Query(q => q
        //            .Term(t => t.Ndc.Suffix("keyword"), p.Ndc)
        //        )
        //    );

        //    if (response.Documents.Count > 0)
        //    {
        //        var doc = response.Documents.First();
        //        return doc.Id;
        //    }
        //    else
        //    {
        //        p.Id = Guid.NewGuid();
        //        var newDoc = await _client.IndexDocumentAsync<Package>(p);
        //        return new Guid(newDoc.Id);
        //    }
        //}

        //public async Task<Guid> AddOrUpdate(Nadac nadac, string ndc)
        //{
        //    var response = _client.Search<Package>(sr => sr
        //        .Query(q => q
        //            .Term(t => t.Ndc.Suffix("keyword"), ndc)
        //        )
        //    );

        //    if (response.Documents.Count > 0)
        //    {
        //        var doc = response.Documents.First();
        //        nadac.DrugId = doc.DrugId;
        //        nadac.PackageId = doc.Id;
        //        nadac.Id = Guid.NewGuid();
        //        var newDoc = await _client.IndexDocumentAsync<Nadac>(nadac);
        //        return new Guid(newDoc.Id);
        //    }
        //    else
        //    {
        //        return Guid.Empty;
        //    }
        //}

        //public async Task<Guid> AddOrUpdate(FederalUpperLimit ful, string ndc)
        //{
        //    var response = _client.Search<Package>(sr => sr
        //        .Query(q => q
        //            .Term(t => t.Ndc.Suffix("keyword"), ndc)
        //        )
        //    );

        //    if (response.Documents.Count > 0)
        //    {
        //        var doc = response.Documents.First();
        //        ful.DrugId = doc.DrugId;
        //        ful.NdcId = doc.Id;
        //        ful.Id = Guid.NewGuid();
        //        var newDoc = await _client.IndexDocumentAsync<FederalUpperLimit>(ful);
        //        return new Guid(newDoc.Id);
        //    }
        //    else
        //    {
        //        return Guid.Empty;
        //    }
        //}
        #endregion

        public async Task<int> BulkAdd<T>(IEnumerable<T> list) where T : class
        {
            if(list.Count() > 0)
                await _client.IndexManyAsync<T>(list);
            return 0;
        }

        public async Task<int> ChunkedBulkAdd<T>(List<T> list) where T : class
        {
            Queue<T> queue = new Queue<T>(list);
            await ChunkedBulkAdd<T>(queue);
            return 0;
        }

        public async Task<int> ChunkedBulkAdd<T>(Queue<T> list) where T : class
        {
            List<T> tempList = new List<T>(2000);

            int i = 1;
            while(list.Count > 0)
            {
                tempList.Add(list.Dequeue());
                if (i % 2000 == 0 || list.Count == 1)
                {
                    await BulkAdd<T>(tempList);
                    tempList.Clear();

                    if (i % 10000 == 0)
                        list.TrimExcess();

                    i = 0;
                }

                ++i;
            }

            return 0;
        }
    }
}
