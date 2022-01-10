using Library.Datamodel;
using Library.EF;
using Library.GraphQL.GraphQLTypes.InputTypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.GraphQL.Mapping {
    public class AuthorMapper {
        private readonly LibraryContext _context;

        public AuthorMapper(IDbContextFactory<LibraryContext> libraryContextFactory) {
            _context = libraryContextFactory.CreateDbContext();
        }

        public async Task<Author> MapAuthorCreateToAuthor(AuthorCreate input) {
            Author author = new Author {
                FirstName = input.FirstName,
                LastName = input.LastName
            };

            if (input.Books is null) {
                author.Books = new List<Book>();
            }
            else {
                author.Books = await _context.Books.Where(a => input.Books.Any(id => id == a.Id)).ToListAsync();
            }
            return author;
        }

        public async Task<Author> MapAuthorUpdateToAuthor(AuthorUpdate input) {
            Author author = new Author {
                Id = input.Id,
                FirstName = input.FirstName,
                LastName = input.LastName,
                Books = new List<Book>()
            };

            if (input.Books is null) {
                author.Books = new List<Book>();
            }
            else {
                author.Books = await _context.Books.Where(a => input.Books.Any(id => id == a.Id)).ToListAsync();
            }

            return author;
        }
    }
}
