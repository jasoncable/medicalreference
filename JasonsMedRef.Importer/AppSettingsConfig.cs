using System;
using System.Collections.Generic;
using System.Text;

namespace JasonsMedRef.Importer
{
    public class AppSettingsConfig
    {
        public string WorkingFolder { get; set; }
        public ElasticSearchConfig ElasticSearch { get; set; }
        public List<SiteConfig> SiteConfigs { get; set; }
    }

    public class SiteConfig
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Uri { get; set; }
        public List<string> DownloadFiles { get; set; } = new List<string>();
    }

    public class ElasticSearchConfig
    {
        public string ServerUri { get; set; }
    }
}
