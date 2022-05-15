using AutoMapper;
using Library.BusinessLogic;
using Library.Datamodel;
using Library.GraphQL.DataLoaders;
using Library.GraphQLTypes.InputTypes.DTO;

namespace Library.GraphQL.Resolver {
    public class AuthorResolver {
        private readonly IAuthorService authorService;
        private readonly IMapper mapper;

        public AuthorResolver(IAuthorService authorService, IMapper mapper) {
            this.authorService = authorService;
            this.mapper = mapper;
        }

        public async Task<IQueryable<Author>> Authors() {
            return await authorService.GetAsync();
        }

        public async Task<Author> CreateAuthor([Service] IAuthorService authorService, AuthorCreate input) {
            return await authorService.AddAsync(mapper.Map<Author>(input));
        }

        public async Task<Author> UpdateAuthor([Service] IAuthorService authorService, AuthorUpdate input) {
            return await authorService.UpdateAsync(mapper.Map<Author>(input));
        }

        public async Task<Author> AuthorByDataLoader(int id, AuthorByIdDataLoader dataLoader, CancellationToken cancellationToken) {
            return await dataLoader.LoadAsync(id, cancellationToken);
        }
    }
}
