using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.CommandLine;
using System.Linq;
using JasonsMedRef.Importer.Importers;
using JasonsMedRef.Models;
using JasonsMedRef.Repository;
using System.Collections.Generic;
using JasonsMedRef.Importer.Exporters;
using NLog;

namespace JasonsMedRef.Importer
{
    class Program
    {
        internal static Logger Logger { get; set; }

        public static async Task<int> Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddCommandLine(args);
            IConfigurationRoot configuration = builder.Build();
            var config = configuration.GetSection("JMR").Get<AppSettingsConfig>();

            Logger = LogManager.GetCurrentClassLogger();
            Logger.Info("Logger Starting");

            try
            {
                // manually download until you can find a better HTTP client that supports FTP URIs
                await TimeExecutionAndLog("Pharma Class Import", async () =>
                {
                    await PharmaClassImporter.Import(config.WorkingFolder,
                    config.SiteConfigs.Single(x => x.ShortName == "PharmaClass"));
                });

                await TimeExecutionAndLog("Orange Book Import", async () =>
                {
                    await OrangeBookImporter.Import(config.WorkingFolder,
                    config.SiteConfigs.Single(x => x.ShortName == "ORANGEBOOK"));
                });

                await TimeExecutionAndLog("NDC Import", async () =>
                {
                    await NdcImporter.Import(config.WorkingFolder,
                    config.SiteConfigs.Single(x => x.ShortName == "NDC"));
                });

                await TimeExecutionAndLog("Formulary Export", async () =>
                {
                    await FormularyExporter.Export();
                });

                await TimeExecutionAndLog("JSON Export", async () =>
                {
                    await JsonExporter.Export(@"c:\temp\drugs.json");
                });

                //await NadacImporter.Import(config.WorkingFolder,
                //    config.SiteConfigs.Single(x => x.ShortName == "NADAC"));

                //await AcaFulImporter.Import(config.WorkingFolder,
                //    config.SiteConfigs.Single(x => x.ShortName == "FUL"));

                //await StateDrugUtilizationImporter.Import(config.WorkingFolder,
                //    config.SiteConfigs.Single(x => x.ShortName == "SDU"));

                /* Elastic Search Import

                ESImportRepository.Instance.Initialize(config.ElasticSearch.ServerUri);

                await ESImportRepository.Instance.ChunkedBulkAdd<PharmaClass>(ImporterCache.Instance.PharmaClasses
                    .Select(x => x.Value).ToList());

                ImporterCache.Instance.PharmaClasses.Clear();

                await ESImportRepository.Instance.ChunkedBulkAdd<Drug>(ImporterCache.Instance.Drugs
                    .Select(x => x.Value).ToList());

                ImporterCache.Instance.Drugs.Clear();

                await ESImportRepository.Instance.ChunkedBulkAdd<Package>(ImporterCache.Instance.Packages);

                ImporterCache.Instance.Packages.Clear();

                await ESImportRepository.Instance.ChunkedBulkAdd<Application>(ImporterCache.Instance.Apps);

                ImporterCache.Instance.Apps.Clear();

                await ESImportRepository.Instance.ChunkedBulkAdd<Exclusivity>(ImporterCache.Instance.Exclusivities);

                ImporterCache.Instance.Exclusivities.Clear();

                await ESImportRepository.Instance.ChunkedBulkAdd<Patent>(ImporterCache.Instance.Patents);

                ImporterCache.Instance.Patents.Clear();

                await ESImportRepository.Instance.ChunkedBulkAdd<FederalUpperLimit>(ImporterCache.Instance.Fuls);

                ImporterCache.Instance.Fuls.Clear();

                await ESImportRepository.Instance.ChunkedBulkAdd<Nadac>(ImporterCache.Instance.Nadacs);

                ImporterCache.Instance.Nadacs.Clear();

                await ESImportRepository.Instance.ChunkedBulkAdd<StateDrugUtilization>(ImporterCache.Instance.SDUs);
                */

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return 0;
        }

        public static async Task<bool> TimeExecutionAndLog(string description, Action action)
        {
            DateTime start = DateTime.Now;
            Logger.Debug($"Begin Invoke: {description}, {start.ToString("o")}");
            bool errored = false;

            try
            {
                action.Invoke();
            }
            catch (Exception exc)
            {
                Logger.Error(exc, $"ERROR in {description}!");
            }
            finally
            {
                DateTime end = DateTime.Now;
                Logger.Debug($"End Invoke:   {description}, {end.ToString("o")}");
                TimeSpan duration = end - start;
                Logger.Info($"Time to Run:  {description}, {(int)duration.TotalHours}h {duration.Minutes}m {duration.Seconds}s {duration.Milliseconds}ms");
            }

            return !errored;
        }
    }
}
