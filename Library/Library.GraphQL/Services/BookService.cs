using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Datamodel;
using Library.EF;
using Library.GraphQL.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Library.GraphQL.Services {
    public class BookService: IBookService
    {
        private readonly LibraryContext _context;

        public BookService(IDbContextFactory<LibraryContext> libraryContextFactory)
        {
            _context = libraryContextFactory.CreateDbContext();
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await QueryWithIncludes().ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await QueryWithIncludes().FirstAsync(b => b.Id == id);
        }

        public async Task<Book> AddAsync(Book author)
        {
            await _context.Books.AddAsync(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<Book> UpdateAsync(Book author)
        {
            _context.Entry(author).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task RemoveAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            _context.Entry(book).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> EntityExistsAsync(int id) {
            return await _context.Books.AnyAsync(l => l.Id == id);
        }

        private IIncludableQueryable<Book, ICollection<Author>> QueryWithIncludes()
            => _context.Books.Include(b => b.Authors);
    }
}
