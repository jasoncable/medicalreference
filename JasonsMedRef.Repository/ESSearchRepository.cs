using System;
using System.Collections.Generic;
using System.Text;
using JasonsMedRef.Models;
using Nest;
using System.Linq;

namespace JasonsMedRef.Repository
{
    public class ESSearchRepository
    {
        private Uri _nodeLocation;
        private ConnectionSettings _settings;
        private IndexNameResolver _resolver;
        private ElasticClient _client;

        public ESSearchRepository()
        {
        }

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
        }

        public List<Drug> SearchDrugs(string searchString, int limit)
        {
            var result = _client.Search<Drug>(sr => sr
                .Query(q => q
                    .Bool( b => b
                        .MustNot( mn => mn
                            .Term( t=> t.DrugType, 0)))
                && ( q
                    .Match(m => m
                        .Field(f => f.Ingredient)
                        .Query(searchString)) 
                || q
                    .Match(m => m
                        .Field(f => f.TradeNames)
                        .Query(searchString) )
                    )
                )
                .Size(250)
            );

            return result.Documents.ToList();
        }

        public Drug GetDrugById(Guid drugId)
        {
            var result = _client.Search<Drug>(sr => sr
                .Query(q => q
                    .Ids(id => id
                        .Values(drugId))
                ));

            if (result.Documents.Count > 0)
                return result.Documents.First();
            else
                return null;
        }

        public List<FederalUpperLimit> GetFulByDrugId(Guid drugId)
        {
            var result = _client.Search<FederalUpperLimit>(sr => sr
                .Query(q => q
                    .Term(t => t.DrugId, drugId))
                .Size(250));

            if (result.Documents.Count == 0)
                return new List<FederalUpperLimit>();
            else
                return result.Documents.ToList();
        }

        public List<Nadac> GetNadacByDrugId(Guid drugId)
        {
            var result = _client.Search<Nadac>(sr => sr
                .Query(q => q
                    .Term(t => t.DrugId, drugId))
                .Size(250));

            if (result.Documents.Count == 0)
                return new List<Nadac>();
            else
                return result.Documents.ToList();
        }

        public List<StateDrugUtilization> GetSduByDrugId(Guid drugId)
        {
            var result = _client.Search<StateDrugUtilization>(sr => sr
                .Query(q => q
                    .Term(t => t.DrugId, drugId))
                .Size(5000));

            if (result.Documents.Count == 0)
            {
                return new List<StateDrugUtilization>();
            }
            else
            {
                return result.Documents.GroupBy(x => new {x.State, x.ReportDate})
                    .Select( x => new StateDrugUtilization
                    {
                        DrugId = drugId,
                        State = x.Key.State,
                        ReportDate = x.Key.ReportDate,
                        MedicaidAmountReimbursed = x.Sum( y => y.MedicaidAmountReimbursed ),
                        NonMedicaidAmountReimbursed = x.Sum( y=> y.NonMedicaidAmountReimbursed),
                        NumberOfScripts = x.Sum(y => y.NumberOfScripts),
                        TotalAmountReimbursed =x.Sum(y => y.TotalAmountReimbursed),
                        UnitsReimbursed = x.Sum( y => y.UnitsReimbursed)
                    }).ToList();

                //return result.Documents.ToList();
            }
        }

        public List<Patent> GetPatentsByDrugId(Guid drugId)
        {
            var result = _client.Search<Patent>(sr => sr
                .Query(q => q
                    .Term(t => t.DrugId, drugId))
                .Size(250));

            if (result.Documents.Count == 0)
                return new List<Patent>();
            else
                return result.Documents.ToList();
        }

        public List<Application> GetApplicationsByDrugId(Guid drugId)
        {
            var result = _client.Search<Application>(sr => sr
                .Query(q => q
                    .Term(t => t.DrugId, drugId))
                .Size(250));

            if (result.Documents.Count == 0)
                return new List<Application>();
            else
                return result.Documents.ToList();
        }

        public List<Package> GetPackagesByDrugId(Guid drugId)
        {
            var result = _client.Search<Package>(sr => sr
                .Query(q => q
                    .Term(t => t.DrugId, drugId))
                .Size(500));

            if (result.Documents.Count == 0)
                return new List<Package>();
            else
                return result.Documents.ToList();
        }
    }
}
