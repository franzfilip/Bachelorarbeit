using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Datamodel;
using Library.EF;
using Library.GraphQL.Contract;
using Library.GraphQL.GraphQLTypes.InputTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Library.GraphQL.Utils;

namespace Library.GraphQL.Services {
    public class BookService : IBookService {
        private readonly LibraryContext _context;

        public BookService(IDbContextFactory<LibraryContext> libraryContextFactory) {
            _context = libraryContextFactory.CreateDbContext();
        }

        public async Task<IEnumerable<Book>> GetAllAsync() {
            return await QueryWithIncludes().ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id) {
            return await QueryWithIncludes().FirstAsync(b => b.Id == id);
        }

        public async Task<Book> AddAsync(Book entity) {
            Book book = new Book();
            book.Title = entity.Title;
            if (entity.Authors is not null) {
                var authors = await _context.Authors.Where(a => entity.Authors.Contains(a)).ToListAsync();
                book.Authors = new List<Author>();
                foreach (var author in authors) {
                    book.Authors.Add(author);
                }
            }

            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateAsync(Book entity) {
            var bookToUpdate = await GetByIdAsync(entity.Id);
            bookToUpdate.Title = entity.Title;

            if (bookToUpdate.Authors.Count != entity.Authors.Count || !bookToUpdate.Authors.All(entity.Authors.Contains)) {
                bookToUpdate.Authors.UpdateManyToMany(entity.Authors, a => a.Id);
            }

            await _context.SaveChangesAsync();
            return bookToUpdate;
        }

        public async Task<bool> RemoveAsync(int id) {
            var book = await _context.Books.FindAsync(id);
            _context.Entry(book).State = EntityState.Deleted;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EntityExistsAsync(int id) {
            return await _context.Books.AnyAsync(l => l.Id == id);
        }

        private IIncludableQueryable<Book, ICollection<Author>> QueryWithIncludes()
            => _context.Books.Include(b => b.Authors);
    }
}
