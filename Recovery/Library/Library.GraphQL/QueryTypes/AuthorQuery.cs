using HotChocolate.Resolvers;
using Library.BusinessLogic;
using Library.Datamodel;
using Library.EF;
using Library.GraphQL.DataLoaders;
using Microsoft.EntityFrameworkCore;

namespace Library.GraphQL.QueryTypes {
    [ExtendObjectType(typeof(Query))]
    public class AuthorQuery {
        private readonly LibraryContext context;
        public AuthorQuery(IDbContextFactory<LibraryContext> contextFactory) {
            this.context = contextFactory.CreateDbContext();
        }

        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<Author>> Authors([Service] IAuthorService authorService) {
            return await authorService.GetAsync();
        }

        [UseSingleOrDefault]
        [UseProjection]
        [UseFiltering]
        public async Task<IQueryable<Author>> AuthorById([Service] IAuthorService authorService) {
            return await authorService.GetAsync();
        }

        [UseProjection]
        public Task<Author> AuthorWithDataLoader(int id, AuthorByIdDataLoader dataLoader, CancellationToken cancellationToken) {
            var data = dataLoader.LoadAsync(id, cancellationToken);
            if (data is null) {
                throw new NullReferenceException($"Cannot find Author with ID {id}");
            }
            return data;
        }

        //[UseDbContext(typeof(LibraryContext))]
        [UseSingleOrDefault]
        [UseProjection]
        [UseFiltering]
        public IQueryable<Author> TestAuthorStuff() {
            return context.Authors.AsQueryable();
        }
    }
}
