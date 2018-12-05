using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JasonsMedRef.Models;

namespace JasonsMedRef.Web.Models
{
    public class RxSearchResultModel
    {
        public string SearchInput { get; set; }
        public List<Drug> Results { get; set; }
    }
}
