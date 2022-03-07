using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.AspNetCore.Authorization;
using Library.Datamodel;
using Library.GraphQL.Contract;
using Library.GraphQL.GraphQLTypes.InputTypes;
using Library.GraphQL.Mapping;

namespace Library.GraphQL.MutationTypes {
    public class AuthorMutation {
        private readonly IAuthorService _authorService;
        private readonly AuthorMapper _authorMapper;
        public AuthorMutation(IAuthorService authorService, AuthorMapper authorMapper) {
            _authorService = authorService;
            _authorMapper = authorMapper;
        }

        [Authorize(Roles = new[] { "Admin", "Librarian" })]
        public async Task<Author> CreateAuthor(AuthorCreate author) => await _authorService.AddAsync(await _authorMapper.MapAuthorCreateToAuthor(author));
        [Authorize(Roles = new[] { "Admin", "Librarian" })]
        public async Task<Author> UpdateAuthor(AuthorUpdate author) => await _authorService.UpdateAsync(await _authorMapper.MapAuthorUpdateToAuthor(author));
        [Authorize(Roles = new[] { "Admin", "Librarian" })]
        public async Task Delete(int id) => await _authorService.RemoveAsync(id);
    }
}
