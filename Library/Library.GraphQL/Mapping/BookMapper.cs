using Library.Datamodel;
using Library.EF;
using Library.GraphQL.GraphQLTypes.InputTypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.GraphQL.Mapping {
    public class BookMapper {
        private readonly LibraryContext _context;

        public BookMapper(IDbContextFactory<LibraryContext> libraryContextFactory) {
            _context = libraryContextFactory.CreateDbContext();
        }

        public async Task<Book> MapBookCreateToBook(BookCreate input) {
            Book book = new Book {
                Title = input.Title
            };

            if (input.Authors is null) {
                book.Authors = new List<Author>();
            }
            else {
                book.Authors = await _context.Authors.Where(a => input.Authors.Any(id => id == a.Id)).ToListAsync();
            }
            return book;
        }

        public async Task<Book> MapBookUpdateToBook(BookUpdate input) {
            Book book = new Book {
                Id = input.Id,
                Title = input.Title,
                Authors = new List<Author>()
            };

            book.Title = input.Title;
            if (input.Authors is null) {
                book.Authors = new List<Author>();
            }
            else {
                book.Authors = await _context.Authors.Where(a => input.Authors.Any(id => id == a.Id)).ToListAsync();
            }
            return book;
        }
    }
}
