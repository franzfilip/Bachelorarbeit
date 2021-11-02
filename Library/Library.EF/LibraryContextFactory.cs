using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Library.EF {
    class LibraryContextFactory: IDbContextFactory<LibraryContext> {
        private const string DEFAULT_DB_CONNECTION_STRING = @"Server = (localdb)\mssqllocaldb; Database = LibraryDB; Trusted_Connection = True";
        public LibraryContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>().UseSqlServer(DEFAULT_DB_CONNECTION_STRING);
            var context = new LibraryContext(optionsBuilder.Options);
            return context;
        }
    }
}
