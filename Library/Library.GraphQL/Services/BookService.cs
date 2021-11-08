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

        public async Task<Book> AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> AddWithAuthorsAsync(string title, ICollection<int> authorsToAdd)
        {
            var authors = await _context.Authors.Where(a => authorsToAdd.Any(id => id == a.Id)).ToListAsync();
            Book book = new Book
            {
                Title = title,
                Authors = authors
            };
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            //TODO updating with author FK does not work, so it will probably fail in Add() too
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return book;
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
