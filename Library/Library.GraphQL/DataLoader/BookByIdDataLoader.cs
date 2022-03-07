using GreenDonut;
using Library.Datamodel;
using Library.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library.GraphQL.DataLoader {
    public class BookByIdDataLoader : BatchDataLoader<int, Book> {
        private readonly IDbContextFactory<LibraryContext> _dbContextFactory;

        public BookByIdDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<LibraryContext> libraryContextFactory): base(batchScheduler) {
            _dbContextFactory = libraryContextFactory ??
                throw new ArgumentNullException(nameof(libraryContextFactory));
        }

        protected async override Task<IReadOnlyDictionary<int, Book>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken) {
            await using LibraryContext dbContext = _dbContextFactory.CreateDbContext();

            return await dbContext.Books.Where(b => keys.Contains(b.Id)).ToDictionaryAsync(t => t.Id, cancellationToken);
        }
    }
}
