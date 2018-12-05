using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JasonsMedRef.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace JasonsMedRef.Web.Controllers
{
    public class SearchController : Controller
    {
        private ISearchRepo _repo;
        private AspNetCoreConfig _config;

        public SearchController(IOptions<AspNetCoreConfig> config, ISearchRepo repo)
        {
            _repo = repo;
            _config = config.Value;
            _repo.Initialize(_config);
        }

        public IActionResult RxSearch(string rxSearchString)
        {
            RxSearchResultModel vm = new RxSearchResultModel();
            vm.SearchInput = rxSearchString;
            vm.Results = _repo.SearchEngine.SearchDrugs(rxSearchString, 250);
            return View(vm);
        }

        public IActionResult RxDetail(Guid drugId)
        {
            return View(_repo.SearchEngine.GetDrugById(drugId));
        }

        public IActionResult FulDetail(Guid drugId)
        {
            return PartialView(_repo.SearchEngine.GetFulByDrugId(drugId));
        }

        public IActionResult NadacDetail(Guid drugId)
        {
            return PartialView(_repo.SearchEngine.GetNadacByDrugId(drugId));
        }

        public IActionResult SduDetail(Guid drugId)
        {
            return PartialView(_repo.SearchEngine.GetSduByDrugId(drugId));
        }

        public IActionResult PatentDetail(Guid drugID)
        {
            return PartialView(_repo.SearchEngine.GetPatentsByDrugId(drugID));
        }

        public IActionResult ApplicationDetail(Guid drugID)
        {
            return PartialView(_repo.SearchEngine.GetApplicationsByDrugId(drugID));
        }

        public IActionResult PackageDetail(Guid drugID)
        {
            return PartialView(_repo.SearchEngine.GetPackagesByDrugId(drugID));
        }
    }
}