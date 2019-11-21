using Jaxosoft.TestData;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace Jaxosoft.TestTestData
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonDrugs drugs = Startup.LoadData();

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
