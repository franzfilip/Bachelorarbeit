﻿// <auto-generated />
using Library.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Library.EF.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20220509174328_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.Property<int>("AuthorsId")
                        .HasColumnType("int");

                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.HasKey("AuthorsId", "BooksId");

                    b.HasIndex("BooksId");

                    b.ToTable("AuthorBook");

                    b.HasData(
                        new
                        {
                            AuthorsId = 1,
                            BooksId = 1
                        },
                        new
                        {
                            AuthorsId = 1,
                            BooksId = 2
                        },
                        new
                        {
                            AuthorsId = 1,
                            BooksId = 3
                        },
                        new
                        {
                            AuthorsId = 1,
                            BooksId = 4
                        },
                        new
                        {
                            AuthorsId = 1,
                            BooksId = 5
                        },
                        new
                        {
                            AuthorsId = 1,
                            BooksId = 6
                        },
                        new
                        {
                            AuthorsId = 1,
                            BooksId = 7
                        },
                        new
                        {
                            AuthorsId = 2,
                            BooksId = 8
                        },
                        new
                        {
                            AuthorsId = 3,
                            BooksId = 9
                        },
                        new
                        {
                            AuthorsId = 4,
                            BooksId = 10
                        });
                });

            modelBuilder.Entity("Library.Datamodel.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "JK",
                            LastName = "Rowling"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "David Richard",
                            LastName = "Precht"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Sigmund",
                            LastName = "Freud"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Johann Christoph",
                            LastName = "Gotscheid"
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "Johann Jakob",
                            LastName = "Breitinger"
                        });
                });

            modelBuilder.Entity("Library.Datamodel.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Harry Potter und der Stein der Weisen"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Harry Potter und die Kammer des Schreckens"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Harry Potter und der Gefangene von Askaban"
                        },
                        new
                        {
                            Id = 4,
                            Title = "Harry Potter und der Feuerkelch"
                        },
                        new
                        {
                            Id = 5,
                            Title = "Harry Potter und der Orden des Phönix"
                        },
                        new
                        {
                            Id = 6,
                            Title = "Harry Potter und der Halbblutprinz"
                        },
                        new
                        {
                            Id = 7,
                            Title = "Harry Potter und die Heiligtümer des Todes"
                        },
                        new
                        {
                            Id = 8,
                            Title = "Buch 1"
                        },
                        new
                        {
                            Id = 9,
                            Title = "Buch 2"
                        },
                        new
                        {
                            Id = 10,
                            Title = "Buch 3"
                        },
                        new
                        {
                            Id = 11,
                            Title = "Buch 4"
                        });
                });

            modelBuilder.Entity("Library.Datamodel.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            Rating = 7,
                            UserId = 3
                        },
                        new
                        {
                            Id = 2,
                            BookId = 1,
                            Rating = 9,
                            UserId = 4
                        },
                        new
                        {
                            Id = 3,
                            BookId = 1,
                            Rating = 7,
                            UserId = 5
                        },
                        new
                        {
                            Id = 4,
                            BookId = 1,
                            Rating = 1,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("Library.Datamodel.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Librarian"
                        },
                        new
                        {
                            Id = 3,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("Library.Datamodel.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@library.com",
                            FirstName = "Franz-Filip",
                            LastName = "Schörghuber",
                            Password = "$2a$11$wohjURg/MX3fUDB.l469fOTJAprrUs5y54a4iS9BmeuQ47nAxLhj."
                        },
                        new
                        {
                            Id = 2,
                            Email = "librarian@library.com",
                            FirstName = "Maxine",
                            LastName = "Musterfrau",
                            Password = "$2a$11$wohjURg/MX3fUDB.l469fOTJAprrUs5y54a4iS9BmeuQ47nAxLhj."
                        },
                        new
                        {
                            Id = 3,
                            Email = "max.mustermann@gmail.com",
                            FirstName = "Max",
                            LastName = "Mustermann",
                            Password = "$2a$11$wohjURg/MX3fUDB.l469fOTJAprrUs5y54a4iS9BmeuQ47nAxLhj."
                        },
                        new
                        {
                            Id = 4,
                            Email = "franz.klammer@gmail.com",
                            FirstName = "Franz",
                            LastName = "Klammer",
                            Password = "$2a$11$wohjURg/MX3fUDB.l469fOTJAprrUs5y54a4iS9BmeuQ47nAxLhj."
                        },
                        new
                        {
                            Id = 5,
                            Email = "david.schönmann@gmail.com",
                            FirstName = "David",
                            LastName = "Schönmann",
                            Password = "$2a$11$wohjURg/MX3fUDB.l469fOTJAprrUs5y54a4iS9BmeuQ47nAxLhj."
                        });
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<int>("RolesId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RoleUser");

                    b.HasData(
                        new
                        {
                            RolesId = 1,
                            UsersId = 1
                        },
                        new
                        {
                            RolesId = 2,
                            UsersId = 2
                        },
                        new
                        {
                            RolesId = 3,
                            UsersId = 3
                        },
                        new
                        {
                            RolesId = 3,
                            UsersId = 4
                        },
                        new
                        {
                            RolesId = 3,
                            UsersId = 5
                        });
                });

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.HasOne("Library.Datamodel.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Datamodel.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Library.Datamodel.Review", b =>
                {
                    b.HasOne("Library.Datamodel.Book", "Book")
                        .WithMany("Reviews")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Datamodel.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("Library.Datamodel.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Datamodel.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Library.Datamodel.Book", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Library.Datamodel.User", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
