using CsvHelper;
using CsvHelper.Configuration;
using Hangfire_SQLite.Configuration;
using Hangfire_SQLite.CsvFiles;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Hangfire_SQLite.Managers
{
    public class CsvFileHandlerManager : ICsvFileHandlerManager
    {
        private readonly CsvFileHandlerJobConfig _csvFileJobConfiguration;
        private readonly ILogger _logger;

        private readonly string _csvFolder;

        public CsvFileHandlerManager(
            ILogger<CsvFileHandlerManager> logger,
            IOptions<CsvFileHandlerJobConfig> options)
        {
            _csvFileJobConfiguration = options.Value;
            _csvFolder = _csvFileJobConfiguration.CsvFileFolder;

            _logger = logger;
        }

        public void HandleCsvFiles()
        {
            IList<Person> persons = null;

            if (!Directory.Exists(_csvFolder))
            {
                _logger.LogError($"CSV Directory {_csvFolder} does not exist.");
                return;
            }

            IList<string> files = Directory.GetFiles(_csvFolder);

            foreach (var file in files)
            {
                if (!file.EndsWith(_csvFileJobConfiguration.CsvFileSuffix)) continue;

                using var reader = new StreamReader(file);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.Delimiter = _csvFileJobConfiguration.CsvFileDelimiter;
                csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.Trim();
                csv.Configuration.TrimOptions = TrimOptions.Trim;

                persons = csv.GetRecords<Person>().ToList();
            }

            _logger.LogDebug($"Got persons list: {JsonConvert.SerializeObject(persons)}");
        }
    }
}
