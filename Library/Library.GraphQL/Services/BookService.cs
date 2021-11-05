using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Datamodel;
using Library.EF;
using Library.GraphQL.Contract;
using Microsoft.EntityFrameworkCore;

namespace Library.GraphQL.Services {
    public class BookService: IBookService
    {
        private readonly LibraryContext _context;

        public BookService(IDbContextFactory<LibraryContext> libraryContextFactory)
        {
            _context = libraryContextFactory.CreateDbContext();
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.Books.Include(b => b.Authors).ToListAsync();
        }

        public async Task<Book> Add(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> Update(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!await EntityExistsAsync(book.Id)) {
                    return null;
                }
                throw;
            }
            return book;
        }

        public Task Remove(int íd)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EntityExistsAsync(long id) {
            return await _context.Books.AnyAsync(l => l.Id == id);
        }
    }
}
