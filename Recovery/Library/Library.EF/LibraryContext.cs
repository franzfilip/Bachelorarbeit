using Library.Datamodel;
using Microsoft.EntityFrameworkCore;

namespace Library.EF {
    public class LibraryContext: DbContext {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Role> Roles { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

        }
    }
}