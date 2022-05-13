using AutoMapper;
using Library.BusinessLogic;
using Library.Datamodel;
using Library.GraphQL.Resolver;
using Library.GraphQLTypes.InputTypes;
using Library.GraphQLTypes.InputTypes.Author;
using Library.GraphQLTypes.InputTypes.Book;
using Library.GraphQLTypes.ObjectTypes;

namespace Library.GraphQL.MutationTypes {
    [ExtendObjectType(Name = "Mutation")]
    public class AuthorMutation {
        private readonly IMapper mapper;

        public AuthorMutation(IMapper mapper) {
            this.mapper = mapper;
        }

        public async Task<Author> CreateAuthor([Service] IAuthorService authorService, AuthorCreate input) {
            if (input is null) {
                throw new ArgumentNullException(nameof(input));
            }

            return await authorService.AddAsync(mapper.Map<Author>(input));
        }

        public async Task<Author> UpdateAuthor([Service] IAuthorService authorService, AuthorUpdate input) {
            if (input is null) {
                throw new ArgumentNullException(nameof(input));
            }

            return await authorService.UpdateAsync(mapper.Map<Author>(input));
        }
    }
}
