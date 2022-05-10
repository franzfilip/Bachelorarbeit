using AutoMapper;
using Library.BusinessLogic;
using Library.Datamodel;
using Library.GraphQLTypes.InputTypes;

namespace Library.GraphQL.Resolver {
    public class AuthorResolver {
        private readonly IMapper mapper;

        public AuthorResolver(IMapper mapper) {
            this.mapper = mapper;
        }

        //public async Task<Author> CreateAuthor([Service] IAuthorService authorService, AuthorInput input) {
        //    if (input is null) {
        //        throw new ArgumentNullException(nameof(input));
        //    }

        //    Author author = new Author {
        //        //Id = input.Id,
        //        //FirstName = input.FirstName,
        //        //LastName = input.LastName,
        //        //Books = input.Books
        //    };

        //    return await authorService.AddAsync(author);
        //}

        //public async Task<Author> UpdateAuthor([Service] IAuthorService authorService, AuthorInput input) {
        //    if (input is null) {
        //        throw new ArgumentNullException(nameof(input));
        //    }

        //    Author author = new Author {
        //        //Id = input.Id,
        //        //FirstName = input.FirstName,
        //        //LastName = input.LastName,
        //        //Books = input.Books
        //    };

        //    return await authorService.UpdateAsync(author);
        //}
    }
}
