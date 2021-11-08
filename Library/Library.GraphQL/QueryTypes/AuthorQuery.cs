using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Datamodel;
using Library.GraphQL.Contract;

namespace Library.GraphQL.QueryTypes {
    public class AuthorQuery {
        private readonly IAuthorService _authorService;

        public AuthorQuery(IAuthorService authorService) {
            this._authorService = authorService;
        }

        public async Task<IEnumerable<Author>> Authors() => await _authorService.GetAllAsync();

        public async Task<Author> Author(int id) => await _authorService.GetByIdAsync(id);
    }
}
