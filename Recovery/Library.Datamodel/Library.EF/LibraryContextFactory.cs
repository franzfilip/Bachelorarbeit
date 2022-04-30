using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.EF {
    public class LibraryContextFactory : IDesignTimeDbContextFactory<LibraryContext> {
        public LibraryContext CreateDbContext(string[] args) {
            var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = LibraryDB; Trusted_Connection = True");

            return new LibraryContext(optionsBuilder.Options);
        }
    }
}
