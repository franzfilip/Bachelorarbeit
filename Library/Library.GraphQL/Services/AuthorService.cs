using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Datamodel;
using Library.EF;
using Library.GraphQL.Contract;
using Microsoft.EntityFrameworkCore;

namespace Library.GraphQL.Services {
    public class AuthorService: IAuthorService
    {
        private readonly LibraryContext _context;

        public AuthorService(IDbContextFactory<LibraryContext> dbContextFactory)
        {
            _context = dbContextFactory.CreateDbContext();
        }


        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author> Add(Author author)
        {
            await _context.AddAsync(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<Author> Update(Author author)
        {
            _context.Entry(author).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!await EntityExistsAsync(author.Id)) {
                    return null;
                }
                throw;
            }
            return author;
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        private async Task<bool> EntityExistsAsync(long id) {
            return await _context.Authors.AnyAsync(l => l.Id == id);
        }
    }
}
