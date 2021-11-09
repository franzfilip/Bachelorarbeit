using CsvHelper;
using Library.Datamodel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter
{
    class Importer
    {
        private readonly string csvPath;

        public Importer(string path)
        {
            csvPath = path;
        }

        public List<BookStats> getDataFromCsv()
        {
            List<BookStats> records;

            using (var reader = new StreamReader(csvPath))
            using (CsvReader csv = new CsvReader(reader, System.Globalization.CultureInfo.CreateSpecificCulture("en")))
            {
                records = csv.GetRecords<BookStats>().ToList();
            }

            return records;
        }

        public void storeCsvIntoDatabase()
        {
            List<BookStats> bookStats = getDataFromCsv();
            List<Author> authors = new List<Author>();
            List<Book> books = new List<Book>();
            List<Subject> subjects = new List<Subject>();

            foreach (var record in bookStats)
            {
                var author = new Author { FirstName = record.AuthorFullName.Split(",")[0].Trim(), LastName = record.AuthorFullName.Split(",")[1].Trim() };
                
            }
        }
    }
}
