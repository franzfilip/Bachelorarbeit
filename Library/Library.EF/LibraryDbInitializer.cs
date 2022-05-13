using Library.Datamodel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.EF {
    public class LibraryDbInitializer {
        public void Seed(ModelBuilder modelBuilder) {
            AddRoleData(modelBuilder);
            AddUserData(modelBuilder);
            AddRoleUserData(modelBuilder);
            AddBookData(modelBuilder);
            AddAuthorData(modelBuilder);
            AddBookAuthorData(modelBuilder);
            AddReviewData(modelBuilder);
        }

        private static void AddReviewData(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Review>().HasData(new[] {
                new Review { 
                    Id = 1,
                    UserId = 3,
                    BookId = 1,
                    Rating = 7
                },
                new Review {
                    Id = 2,
                    UserId = 4,
                    BookId = 1,
                    Rating = 9
                },
                new Review {
                    Id = 3,
                    UserId = 5,
                    BookId = 1,
                    Rating = 7
                },
                new Review {
                    Id = 4,
                    UserId = 3,
                    BookId = 1,
                    Rating = 1
                }
            });
        }

        private static void AddBookAuthorData(ModelBuilder modelBuilder) {
            modelBuilder
                    .Entity<Book>()
                    .HasMany(b => b.Authors)
                    .WithMany(a => a.Books)
                    .UsingEntity(a => a.HasData(new[] {
                        new { BooksId = 1, AuthorsId= 1 },
                        new { BooksId = 2, AuthorsId= 1 },
                        new { BooksId = 3, AuthorsId= 1 },
                        new { BooksId = 4, AuthorsId= 1 },
                        new { BooksId = 5, AuthorsId= 1 },
                        new { BooksId = 6, AuthorsId= 1 },
                        new { BooksId = 7, AuthorsId= 1 },
                        new { BooksId = 8, AuthorsId= 2 },
                        new { BooksId = 9, AuthorsId= 3 },
                        new { BooksId = 10, AuthorsId= 4 },
                    }));
        }

        private static void AddAuthorData(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Author>().HasData(new[] {
                new Author {
                    Id = 1,
                    FirstName = "JK",
                    LastName = "Rowling"
                },
                new Author {
                    Id = 2,
                    FirstName = "David Richard",
                    LastName = "Precht"
                },
                new Author {
                    Id = 3,
                    FirstName = "Sigmund",
                    LastName = "Freud"
                },
                new Author {
                    Id = 4,
                    FirstName = "Johann Christoph",
                    LastName = "Gotscheid"
                },
                new Author {
                    Id = 5,
                    FirstName = "Johann Jakob",
                    LastName = "Breitinger"
                }
            });
        }

        private static void AddBookData(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Book>().HasData(new[] {
                new Book {
                    Id = 1,
                    Title = "Harry Potter und der Stein der Weisen"
                },
                new Book {
                    Id = 2,
                    Title = "Harry Potter und die Kammer des Schreckens"
                },
                new Book {
                    Id = 3,
                    Title = "Harry Potter und der Gefangene von Askaban"
                },
                new Book {
                    Id = 4,
                    Title = "Harry Potter und der Feuerkelch"
                },
                new Book {
                    Id = 5,
                    Title = "Harry Potter und der Orden des Phönix"
                },
                new Book {
                    Id = 6,
                    Title = "Harry Potter und der Halbblutprinz"
                },
                new Book {
                    Id = 7,
                    Title = "Harry Potter und die Heiligtümer des Todes"
                },
                new Book {
                    Id = 8,
                    Title = "Buch 1"
                },
                new Book {
                    Id = 9,
                    Title = "Buch 2"
                },
                new Book {
                    Id = 10,
                    Title = "Buch 3"
                },
                new Book {
                    Id = 11,
                    Title = "Buch 4"
                }
            });
        }

        private static void AddRoleUserData(ModelBuilder modelBuilder) {
            modelBuilder
                    .Entity<User>()
                    .HasMany(u => u.Roles)
                    .WithMany(r => r.Users)
                    .UsingEntity(a => a.HasData(new[] {
                        new { UsersId = 1, RolesId = 1 },
                        new { UsersId = 2, RolesId = 2 },
                        new { UsersId = 3, RolesId = 3 },
                        new { UsersId = 4, RolesId = 3 },
                        new { UsersId = 5, RolesId = 3 }
                    }));
        }

        private static void AddUserData(ModelBuilder modelBuilder) {
            modelBuilder.Entity<User>().HasData(new User {
                Id = 1,
                Email = "admin@library.com",
                FirstName = "Franz-Filip",
                LastName = "Schörghuber",
                Password = "$2a$11$wohjURg/MX3fUDB.l469fOTJAprrUs5y54a4iS9BmeuQ47nAxLhj."
            });

            modelBuilder.Entity<User>().HasData(new User {
                Id = 2,
                Email = "librarian@library.com",
                FirstName = "Maxine",
                LastName = "Musterfrau",
                Password = "$2a$11$wohjURg/MX3fUDB.l469fOTJAprrUs5y54a4iS9BmeuQ47nAxLhj.",
            });

            modelBuilder.Entity<User>().HasData(new User {
                Id = 3,
                Email = "max.mustermann@gmail.com",
                FirstName = "Max",
                LastName = "Mustermann",
                Password = "$2a$11$wohjURg/MX3fUDB.l469fOTJAprrUs5y54a4iS9BmeuQ47nAxLhj.",
            });

            modelBuilder.Entity<User>().HasData(new User {
                Id = 4,
                Email = "franz.klammer@gmail.com",
                FirstName = "Franz",
                LastName = "Klammer",
                Password = "$2a$11$wohjURg/MX3fUDB.l469fOTJAprrUs5y54a4iS9BmeuQ47nAxLhj.",
            });

            modelBuilder.Entity<User>().HasData(new User {
                Id = 5,
                Email = "david.schönmann@gmail.com",
                FirstName = "David",
                LastName = "Schönmann",
                Password = "$2a$11$wohjURg/MX3fUDB.l469fOTJAprrUs5y54a4iS9BmeuQ47nAxLhj.",
            });
        }

        private static void AddRoleData(ModelBuilder modelBuilder) {
            modelBuilder
                .Entity<Role>().HasData(
                    new Role {
                        Id = 1,
                        Name = "Admin"
                    },
                    new Role {
                        Id = 2,
                        Name = "Librarian"
                    },
                    new Role {
                        Id = 3,
                        Name = "User"
                    });
        }
    }
}
