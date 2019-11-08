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
using Newtonsoft.Json;

namespace JasonsMedRef.Models.JsonModels
{
    public class JsonDrugs
    {
        public DateTime GeneratedDate { get; set; } = DateTime.UtcNow;
        public List<JsonDrug> Drugs { get; set; }
    }
}
