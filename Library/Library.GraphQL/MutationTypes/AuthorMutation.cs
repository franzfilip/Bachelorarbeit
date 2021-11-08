using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Datamodel;
using Library.GraphQL.Contract;

namespace Library.GraphQL.MutationTypes {
    public class AuthorMutation {
        private readonly IAuthorService _authorService;

        public AuthorMutation(IAuthorService authorService) {
            _authorService = authorService;
        }

        public async Task<Author> Create(Author author) => await _authorService.AddAsync(author);
        public async Task<Author> Update(Author author) => await _authorService.UpdateAsync(author);
        public async Task Delete(int id) => await _authorService.RemoveAsync(id);
    }
}
