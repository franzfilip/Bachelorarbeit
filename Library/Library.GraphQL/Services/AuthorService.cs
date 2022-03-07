using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Datamodel;
using Library.EF;
using Library.GraphQL.Contract;
using Library.GraphQL.Utils;
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
            return await _context.Authors.FirstOrDefaultAsync(a => a.Id == id);
            //return await QueryWithIncludes().FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Author> AddAsync(Author entity) {
            Author author = new Author { FirstName = entity.FirstName, LastName = entity.LastName };

            if (entity.Books is not null) {
                var books = await _context.Books.Where(a => entity.Books.Contains(a)).ToListAsync();
                author.Books = new List<Book>();
                foreach (var book in books) {
                    author.Books.Add(book);
                }
            }

            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<Author> UpdateAsync(Author entity) {

            var authorToUpdate = await GetByIdAsync(entity.Id);
            authorToUpdate.FirstName = entity.FirstName;
            authorToUpdate.LastName = entity.LastName;

            if (authorToUpdate.Books.Count != entity.Books.Count || !authorToUpdate.Books.All(entity.Books.Contains)) {
                authorToUpdate.Books.UpdateManyToMany(entity.Books, b => b.Id);
            }

            await _context.SaveChangesAsync();
            return authorToUpdate;
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
