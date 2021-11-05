using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Datamodel;
using Library.GraphQL.Contract;

namespace Library.GraphQL.QueryTypes {
    public class AuthorQuery {
        private readonly IAuthorService authorService;

        public AuthorQuery(IAuthorService authorService) {
            this.authorService = authorService;
        }

        public async Task<IEnumerable<Author>> Authors() {
            return await authorService.GetAll();
        }
    }
}
