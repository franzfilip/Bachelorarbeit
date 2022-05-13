using AutoBetter.DataAccess.impl;
using Library.Datamodel;
using Library.EF;
using Library.EF.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Impl {
    public class AuthorRepository : Repository<Author>, IAuthorRepository {
        public AuthorRepository(IDbContextFactory<LibraryContext> contextFactory) : base(contextFactory) { }

        public override async Task<Author> AddAsync(Author author) {
            author.Books = await context.Books.Where(book => author.Books.Select(x => x.Id).ToList().Contains(book.Id)).ToListAsync();
            return await base.AddAsync(author);
        }

        public override async Task<Author> UpdateAsync(Author author) {
            var authorToUpdate = await GetFirstAsync(a => a.Id == author.Id, a => a.Books);
            if (authorToUpdate == null) {
                throw new ArgumentNullException(nameof(authorToUpdate));
            }

            authorToUpdate.FirstName = author.FirstName;
            authorToUpdate.LastName = author.LastName;

            if (author.Books.Count != authorToUpdate.Books.Count || !authorToUpdate.Books.All(author.Books.Contains)) {
                authorToUpdate.Books.UpdateManyToMany(author.Books, b => b.Id);
                authorToUpdate.Books = await context.Books.Where(book => author.Books.Select(a => a.Id).ToList().Contains(book.Id)).ToListAsync();
            }

            return await base.UpdateAsync(authorToUpdate);
        }
    }
}
