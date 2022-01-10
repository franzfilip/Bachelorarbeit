using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.AspNetCore.Authorization;
using Library.Datamodel;
using Library.GraphQL.Contract;

namespace Library.GraphQL.QueryTypes {
    public class AuthorQuery {
        private readonly IAuthorService _authorService;

        public AuthorQuery(IAuthorService authorService) {
            this._authorService = authorService;
        }
        [Authorize]
        public async Task<IEnumerable<Author>> Authors() => await _authorService.GetAllAsync();

        [Authorize]
        public async Task<Author> Author(int id) {
            var author = await _authorService.GetByIdAsync(id);
            if(author is not null) {
                return author;
            }

            throw new NullReferenceException($"Cannot find Author with ID {id}");
        }
    }
}
