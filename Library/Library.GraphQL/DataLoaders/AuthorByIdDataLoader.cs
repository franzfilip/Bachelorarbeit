using Library.BusinessLogic;
using Library.Datamodel;

namespace Library.GraphQL.DataLoaders {
    public class AuthorByIdDataLoader : BatchDataLoader<int, Author> {
        private readonly IAuthorService authorService;
        public AuthorByIdDataLoader(IBatchScheduler batchScheduler, IAuthorService authorService, DataLoaderOptions? options = null) : base(batchScheduler, options) {
            this.authorService = authorService;
        }

        protected override async Task<IReadOnlyDictionary<int, Author>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken) {
            return (await authorService.GetAsync(a => keys.Contains(a.Id), a => a.Books)).ToDictionary(t => t.Id);
        }
    }
}
