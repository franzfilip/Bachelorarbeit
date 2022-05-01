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
    public class BookRepository : Repository<Book>, IBookRepository {
        public BookRepository(IDbContextFactory<LibraryContext> contextFactory) : base(contextFactory) { }

        public override async Task<Book> AddAsync(Book book) {
            book.Authors = await context.Authors.Where(author => book.Authors.Select(x => x.Id).ToList().Contains(author.Id)).ToListAsync();
            return await base.AddAsync(book);
        }

        public override async Task<Book> UpdateAsync(Book book) {
            var bookToUpdate = await GetFirstAsync(b => b.Id == book.Id, b => b.Authors);
            if (bookToUpdate == null) {
                throw new ArgumentNullException(nameof(bookToUpdate));
            }

            bookToUpdate.Title = book.Title;

            if (book.Authors.Count != bookToUpdate.Authors.Count || !bookToUpdate.Authors.All(book.Authors.Contains)) {
                bookToUpdate.Authors.UpdateManyToMany(book.Authors, b => b.Id);
                bookToUpdate.Authors = await context.Authors.Where(author => book.Authors.Select(a => a.Id).ToList().Contains(author.Id)).ToListAsync();
            }

            return await base.UpdateAsync(bookToUpdate);
        }
    }
}
