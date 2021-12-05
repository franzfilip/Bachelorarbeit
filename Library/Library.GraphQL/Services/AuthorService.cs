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
    public class AuthorService: IAuthorService
    {
        private readonly LibraryContext _context;

        public AuthorService(IDbContextFactory<LibraryContext> dbContextFactory)
        {
            _context = dbContextFactory.CreateDbContext();
        }

        public async Task<IEnumerable<Author>> GetAllAsync() {
            return await QueryWithIncludes().ToListAsync();
        }

        public async Task<Author> GetByIdAsync(int id) {
            return await QueryWithIncludes().FirstAsync(b => b.Id == id);
        }

        public async Task<Author> AddAsync(Author author) {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<Author> UpdateAsync(Author author) {
            _context.Entry(author).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<bool> RemoveAsync(int id) {
            var author = await _context.Authors.FindAsync(id);
            _context.Entry(author).State = EntityState.Deleted;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EntityExistsAsync(int id) {
            return await _context.Authors.AnyAsync(l => l.Id == id);
        }

        private IIncludableQueryable<Author, List<Book>> QueryWithIncludes()
            => _context.Authors.Include(b => b.Books) as IIncludableQueryable<Author, List<Book>>;
    }
}
