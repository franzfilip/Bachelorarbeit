using System;
using System.Net;
using Library.Datamodel;
using Library.EF.Comparers;
using Microsoft.EntityFrameworkCore;

namespace Library.EF {
    public class LibraryContext : DbContext {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<User> Users { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            var converter = new EnumCollectionJsonValueConverter<Role>();
            var comparer = new CollectionValueComparer<Role>();

            modelBuilder.Entity<User>()
                .Property(e => e.Roles)
                .HasConversion(converter)
                .Metadata.SetValueComparer(comparer);

            base.OnModelCreating(modelBuilder);
        }

    }
}
