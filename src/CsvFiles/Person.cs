using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangfire_SQLite.CsvFiles
{
    public class Person
    {
        public string Id { get; set; }

        [Name("Name")]
        public string UserName { get; set; }

        public int Age { get; set; }

        public DateTime OpenTime { get; set; }
    }
}
