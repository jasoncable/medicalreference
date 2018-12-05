using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JasonsMedRef.Repository;

namespace JasonsMedRef.Web.Models
{
    public interface ISearchRepo
    {
        void Initialize(AspNetCoreConfig config);
        ESSearchRepository SearchEngine { get; set; }
    }
}
