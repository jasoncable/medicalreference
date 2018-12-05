using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JasonsMedRef.Repository;

namespace JasonsMedRef.Web.Models
{
    public class SearchRepo : ISearchRepo
    {
        public SearchRepo()
        {
        }

        public void Initialize(AspNetCoreConfig config)
        {
            if(SearchEngine == null)
            {
                SearchEngine = new ESSearchRepository();
                SearchEngine.Initialize(config.ServerUri);
            }
        }

        public ESSearchRepository SearchEngine { get; set; }
    }
}
