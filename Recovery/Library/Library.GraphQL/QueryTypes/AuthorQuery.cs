using HotChocolate.Resolvers;
using Library.BusinessLogic;
using Library.Datamodel;
using Library.EF;
using Library.GraphQL.DataLoaders;
using Microsoft.EntityFrameworkCore;

namespace Library.GraphQL.QueryTypes {
    [ExtendObjectType(typeof(Query))]
    public class AuthorQuery {
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<Author>> Authors([Service] IAuthorService authorService) {
            return await authorService.GetAsync();
        }
    }
}
