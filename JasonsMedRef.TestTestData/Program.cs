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
using JasonsMedRef.Models.JsonModels;
using Newtonsoft.Json;

namespace JasonsMedRef.TestTestData
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonDrugs drugs = JasonsMedRef.TestData.Startup.LoadData();

            string line;
            JsonSerializer jsz = new JsonSerializer();
            jsz.Formatting = Formatting.Indented;

            while((line = Console.ReadLine()) != String.Empty)
            {
                var result =
                    drugs.Drugs.Where(x => x.Ingredient.Contains(line.Trim(), StringComparison.CurrentCultureIgnoreCase)).ToList();
                Console.WriteLine(JsonConvert.SerializeObject(result));
            }

            Console.WriteLine("Press ENTER to exit.");
            Console.ReadLine();
        }
    }
}
