using System;

namespace DataImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            Importer importer = new Importer(@"C:\Users\Franz-Filip\Downloads\classics.csv");

            var data = importer.getDataFromCsv();
        }
    }
}
