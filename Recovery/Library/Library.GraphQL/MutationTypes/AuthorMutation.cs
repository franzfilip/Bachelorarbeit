using AutoMapper;
using Library.BusinessLogic;
using Library.Datamodel;
using Library.GraphQLTypes.InputTypes;
using Library.GraphQLTypes.InputTypes.Author;

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

            Author author = mapper.Map<Author>(input);
            return await authorService.AddAsync(author);
        }

        public async Task<Author> UpdateAuthor([Service] IAuthorService authorService, AuthorUpdate input) {
            if (input is null) {
                throw new ArgumentNullException(nameof(input));
            }

            Author author = mapper.Map<Author>(input);
            return await authorService.UpdateAsync(author);
        }
    }
}
