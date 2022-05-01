using Library.BusinessLogic;
using Library.Datamodel;

namespace Library.GraphQL.QueryTypes {
    [ExtendObjectType(typeof(Query))]
    public class AuthorQuery {
        public async Task<List<Author>> Authors([Service] IAuthorService authorService) {
            return await authorService.GetAsync(includes: author => author.Books);
        }

        public async Task<Author> AuthorById([Service] IAuthorService authorService, int id) {
            return await authorService.GetFirstAsync(author => author.Id == id, author => author.Books);
        }
    }
}
