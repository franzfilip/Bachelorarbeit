using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter
{
    class BookStats
    {
        [Name("bibliography.title")]
        public string Title { get; set; }
        [Name("bibliography.subjects")]
        public string Subjects { get; set; }
        [Name("bibliography.author.name")]
        public string AuthorFullName { get; set; }
    }
}
